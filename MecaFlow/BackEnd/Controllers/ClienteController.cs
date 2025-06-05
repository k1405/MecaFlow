using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public IEnumerable<ClienteDTO> Get()
        {
            return _clienteService.GetCliente();
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public ClienteDTO Get(int id)
        {
            return _clienteService.GetClienteById(id);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public void Post([FromBody] ClienteDTO cliente)
        {
            _clienteService.AddCliente(cliente);

        }

        // PUT api/<ClienteController>/5
        [HttpPut]
        public void Put([FromBody] ClienteDTO cliente)
        {
            try
            {
                _clienteService.UpdateCliente(cliente);
            }
            catch (Exception e)
            {

            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _clienteService.DeleteCliente(id);
        }
    }
}
