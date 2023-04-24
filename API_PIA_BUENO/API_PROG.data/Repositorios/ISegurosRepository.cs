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
        Task<IEnumerable<GetSeguros>> GetAllSeguros();
        Task<IEnumerable<Seguros>> GetSegurosDetails(int idSeguros);
        Task<IEnumerable<Seguros>> InsertSeguros(SegurosInsertar seguros);
        Task<bool> UpdateSeguros(int idSeguros, Seguros seguros);
        Task<bool> BorrarSeguros(int idSeguros);
    }
}
