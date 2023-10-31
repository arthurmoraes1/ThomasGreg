using CadastroCliente.Api.Service;
using CadastroCliente.Domain.Dtos;
using CadastroCliente.Domain.Models;
using CadastroCliente.Infra.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        [HttpPost()]
        public IActionResult Autenticar([FromBody] Usuario model)
        {
            var user = UsuarioRepository.Get(model.Login, model.Password);

            if (user == null)
                return BadRequest(new { message = "Usuário ou senha inválidos." });

            var token = TokenService.GerarToken(user, _configuration);

            return Ok(new LoginDto(model.Login, token, user.Id));
        }

    }
}
