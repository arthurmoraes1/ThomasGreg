using AutoMapper;
using CadastroCliente.Domain.Dtos;
using CadastroCliente.Domain.Entities;
using CadastroCliente.Domain.Interfaces;
using CadastroCliente.Domain.Interfaces.Repositories;

namespace CadastroCliente.Application.Applications
{
    public class ClienteApplication : IClienteApplication
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteApplication(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteDto> Create(Cliente cliente)
        {
            var clienteMap = await _clienteRepository.Create(_mapper.Map<Cliente>(cliente));
            return _mapper.Map<ClienteDto>(clienteMap);
        }

        public async Task Delete(Guid id)
        {
            await _clienteRepository.Delete(id);
        }

        public async Task<IEnumerable<ClienteDto>> Get()
        {
            var clientes = await _clienteRepository.GetAll();
            return _mapper.Map<IEnumerable<ClienteDto>>(clientes);
        }

        public async Task<ClienteDto> GetById(Guid id)
        {
            var cliente = await _clienteRepository.GetById(id);
            return _mapper.Map<ClienteDto>(cliente);
        }

        public async Task Update(Guid id, Cliente cliente)
        {
            var clienteMap = _mapper.Map<Cliente>(cliente);
            await _clienteRepository.Update(id, clienteMap);
        }

        public async Task<bool> IsEmailUnique(string email)
        {
            var existeCliente = await _clienteRepository.GetClienteByEmail(email);
            return existeCliente == null;
        }
    }
}
