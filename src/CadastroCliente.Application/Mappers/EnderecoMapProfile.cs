using AutoMapper;
using CadastroCliente.Domain.Dtos;
using CadastroCliente.Domain.Entities;

namespace CadastroCliente.Application.Mappers
{
    public class EnderecoMapProfile : Profile
    {
        public EnderecoMapProfile()
        {
            CreateMap<Endereco, EnderecoDto>().ReverseMap();
        }
    }
}
