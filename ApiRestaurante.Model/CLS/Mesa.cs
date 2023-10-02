using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Model.CLS
{
    public class Mesa
    {
        int idMesa;
        int numero;
        String nombre;
        int capacidad;
        Boolean disponible;
        int idSalon;
        String salon;

        public int IdMesa { get => idMesa; set => idMesa = value; }
        public int Numero { get => numero; set => numero = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }
        public bool Disponible { get => disponible; set => disponible = value; }
        public int IdSalon { get => idSalon; set => idSalon = value; }
        public string Salon { get => salon; set => salon = value; }
    }
}
