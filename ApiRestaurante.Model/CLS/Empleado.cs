using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Model.CLS
{
    public class Empleado
    {
        int _idEmpleado;
        String _nombres;
        String _apellidos;
        String _direccion;
        String _email;
        String _telefono;
        String _dui;
        String _nit;
        double _sueldoBase;
        double _comision;
        String _regContable;

        public int IdEmpleado { get => _idEmpleado; set => _idEmpleado = value; }
        public string Nombres { get => _nombres; set => _nombres = value; }
        public string Apellidos { get => _apellidos; set => _apellidos = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Email { get => _email; set => _email = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Dui { get => _dui; set => _dui = value; }
        public string Nit { get => _nit; set => _nit = value; }
        public double SueldoBase { get => _sueldoBase; set => _sueldoBase = value; }
        public double Comision { get => _comision; set => _comision = value; }
        public string RegContable { get => _regContable; set => _regContable = value; }
    }
}
