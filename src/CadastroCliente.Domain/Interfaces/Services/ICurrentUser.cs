using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Domain.Interfaces.Services
{
    public interface ICurrentUser
    {

        Guid? GetUserId();
        Task<string> GetToken();
    }
}
