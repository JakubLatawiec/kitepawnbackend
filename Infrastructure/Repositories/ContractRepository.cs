using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly KitePawnDBContext _context;

        public ContractRepository(KitePawnDBContext context)
        {
            _context = context;
        }

        public Contract? Add(Contract contract)
        {
            var now = DateTime.UtcNow;
            var month = now.ToString("MM");
            var year = now.ToString("yy");

            var existingContracts = _context.Contracts.Where(x => EF.Functions.Like(x.ID, $"{contract.ID}/%/{month}/{year}")).ToList();

            int lastNumber = existingContracts.Select(x => int.Parse(x.ID.Split('/')[1])).DefaultIfEmpty(0).Max();

            contract.ID = $"{contract.ID}/{(lastNumber + 1 < 10 ? '0' : null)}{lastNumber + 1}/{month}/{year}";
            _context.Add(contract);
            _context.SaveChanges();

            var action = new Domain.Entities.Action()
            {
                Name = $"Added contract {contract.ID}",
                Date = DateTime.Now,
                EmployeeID = 1
            };

            _context.Add(action);
            _context.SaveChanges();

            return contract;
        }

        public bool Delete(string id)
        {
            if (_context.Contracts == null)
                return false;

            var contract = _context.Contracts.FirstOrDefault(c => c.ID == id);

            if (contract == null) { return false; }

            _context.Contracts.Remove(contract);
            _context.SaveChanges();

            var action = new Domain.Entities.Action()
            {
                Name = $"Deleted contract {id}",
                Date = DateTime.Now,
                EmployeeID = 1
            };

            _context.Add(action); 
            _context.SaveChanges();

            return true;
        }

        public Contract? Get(string id)
        {
            if (_context.Contracts == null)
                return null;

            return _context.Contracts.Include(c => c.Customer).Include(c => c.Products).ThenInclude(p => p.Category).FirstOrDefault(c => c.ID == id);
        }

        public IEnumerable<Contract>? GetAll(int? limit = null)
        {
            if (_context.Contracts == null)
                return null;

            if (limit == null)
                return _context.Contracts.Include(c => c.Customer).Include(c => c.Products).Distinct().ToList();
            else
                return _context.Contracts.Include(c => c.Customer).Include(c => c.Products).Take((int)limit).Distinct().ToList();
        }
    }
}
