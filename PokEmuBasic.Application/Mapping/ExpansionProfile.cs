using AutoMapper;
using PokEmuBasic.Application.Dtos;
using PokEmuBasic.Application.Dtos.Responses;
using PokEmuBasic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Mapping
{
    public  class ExpansionProfile : Profile
    {
        public ExpansionProfile()
        {
            CreateMap<Expansion, GetExpansionOptionsResponse>();
        }
    }
}
