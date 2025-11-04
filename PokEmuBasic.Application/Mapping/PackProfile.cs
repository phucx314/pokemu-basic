using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PokEmuBasic.Application.Dtos.Responses;
using PokEmuBasic.Domain.Entities;

namespace PokEmuBasic.Application.Mapping
{
    public class PackProfile : Profile
    {
        public PackProfile()
        {
            CreateMap<Pack, GetPacksResponse>();
        }
    }
}
