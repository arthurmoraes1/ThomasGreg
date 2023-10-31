using AutoMapper;
using CadastroCliente.Domain.Dtos;
using CadastroCliente.Domain.Entities;
using CadastroCliente.Domain.Interfaces;
using CadastroCliente.Domain.Interfaces.Repositories;

namespace CadastroCliente.Application.Applications
{
    public class EnderecoApplication : IEnderecoApplication
    {
        private readonly IEnderecoRepository _logradouroRepository;
        private readonly IMapper _mapper;

        public EnderecoApplication(IEnderecoRepository logradouroRepository, IMapper mapper)
        {
            _logradouroRepository = logradouroRepository;
            _mapper = mapper;
        }

        public async Task<EnderecoDto> Create(Endereco cliente)
        {
            var enderecoMap = await _logradouroRepository.Create(_mapper.Map<Endereco>(cliente));
            return _mapper.Map<EnderecoDto>(enderecoMap);
        }

        public async Task Delete(Guid id)
        {
            await _logradouroRepository.Delete(id);
        }

        public async Task<IEnumerable<EnderecoDto>> Get()
        {
            var logradouros = await _logradouroRepository.GetAll();
            return _mapper.Map<IEnumerable<EnderecoDto>>(logradouros);
        }

        public async Task<EnderecoDto> GetById(Guid id)
        {
            var logradouro = await _logradouroRepository.GetById(id);
            return _mapper.Map<EnderecoDto>(logradouro);
        }

        public async Task Update(Guid id, Endereco logradouro)
        {
            var logradouroMap = _mapper.Map<Endereco>(logradouro);
            await _logradouroRepository.Update(id, logradouroMap);
        }
    }
}
