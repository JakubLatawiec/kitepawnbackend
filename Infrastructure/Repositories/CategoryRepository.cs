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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly KitePawnDBContext _context;

        public CategoryRepository(KitePawnDBContext context)
        {
            _context = context;
        }

        public List<Category>? GetAll()
        {
            if (_context.Categories == null)
                return null;

            return _context.Categories.Distinct().ToList();
        }
    }
}
