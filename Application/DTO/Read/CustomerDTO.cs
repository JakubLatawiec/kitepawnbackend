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
    public class CustomerDTO : IMap
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerDTO>();
        }
    }
}
