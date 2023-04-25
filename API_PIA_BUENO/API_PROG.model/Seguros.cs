namespace API_PROG.model
{
    public class Seguros
    {
        public int idSeguros { get; set; }
        public string TipoSeguros { get; set; }
        public string SegurosDesc { get; set;}  
        public int status { get; set; } 
    }

    public class SegurosInsertar
    {
        public string SEGUROS_TYPE { get; set; }
        public string SEGURO_DESC { get; set; }

        public int ESTATUS { get; set; }
    }

    public class GetCliente
    {
        public string Nombre_Completo { get; set; }
        public string SEGUROS_TYPE { get; set; }
        public string SEGURO_DESC { get; set; }

        public string CL_CORREO { get; set; }
        public Int64 CL_NUMERO { get; set; }
    }

    public class GetSegurosID
    {
        public string SEGUROS_TYPE { get; set; }
        public string SEGURO_DESC { get; set; }

        public int ESTATUS { get; set; }
    }

    public class GetSeguros
    {
        public int idSeguros { get; set; }
        public string SEGUROS_TYPE { get; set; }
        public string SEGURO_DESC { get; set; }

        public int ESTATUS { get; set; }
    }

    public class UpdateSeguros
    {
        public int idSeguros { get; set; }
        public string SEGUROS_TYPE { get; set; }
        public string SEGURO_DESC { get; set; }

        public int ESTATUS { get; set; }
    }


    public class DeleteSeguros
    {
        public int idSeguros { get; set; }
    }

}
