using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seeders
{
    public class KitePawnDBSeeder
    {
        private readonly ModelBuilder _modelBuilder;

        public KitePawnDBSeeder(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            _modelBuilder.Entity<Customer>().HasData(
                new Customer()
                {
                    ID = 1,
                    FirstName = "Danuta",
                    LastName = "Gajewska",
                    Address = "32-012 Krosno Klasztorna 12/2",
                    PhoneNumber = "165706656",
                    EmailAddress = "augue.ac@hotmail.com",
                },
                new Customer()
                {
                    ID = 2,
                    FirstName = "Zdzisław",
                    LastName = "Łuczak",
                    Address = "73-520 Sopot Piesza 13",
                    PhoneNumber = "314360952",
                    EmailAddress = "felis.purus.ac@hotmail.net",
                },
                new Customer()
                {
                    ID = 3,
                    FirstName = "Błażej",
                    LastName = "Urbaniak",
                    Address = "06-571 Siemianowice Śląskie Leśna 24/8",
                    PhoneNumber = "679702769",
                    EmailAddress = "morbi.tristique.senectus@hotmail.net",
                },
                new Customer()
                {
                    ID = 4,
                    FirstName = "Zuzanna",
                    LastName = "Kania",
                    Address = "79-204 Zamość Leśna 44",
                    PhoneNumber = "384028471",
                    EmailAddress = "sit.amet@hotmail.couk",
                },
                new Customer()
                {
                    ID = 5,
                    FirstName = "Svitlana",
                    LastName = "Bednarczyk",
                    Address = "57-490 Dąbrowa Górnicza Sosnowa 23",
                    PhoneNumber = "521411614",
                    EmailAddress = "fusce.dolor@aol.org",
                }
            );

            _modelBuilder.Entity<Employee>().HasData(
                 new Employee()
                 {
                     ID = 1,
                     FirstName = "Jakub",
                     LastName = "Latawiec",
                     Address = "34-700 Kraków Na Błonie 3/33",
                     PhoneNumber = "123123123",
                     EmailAddress = "latawiec@student.agh.edu.pl",
                     Password = "zaq1@WSX"
                 }
            );

            _modelBuilder.Entity<Branch>().HasData(
                new Branch()
                {
                    ID = 1,
                    Name = "Branch 1",
                    Address = "89-602 Łomża Akacjowa 22"
                }
            );

            _modelBuilder.Entity<EmployeeInBranch>().HasData(
                new EmployeeInBranch()
                {
                    EmployeeID = 1,
                    BranchID = 1
                }
            );

            _modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    ID = 1,
                    Name = "Phones"
                },
                new Category()
                {
                    ID = 2,
                    Name = "RTV"
                },
                new Category()
                {
                    ID = 3,
                    Name = "AGD"
                },
                new Category()
                {
                    ID = 4,
                    Name = "Tools"
                },
                new Category()
                {
                    ID = 5,
                    Name = "Other"
                }
            );

            _modelBuilder.Entity<Contract>().HasData(
                new Contract()
                {
                    ID = "L/01/05/24",
                    CustomerID = 1,
                    DateStart = new DateTime(2024, 5, 1),
                    DateEnd = new DateTime(2024, 5, 31),
                    EmployeeID = 1,
                    InterestPerDay = 0.05f
                },
                new Contract()
                {
                    ID = "L/02/05/24",
                    CustomerID = 2,
                    DateStart = new DateTime(2024, 5, 1),
                    DateEnd = new DateTime(2024, 5, 31),
                    EmployeeID = 1,
                    InterestPerDay = 0.05f
                },
                new Contract()
                {
                    ID = "L/03/05/24",
                    CustomerID = 3,
                    DateStart = new DateTime(2024, 5, 2),
                    DateEnd = new DateTime(2024, 6, 1),
                    EmployeeID = 1,
                    InterestPerDay = 0.05f
                },
                new Contract()
                {
                    ID = "L/04/05/24",
                    CustomerID = 4,
                    DateStart = new DateTime(2024, 5, 5),
                    DateEnd = new DateTime(2024, 5, 15),
                    EmployeeID = 1,
                    InterestPerDay = 0.05f
                },
                new Contract()
                {
                    ID = "L/05/05/24",
                    CustomerID = 5,
                    DateStart = new DateTime(2024, 5, 10),
                    DateEnd = new DateTime(2024, 6, 10),
                    EmployeeID = 1,
                    InterestPerDay = 0.05f
                }
            );

            _modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    ID = 1,
                    Name = "Samsung Galaxy S20 5G SM-G981B 8/128GB",
                    CategoryID = 1,
                    Count = 1,
                    PricePerItem = 1200.00f,
                    BranchID = 1,
                    ContractID = "L/01/05/24"
                },
                new Product()
                {
                    ID = 2,
                    Name = "Makita Td001Gm201",
                    CategoryID = 4,
                    Count = 1,
                    PricePerItem = 2050.00f,
                    BranchID = 1,
                    ContractID = "L/02/05/24"
                },
                new Product()
                {
                    ID = 3,
                    Name = "LG 55UR78003LK 55\" 4K Smart TV DVB-T2 Telewizor LED",
                    CategoryID = 2,
                    Count = 1,
                    PricePerItem = 1580.00f,
                    BranchID = 1,
                    ContractID = "L/03/05/24"
                },
                new Product()
                {
                    ID = 4,
                    Name = "SIEMENS EQ.6 Plus S100 TE651209RW",
                    CategoryID = 3,
                    Count = 1,
                    PricePerItem = 1580.00f,
                    BranchID = 1,
                    ContractID = "L/03/05/24"
                }
            );
        }
    }
}
