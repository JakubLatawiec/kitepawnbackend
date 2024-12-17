using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ActionsRepository : IActionsRepository
    {
        private readonly KitePawnDBContext _context;

        public ActionsRepository(KitePawnDBContext context)
        {
            _context = context;
        }

        IEnumerable<Domain.Entities.Action>? IActionsRepository.GetAll()
        {
            if (_context.Actions == null)
                return null;

            return _context.Actions.Take(5).OrderByDescending(a => a.Date).ToList();
        }
    }
}
