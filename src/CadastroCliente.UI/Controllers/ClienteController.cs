using CadastroCliente.Domain.Dtos;
using CadastroCliente.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.UI.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteService.GetClientesAsync();

            return View(clientes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClienteDto clienteDto)
        {
            if (ModelState.IsValid)
            {
                var success = await _clienteService.CreateClienteAsync(clienteDto);

                if (success)
                {
                    TempData["Sucesso"] = "Cliente salvo com sucesso.";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Erro ao salvar cliente.");
                }
            }

            return View(clienteDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            var clienteDto = await _clienteService.GetByIdAsync(id);
            if (clienteDto == null)
            {
                return NotFound(); 
            }

            return View(clienteDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClienteDto cliente)
        {
            if (ModelState.IsValid)
            {

                var success = await _clienteService.UpdateClienteAsync(cliente.Id, cliente);

                if (success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Erro ao atualizar cliente.");
                }
            }

            return View(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var clienteDto = await _clienteService.GetByIdAsync(id);

            if (clienteDto == null)
            {
                return NotFound(); 
            }

            return View(clienteDto);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var success = await _clienteService.DeleteClienteAsync(id);

            if (success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Erro ao excluir cliente.");
                return View();
            }
        }


        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var clienteDto = await _clienteService.GetByIdAsync(id);

            if (clienteDto == null)
            {
                return NotFound(); 
            }

            return View(clienteDto);
        }
    }
}
