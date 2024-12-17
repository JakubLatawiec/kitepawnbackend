using Application.DTO.Create;
using Application.DTO.Read;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IContractService
    {
        IEnumerable<ContractDTO>? GetContracts(int? limit);
        ContractDetailsDTO? GetContractById(string id);

        Contract? CreateContract(CreateContractDTO dto);

        bool DeleteContract(string id);
    }
}
