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

        public async Task<IEnumerable<GetCliente>> GetAllClient()
        {
            var db = dbConnection();
            var sql = @"CALL SELECT_MULTIPLE_ENSURANCE";
            return await db.QueryAsync<GetCliente>(sql, new { });
        }

        public async Task<IEnumerable<GetSegurosID>> GetSegurosID(int idSeguros)
        {
            var db = dbConnection();

            var sql = @"CALL SelectDetailsSeguros(@idSegurosP)";
            return await db.QueryAsync<GetSegurosID>(sql, new { idSegurosP = idSeguros });
        }

        public async Task<IEnumerable<GetSeguros>> GetSeguros()
        {
            var db = dbConnection();
            var sql = @"CALL SELECT_SEGUROS";
            return await db.QueryAsync<GetSeguros>(sql, new { });
        }

        public async Task<bool> UpdateSeguros(int idSeguros, UpdateSeguros seguros)
        {
            var db = dbConnection();
            var sql = @"CALL UPDATE_INSURANCE(@idSegurosP, @SegurosP ,@SegurosDesP, @EstautsP)";
            var result = await db.ExecuteAsync(sql, new { idSegurosP = idSeguros, SegurosP = seguros.SEGUROS_TYPE, SegurosDesP = seguros.SEGURO_DESC, EstautsP = seguros.ESTATUS });
            return result > 0; 
        }



        public async Task<bool> InsertSeguros(SegurosInsertar seguros)
        {
            var db = dbConnection();
            var sql = @"CALL AgregarSeguro(@SegurosP, @SegurosDesP, @EstautsP)";
            var result = await db.ExecuteAsync(sql, new { SegurosP = seguros.SEGUROS_TYPE, SegurosDesP = seguros.SEGURO_DESC, EstautsP = seguros.ESTATUS });
            return result > 0;
        }

        public async Task<bool> BorrarSeguros(int idSeguros, DeleteSeguros seguros)
        {
            var db = dbConnection();

            var sql = @"CALL DELETE_INSURANCE(@idSegurosP)";
            var result = await db.ExecuteAsync(sql, new { idSegurosP = idSeguros });

            return result > 0;
        }
    }
}
