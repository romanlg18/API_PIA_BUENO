using Dapper;
using MySql.Data.MySqlClient;
using API_PROG.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace API_PROG.data.Repositorios
{
    public class SegurosRepository : ISegurosRepository
    {
        private readonly MySqlConfiguration _connectionString;

        public SegurosRepository(MySqlConfiguration ConnectionString)
        {
            _connectionString = ConnectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<GetSeguros>> GetAllSeguros()
        {
            var db = dbConnection();
            var sql = @"CALL SELECT_MULTIPLE_ENSURANCE";
            return await db.QueryAsync<GetSeguros>(sql, new { });
        }

        public async Task<IEnumerable<Seguros>> GetSegurosDetails(int idSeguros)
        {
            var db = dbConnection();

            var sql = @"CALL DetalleSeguros(@idSegurosP)";
            return await db.QueryAsync<Seguros>(sql, new { idSegurosP = idSeguros });
        }
        public async Task<bool> UpdateSeguros(int idSeguros, Seguros seguros)
        {
            var db = dbConnection();
            var sql = @"CALL UPDATE_INSURANCE(@idSegurosP, @SegurosP,@SegurosDesP, @EstautsP)";
            var result = await db.ExecuteAsync(sql, new { idSegurosP = idSeguros, SegurosP = seguros.TipoSeguros, SeguroDesP = seguros.SegurosDesc, status_p = seguros.status });
            return result > 0;
        }
        public async Task<bool> BorrarSeguros(int idSeguros)
        {
            var db = dbConnection();

            var sql = @"CALL DELETE_INSURANCE(@idSegurosP)";
            var result = await db.ExecuteAsync(sql, new { idSeguros = idSeguros });

            return result > 0;
        }

        public async Task<IEnumerable<Seguros>> InsertSeguros(SegurosInsertar seguros)
        {
            var db = dbConnection();
            var sql = @"CALL AgregarSeguro(@NombreSeguro)";
            return await db.QueryAsync<Seguros>(sql, new { seguros.NombreSeguro });
        }
    }
}
