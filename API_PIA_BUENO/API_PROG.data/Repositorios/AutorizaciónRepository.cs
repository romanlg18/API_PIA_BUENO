using API_PIA_BUENO.API_PROG.model;
using System;

namespace API_PIA_BUENO.API_PROG.data.Repositorios
{
    public class AutorizacionRepositorio
    {
        public static List<string> getToken(string P_connection, login user)
        {
            List<string> ListaValidaciones = new List<string>();
            if (user.User == "admin" && user.Pass == "tKRHO3p8%07dlDSf#B^k")
            {
                ListaValidaciones.Add("00");
            }
            else
            {
                ListaValidaciones.Add("14");
            }

            return ListaValidaciones;
        }
    }
}
