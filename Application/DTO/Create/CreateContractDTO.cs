using Application.Mapper;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Create
{
    public class CreateContractDTO : IMap
    {
        public string CustomerID { get; set; } = string.Empty;
        public string DateStart { get; set; } = string.Empty;
        public string DateEnd { get; set; } = string.Empty;
        public string EmployeeID { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public List<CreateProductDTO>? Products { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateContractDTO, Contract>();
        }
    }

    public class CreateProductDTO : IMap
    {
        public string Name { get; set; } = string.Empty;
        public string CategoryID { get; set; } = string.Empty;
        public string Count { get; set; } = string.Empty;
        public float PricePerItem { get; set; }
        public int BranchID { get; set; } = 1;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductDTO, Product>();
        }
    }
}
