using API_PIA_BUENO.API_PROG.model;
using API_PROG.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_PROG.data.Repositorios
{
    public interface IClienteRepository
    {
        Task<IEnumerable<GetClienteCL>> GetAllClient();

        Task<IEnumerable<GetCredenciales>> GetCredentials();
        Task<IEnumerable<GetBuzon>> GetDudas();

        Task<bool> InsertClientes(ClientesInsertar clientes);
        Task<bool> BajaClientes(UpDeleteClient clientes);

        Task<bool> UpdateClienteAdmin(UpdateClienteAdmin clientes);

    }
}
