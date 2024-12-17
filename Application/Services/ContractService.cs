using Application.DTO.Create;
using Application.DTO.Read;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _repository;
        private readonly IMapper _mapper;

        public ContractService(IContractRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Contract? CreateContract(CreateContractDTO dto)
        {
            var contract = _mapper.Map<Contract>(dto);
            if (dto.Type == "L")
                contract.ID = "L";
            else
                contract.ID = "S";

            return _repository.Add(contract);
        }

        public bool DeleteContract(string id)
        {
            return _repository.Delete(id);
        }

        public ContractDetailsDTO? GetContractById(string id)
        {
            var data = _repository.Get(id);
            return _mapper.Map<ContractDetailsDTO>(data);
        }

        public IEnumerable<ContractDTO>? GetContracts(int? limit)
        {
           var data = _repository.GetAll(limit);
           return _mapper.Map<IEnumerable<ContractDTO>>(data);
        }
    }
}
