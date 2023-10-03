using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Model.CLS
{
    public class Usuario
    {
        String username;
        int idEmpleado;
        int idUsuario;
        String rol;
        int idRol;
        
        public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Rol { get => rol; set => rol = value; }
        public int IdRol { get => idRol; set => idRol = value; }
        public string Username { get => username; set => username = value; }
    }
}
