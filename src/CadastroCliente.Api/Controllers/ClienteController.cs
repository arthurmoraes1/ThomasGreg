using AutoMapper;
using CadastroCliente.Domain.Dtos;
using CadastroCliente.Domain.Entities;
using CadastroCliente.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteApplication _clienteApplication;
        private readonly IMapper _mapper;

        public ClienteController(IClienteApplication clienteApplication, IMapper mapper)
        {
            _clienteApplication = clienteApplication;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _clienteApplication.Get());
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _clienteApplication.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteDto cliente)
        {
            if (cliente == null)
                return NotFound();

            bool isEmailUnique = await _clienteApplication.IsEmailUnique(cliente.Email);

            if (!isEmailUnique)
            {
                return BadRequest(new { message = "O endereço de e-mail já está em uso." });
            }

            var clienteMap = _mapper.Map<Cliente>(cliente);

            return Ok(await _clienteApplication.Create(clienteMap));
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ClienteDto cliente)
        {
            try
            {
                var clienteMap = _mapper.Map<Cliente>(cliente);

                var existeCliente = await _clienteApplication.GetById(cliente.Id);

                if (existeCliente == null)
                    return NotFound();

                bool isEmailUnique = await _clienteApplication.IsEmailUnique(cliente.Email);

                if (!isEmailUnique)
                {
                    return BadRequest(new { message = "O endereço de e-mail já está em uso." });
                }


                await _clienteApplication.Update(id, clienteMap);

                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cliente = await _clienteApplication.GetById(id);

            if (cliente == null)
                return NotFound();

            await _clienteApplication.Delete(id);

            return NoContent();
        }

    }
}
