using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IContractRepository
    {
        IEnumerable<Contract>? GetAll(int? limit = null);
        Contract? Get(string id);

        Contract? Add(Contract contract);

        bool Delete(string id);
    }
}
