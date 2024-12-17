using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly KitePawnDBContext _context;

        public CustomerRepository (KitePawnDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer>? GetAll()
        {
            if (_context.Customers == null)
                return null;

            return _context.Customers.Distinct().ToList();
        }
    }
}
