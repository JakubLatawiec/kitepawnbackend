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
    public class ContractDTO : IMap
    {
        public string ID { get; set; } = string.Empty;
        public string Client { get; set; } = string.Empty;
        public string DateStart { get; set; } = string.Empty;
        public string DateEnd { get; set; } = string.Empty;
        public float LoanTotal { get; set; }
        public float ServicePercentage { get; set; }
        public string Status { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Contract, ContractDTO>()
                .ForMember(dest => dest.DateStart, opt => opt.MapFrom(src => src.DateStart.ToShortDateString()))
                .ForMember(dest => dest.DateEnd, opt => opt.MapFrom(src => src.DateEnd.ToShortDateString()))
                .ForMember(dest => dest.Client, opt => opt.MapFrom(src => $"{src.Customer.FirstName} {src.Customer.LastName}"))
                .ForMember(dest => dest.LoanTotal, opt => opt.MapFrom(src => src.Products.Sum(p => p.PricePerItem * p.Count)))
                .ForMember(dest => dest.ServicePercentage, opt => opt.MapFrom(src => (src.DateEnd - src.DateStart).TotalDays * src.InterestPerDay))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.DateEnd < DateTime.Now ? "Overdue" : "Active"));
        }
    }
}
