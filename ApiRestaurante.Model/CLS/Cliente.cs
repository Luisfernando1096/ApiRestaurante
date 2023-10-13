using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Model.CLS
{
    public class Cliente
    {
        int _idCliente;
        String _nombre;
        String _direccion;
        String _email;
        String _telefono;
        String _NIT;
        String _regContable;

        public int IdCliente { get => _idCliente; set => _idCliente = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Email { get => _email; set => _email = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string NIT { get => _NIT; set => _NIT = value; }
        public string RegContable { get => _regContable; set => _regContable = value; }
    }
}
