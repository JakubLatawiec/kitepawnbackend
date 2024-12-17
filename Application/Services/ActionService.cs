using Application.DTO.Read;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ActionService : IActionService
    {
        private readonly IActionsRepository _repository;
        private readonly IMapper _mapper;

        public ActionService(IActionsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IEnumerable<ActionDTO> GetActions()
        {
            var data = _repository.GetAll();
            return _mapper.Map<List<ActionDTO>>(data);
        }
    }
}
