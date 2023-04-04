using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.Model.DTO;

namespace WebApplication1.DtoMapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDTO, Register>().ReverseMap();
            CreateMap<LoginDTO, LoginVM>().ReverseMap();
        }
    }
}
