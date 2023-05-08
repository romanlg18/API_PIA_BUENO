using Microsoft.VisualBasic;

namespace API_PROG.model
{
    public class GetClienteCL
    {
        public int IdCliente { get; set; }
        public string CL_NOMBRES { get; set; }
        public string CL_aPELLIDOS { get; set; }

        public string CL_CORREO { get; set; }
        public Int64 CL_NUMERO { get; set; }
        public string SEGURO { get; set; }

        public string Estatus { get; set; }

        public string FECHA_ALTA { get; set; } 
    }


    public class GetCredenciales
    {
        public string Usuario { get; set; }
        public string Password { get; set; }

    }

    public class ClientesInsertar
    {
        public string CL_NOMBRES { get; set; }
        public string CL_aPELLIDOS { get; set; }
        public string CL_CORREO { get; set; }
        public Int64 CL_NUMERO { get; set; }
        public int IDSEGUROS { get; set; }
        public string FECHA_ALTA { get; set; }
    }

    public class UpDeleteClient
    {
        public int idCliente { get; set; }
        public int EstatusCL { get; set; }
    }


    public class ContactoInsertar
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
    }

    public class GetBuzon
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
    }

}
