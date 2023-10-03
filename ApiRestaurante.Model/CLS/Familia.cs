using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Model.CLS
{
    public class Familia
    {
        int idFamilia;
        int activo;
        string nombre;
        string grupoPrinter;

        public int IdFamilia { get => idFamilia; set => idFamilia = value; }
        public int Activo { get => activo; set => activo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string GrupoPrinter { get => grupoPrinter; set => grupoPrinter = value; }
    }
}
