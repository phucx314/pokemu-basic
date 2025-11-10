using AutoMapper;
using PokEmuBasic.Application.Dtos.Responses;
using PokEmuBasic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Mapping
{
    public class PackRarityDropRateProfile : Profile
    {
        public PackRarityDropRateProfile()
        {
            CreateMap<PackRarityDropRate, DropRateResponse>()
                .ForMember(dest => dest.RarityName, opt => opt.MapFrom(src => src.Rarity.RarityName));
        }
    }
}
