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
        public string NombreSeguro { get; set; }
    }

    public class GetSeguros
    {
        public string Nombre_Completo { get; set; }
        public string SEGUROS_TYPE { get; set; }
        public string SEGURO_DESC { get; set; }

        public string CL_CORREO { get; set; }
        public Int64 CL_NUMERO { get; set; }
    }
}
