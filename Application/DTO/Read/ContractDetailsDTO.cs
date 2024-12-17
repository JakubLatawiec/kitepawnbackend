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
    public class ContractDetailsDTO : IMap
    {
        public string ID { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string DateStart { get; set; } = string.Empty;
        public string DateEnd { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public CustomerContratDTO? Customer { get; set; }

        public List<ProductDTO>? Products { get; set; }



        public void Mapping(Profile profile)
        {
            profile.CreateMap<Contract, ContractDetailsDTO>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.ID[0] == 'L' ? "Loan" : "Sell"))
                .ForMember(dest => dest.DateStart, opt => opt.MapFrom(src => src.DateStart.ToShortDateString()))
                .ForMember(dest => dest.DateEnd, opt => opt.MapFrom(src => src.DateEnd.ToShortDateString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.DateEnd < DateTime.Now ? "Overdue" : "Active"));
        }
        
    }

    public class CustomerContratDTO : IMap
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerContratDTO>();
        }
    }

    public class ProductDTO : IMap
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int Count { get; set; }
        public float PricePerItem { get; set; }
        public float TotalPrice { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.PricePerItem * src.Count));
        }
    }
}
