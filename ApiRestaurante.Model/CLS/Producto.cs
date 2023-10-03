using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Model.CLS
{
    public class Producto
    {
        int idProducto;
        string nombre;
        string descripcion;
        double precio;
        double costo;
        int inventariable;
        int conIngrediente;
        int stock;
        int stockMinimo;
        int activo;
        int idFamilia;
        string familia;
        string grupoPrinter;

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Precio { get => precio; set => precio = value; }
        public double Costo { get => costo; set => costo = value; }
        public int Inventariable { get => inventariable; set => inventariable = value; }
        public int ConIngrediente { get => conIngrediente; set => conIngrediente = value; }
        public int Stock { get => stock; set => stock = value; }
        public int StockMinimo { get => stockMinimo; set => stockMinimo = value; }
        public int Activo { get => activo; set => activo = value; }
        public int IdFamilia { get => idFamilia; set => idFamilia = value; }
        public string Familia { get => familia; set => familia = value; }
        public string GrupoPrinter { get => grupoPrinter; set => grupoPrinter = value; }
    }
}
