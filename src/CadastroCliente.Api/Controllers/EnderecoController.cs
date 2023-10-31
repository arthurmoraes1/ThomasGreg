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
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoApplication _logradouroApplication;
        private readonly IClienteApplication _clienteApplication;
        private readonly IMapper _mapper;

        public EnderecoController(IEnderecoApplication logradouroApplication, IMapper mapper, IClienteApplication clienteApplication)
        {
            _logradouroApplication = logradouroApplication;
            _mapper = mapper;
            _clienteApplication = clienteApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _logradouroApplication.Get());
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _logradouroApplication.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EnderecoDto logradouro)
        {
            var cliente = await _clienteApplication.GetById(logradouro.ClienteId);

            if (cliente == null)
            {
                return BadRequest("Cliente não encontrado.");
            }

            var logradouroMap = _mapper.Map<Endereco>(logradouro);

            return Ok(await _logradouroApplication.Create(logradouroMap));
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EnderecoDto logradouro)
        {
            try
            {
                var logradouroMap = _mapper.Map<Endereco>(logradouro);

                var existeLogradouro = await _logradouroApplication.GetById(id);

                if (existeLogradouro == null)
                    return NotFound();

                var cliente = await _clienteApplication.GetById(logradouro.ClienteId);
                
                if (cliente == null)
                {
                    return BadRequest("Informe um id de cliente válido.");
                }

                await _logradouroApplication.Update(id, logradouroMap);

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
            var logradouro = await _logradouroApplication.GetById(id);

            if (logradouro == null)
                return NotFound();

            await _logradouroApplication.Delete(id);

            return NoContent();
        }

    }
}
