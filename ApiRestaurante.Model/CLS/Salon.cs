using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Model.CLS
{
    public class Salon
    {
        /*DECLARAR LAS VARIABLES*/
        int idSalon;
        string nombre;
        string fondo;
        int nMesas;

        /*DECLARACION DE PROPIEDADES*/
        public int IdSalon { get => idSalon; set => idSalon = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Fondo { get => fondo; set => fondo = value; }
        public int NMesas { get => nMesas; set => nMesas = value; }

    }
}
