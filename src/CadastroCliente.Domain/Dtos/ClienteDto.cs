﻿namespace CadastroCliente.Domain.Dtos
{
    public class ClienteDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Logotipo { get; set; }
    }
}
