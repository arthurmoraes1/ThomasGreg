using CadastroCliente.Domain.Dtos;
using CadastroCliente.Domain.Entities;
using CadastroCliente.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CadastroCliente.UI.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly IEnderecoService _enderecoService;
        private readonly IClienteService _clienteService;

        public EnderecoController(IEnderecoService enderecoService, IClienteService clienteService)
        {
            _enderecoService = enderecoService;
            _clienteService = clienteService;
        }

        public async Task<IActionResult> Index()
        {
            var enderecos = await _enderecoService.GetEnderecosAsync();

            return View(enderecos);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var clientes = await _clienteService.GetClientesAsync();

            var clientesSelectList = clientes.Select(c => new SelectListItem
            {
                Text = c.Nome,
                Value = c.Id.ToString()
            });

            ViewBag.Clientes = clientesSelectList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EnderecoDto enderecoDto)
        {

            var success = await _enderecoService.CreateEnderecoAsync(enderecoDto);

            if (success)
            {
                TempData["Sucesso"] = "Logradouro salvo com sucesso.";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Erro ao salvar logradouro.");
            }

            return View(enderecoDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            var enderecoDto = await _enderecoService.GetEnderecoByIdAsync(id);
            if (enderecoDto == null)
            {
                return NotFound();
            }

            enderecoDto.Cliente = await _clienteService.GetByIdAsync(enderecoDto.ClienteId);

            return View(enderecoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EnderecoDto endereco)
        {
            if (ModelState.IsValid)
            {

                var success = await _enderecoService.UpdateEnderecoAsync(endereco.Id, endereco);

                if (success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Erro ao atualizar endereço.");
                }
            }

            return View(endereco);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var enderecoDto = await _enderecoService.GetEnderecoByIdAsync(id);

            if (enderecoDto == null)
            {
                return NotFound();
            }

            return View(enderecoDto);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var success = await _enderecoService.DeleteEnderecoAsync(id);

            if (success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Erro ao excluir endereço.");
                return View();
            }
        }


        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var enderecoDto = await _enderecoService.GetEnderecoByIdAsync(id);

            if (enderecoDto == null)
            {
                return NotFound();
            }

            enderecoDto.Cliente = await _clienteService.GetByIdAsync(enderecoDto.ClienteId);

            return View(enderecoDto);
        }
    }
}
