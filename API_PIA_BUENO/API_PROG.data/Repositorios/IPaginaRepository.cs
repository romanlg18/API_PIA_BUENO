using API_PIA_BUENO.API_PROG.model;
using API_PROG.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_PIA_BUENO.API_PROG.data.Repositorios
{
    public interface IPaginaRepository
    {
        Task<bool> ContactoInsertarPagina(ContactoInsertarPagina clientes);

        Task<bool> InsertClientes(ClientesInsertar clientes);

    }
}
