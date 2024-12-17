using Application.DTO.Create;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _service;
        public ContractController(IContractService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var data = _service.GetContracts(null);
            if (data == null) { return NotFound(); }
            return Ok(data);
        }

        [HttpGet("details")]
        public IActionResult Get([FromQuery] string contractID) 
        { 
            var data = _service.GetContractById(contractID);
            if (data == null) { return NotFound(); };
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateContractDTO dto)
        {
            var data = _service.CreateContract(dto);
            return Created($"api/[controller]/{data.ID}", data);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] string contractID)
        {
            bool result = _service.DeleteContract(contractID);
            if (result) { return NoContent(); }
            return NotFound();
        }
    }
}
