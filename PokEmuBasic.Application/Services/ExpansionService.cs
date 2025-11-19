using AutoMapper;
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
    public class ExpansionService : IExpansionService
    {
        private readonly IExpansionRepository _expansionRepository;
        private readonly ICurrentUserContext _currentUserContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExpansionService(
            IExpansionRepository expansionRepository,
            ICurrentUserContext currentUserContext,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _expansionRepository = expansionRepository;
            _currentUserContext = currentUserContext;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetExpansionOptionsResponse>> GetExpansionOptionsAsync()
        {
            var expansions = await _expansionRepository.GetExpansionsOptionsAsync();

            var res = _mapper.Map<List<GetExpansionOptionsResponse>>(expansions);

            return res;
        }
    }
}
