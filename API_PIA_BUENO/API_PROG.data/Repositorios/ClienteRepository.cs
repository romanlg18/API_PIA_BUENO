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
    public class ClientesRepository : IClienteRepository
    {
        private readonly MySqlConfiguration _connectionString;

        public ClientesRepository(MySqlConfiguration ConnectionString)
        {
            _connectionString = ConnectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<GetClienteCL>> GetAllClient()
        {
            var db = dbConnection();
            var sql = @"CALL SELECTCLIENTS";
            return await db.QueryAsync<GetClienteCL>(sql, new { });
        }

        public async Task<bool> BajaClientes(int idCliente, UpDeleteClient clientes)
        {
            var db = dbConnection();
            var sql = @"CALL delete_update_client(@idClienteP, @EstatusCLP)";
            var result = await db.ExecuteAsync(sql, new { idClienteP = idCliente, EstatusCLP = clientes.EstatusCL });
            return result > 0;
        }

        public async Task<bool> InsertClientes(ClientesInsertar clientes)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCliente(int idCliente, UpdateClient clientes)
        {
            throw new NotImplementedException();
        }
    }
}
