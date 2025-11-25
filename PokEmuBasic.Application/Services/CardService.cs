using AutoMapper;
using PokEmuBasic.Application.Dtos.Requests;
using PokEmuBasic.Application.Dtos.Responses;
using PokEmuBasic.Application.Repositories;
using PokEmuBasic.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IExpansionRepository _expansionRepository;
        private readonly ICurrentUserContext _currentUserContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CardService(
            ICardRepository cardRepository,
            IExpansionRepository expansionRepository,
            ICurrentUserContext currentUserContext,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _cardRepository = cardRepository;
            _expansionRepository = expansionRepository;
            _currentUserContext = currentUserContext;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<(List<GetCardListResponse> cards, int total, string? expansionName)> GetCardListByExpansionAsync(GetCardListRequest request)
        {
            var (cards, total) = await _cardRepository.GetCardListByExpansionAsync(request);

            int? filterExpansionId = request.ExpansionId;

            var expansionName = "Others"; // default

            if (!filterExpansionId.HasValue)
            {
                var latestExpansion = await _expansionRepository.GetLatestExpansionAsync();

                if (latestExpansion != null)
                {
                    filterExpansionId = latestExpansion.Id;
                    expansionName = latestExpansion.ExpansionName;
                }
            }
            else
            {
                var expansion = await _expansionRepository.GetByIdAsync(filterExpansionId.Value);

                expansionName = expansion?.ExpansionName;
            }

            var res = _mapper.Map<List<GetCardListResponse>>(cards);

            return (res, total, expansionName);
        }

        public async Task<(List<GetCardListResponse> cards, int total, string? expansionName)> GetUserCardListByExpansionAsync(GetCardListRequest request)
        {
            var currentUserId = _currentUserContext.UserId;

            var (cards, total) = await _cardRepository.GetUserCardListByExpansionAsync(request, currentUserId);

            int? filterExpansionId = request.ExpansionId;

            var expansionName = "Others"; // default

            if (!filterExpansionId.HasValue)
            {
                var latestExpansion = await _expansionRepository.GetLatestExpansionAsync();

                if (latestExpansion != null)
                {
                    filterExpansionId = latestExpansion.Id;
                    expansionName = latestExpansion.ExpansionName;
                }
            }
            else
            {
                var expansion = await _expansionRepository.GetByIdAsync(filterExpansionId.Value);

                expansionName = expansion?.ExpansionName;
            }

            var res = _mapper.Map<List<GetCardListResponse>>(cards);

            return (res, total, expansionName);
        }
    }
}
