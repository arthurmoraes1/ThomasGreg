using AutoMapper;
using CadastroCliente.Domain.Dtos;
using CadastroCliente.Domain.Entities;

namespace CadastroCliente.Application.Mappers
{
    public class ClienteMapProfile : Profile
    {
        public ClienteMapProfile()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
        }
    }
}
