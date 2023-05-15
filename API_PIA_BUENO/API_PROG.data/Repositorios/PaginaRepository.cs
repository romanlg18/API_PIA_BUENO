using Dapper;
using MySql.Data.MySqlClient;
using API_PROG.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_PIA_BUENO.API_PROG.model;
using API_PROG.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_PIA_BUENO.API_PROG.data.Repositorios;

namespace API_PROG.data.Repositorios
{
    public class PaginaRepository : IPaginaRepository
    {
        private readonly MySqlConfiguration _connectionString;

        public PaginaRepository(MySqlConfiguration ConnectionString)
        {
            _connectionString = ConnectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> ContactoInsertarPagina(ContactoInsertarPagina clientes)
        {
            var db = dbConnection();
            var sql = @"CALL AddSituation(@NombreP, @CorreoP, @AsuntoP,  @MensajeP)";
            var result = await db.ExecuteAsync(sql, new { NombreP = clientes.Nombre, CorreoP = clientes.Correo, AsuntoP = clientes.Asunto, MensajeP = clientes.Mensaje });
            return result > 0;
        }

        public async Task<bool> InsertClientes(ClientesInsertar clientes)
        {
            var db = dbConnection();
            var sql = @"CALL AgregarCliente(@NombresP, @ApellidosP, @NumeroP, @CorreoP, @IdSegurosP, @FECHAP )";
            var result = await db.ExecuteAsync(sql, new { NombresP = clientes.CL_NOMBRES, ApellidosP = clientes.CL_aPELLIDOS, NumeroP = clientes.CL_NUMERO, CorreoP = clientes.CL_CORREO, IdSegurosP = clientes.IDSEGUROS, FECHAP = clientes.FECHA_ALTA });
            return result > 0;
        }


    }
}
