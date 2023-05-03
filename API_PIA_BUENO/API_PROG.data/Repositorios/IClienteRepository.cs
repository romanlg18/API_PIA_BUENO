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

        Task<bool> InsertClientes(ClientesInsertar clientes);

        Task<bool> BajaClientes(UpDeleteClient clientes);


    }
}
