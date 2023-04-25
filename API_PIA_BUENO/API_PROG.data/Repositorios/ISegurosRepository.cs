using API_PROG.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_PROG.data.Repositorios
{
    public interface ISegurosRepository
    {
        Task<IEnumerable<GetCliente>> GetAllClient();

        Task<IEnumerable<GetSegurosID>> GetSegurosID(int idSeguros);

        Task<bool> InsertSeguros(SegurosInsertar seguros);


        Task<bool> UpdateSeguros(int idSeguros, UpdateSeguros seguros);


        Task<bool> BorrarSeguros(int idSeguros, DeleteSeguros seguros);


        Task<IEnumerable<GetSeguros>> GetSeguros();

    }
}
