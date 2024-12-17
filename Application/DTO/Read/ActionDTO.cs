using Application.Mapper;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Read
{
    public class ActionDTO : IMap
    {
        public string Name { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Action, ActionDTO>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString()));
        }
    }
}
