using AutoMapper;
using PokEmuBasic.Application.Dtos.Responses;
using PokEmuBasic.Application.Exceptions;
using PokEmuBasic.Application.Repositories;
using PokEmuBasic.Application.Services.Interfaces;
using PokEmuBasic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Services
{
    public class PackService : IPackService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPackRepository _packRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IUserCardRepository _userCardRepository;
        private readonly ICurrentUserContext _currentUserContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PackService(
            IUserRepository userRepository,
            IPackRepository packRepository,
            ICardRepository cardRepository,
            IUserCardRepository userCardRepository,
            ICurrentUserContext currentUserContext,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _packRepository = packRepository;
            _cardRepository = cardRepository;
            _userCardRepository = userCardRepository;
            _currentUserContext = currentUserContext;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OpenCardResponse>> OpenPackAsync(int packId)
        {
            // 0. get current id of user
            var userId = _currentUserContext.UserId ?? throw new UnAuthorizedException("Not signed in");

            // 1. start transaction

            // 2. get user & pack
            var user = await _userRepository.GetUserByIdAsync(userId) ?? throw new NotFoundException("User not found");

            var pack = await _packRepository.GetPackByIdAsync(packId) ?? throw new NotFoundException("Pack not found");

            if (pack.GlobalQuantity <= 0)
            {
                throw new NotFoundException("Pack sold out");
            }

            // 3. coin payment
            if (user.CoinBalance < pack.Price)
            {
                throw new Exception("Coin balance is not sufficient");
            }

            user.CoinBalance -= pack.Price;
            await _userRepository.UpdateAsync(user);

            // 4. get drop rates
            var dropRates = await _packRepository.GetDropRatesAsync(packId);

            // 5. roll by card quantity
            var newCards = new List<UserCard>();
            var newCardsForMapping = new List<Card>();

            for (int i = 0; i < pack.CardQuantity; i++)
            {
                // a. roll rarity
                var rolledRarityId = RollRarity(dropRates);

                // b. roll cards
                var rolledCard = await _cardRepository.GetRandomCardByRarityAsync(rolledRarityId) ?? throw new Exception("Error while rolling card");

                // c. assign card to user by creating new "version" of it into UserCard
                var userCard = new UserCard
                {
                    UserId = user.Id,
                    CardId = rolledCard.Id,
                    AcquiredAt = DateTime.UtcNow
                };

                newCards.Add(userCard);
                newCardsForMapping.Add(rolledCard);
            }

            // 6. add these new cards to db
            await _userCardRepository.AddRangeAsync(newCards);

            // 7. minus 1 pack from global quantity
            pack.GlobalQuantity--;
            await _packRepository.UpdateAsync(pack);

            // 8. commit transaction
            await _unitOfWork.SaveChangesAsync();

            // 9. sort by rarity id
            var sortedCards = newCardsForMapping.OrderBy(card => card.RarityId);

            // 10. map to response and return response
            var openedCards = _mapper.Map<IEnumerable<OpenCardResponse>>(sortedCards);

            var response = openedCards;

            return response;
        }

        private static int RollRarity(IEnumerable<PackRarityDropRate> dropRates) // use weight random algorithm
        {
            // take a random number from 0.0 to 1.0
            // dung Random.Shared an toan cho thread, ko can new Random()
            double diceRoll = Random.Shared.NextDouble();

            // imagine a line from 0.0 to 1.0
            double cumulative = 0.0;

            // sort rate
            foreach (var dropRate in dropRates)
            {
                // aggregate rate into the "line"
                cumulative += (double)dropRate.DropRate;

                // check if the diceRoll falls within the current cumulative range
                if (diceRoll < cumulative)
                {
                    return dropRate.RarityId;
                }
            }

            // handle exception when dropRate agg is not equal to 1.0
            return dropRates.LastOrDefault()?.RarityId ?? 0; // return 0 if empty list
        }

        public async Task<List<GetPacksResponse>> GetAllAvailablePacks()
        {
            var packs = await _packRepository.GetAllAvailablePacksAsync();

            var response = _mapper.Map<List<GetPacksResponse>>(packs);

            return response;
        }

        public async Task<List<GetPacksResponse>> GetFeaturedPacksAsync()
        {
            var packs = await _packRepository.GetFeaturedPacksAsync();

            var response = _mapper.Map<List<GetPacksResponse>>(packs);

            return response;
        }

        public async Task<List<GetPacksResponse>> GetAllPacks()
        {
            var packs = await _packRepository.GetAllPacksAsync();

            var response = _mapper.Map<List<GetPacksResponse>>(packs);

            return response;
        }
    }
}
