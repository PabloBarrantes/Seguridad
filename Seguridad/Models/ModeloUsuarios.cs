using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seguridad.Models
{
    public class ModeloUsuarios
    {
        ContextoSeguridad contexto;

        public ModeloUsuarios()
        {
            contexto = new ContextoSeguridad();
        }

        public USUARIOS ExisteUsuario(String username, String pass)
        {
            var consulta = from datos in contexto.USUARIOS
                           where datos.userName == username
                           && datos.pass == pass
                           select datos;
            return consulta.FirstOrDefault();
        }

    }
}