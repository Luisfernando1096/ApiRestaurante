using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Model.CLS
{
    public class Ingrediente
    {
        int idProducto;
        int idIngrediente;
        int cantidad;
        int stock_ingrediente;
        int stock_producto;

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int IdIngrediente { get => idIngrediente; set => idIngrediente = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Stock_ingrediente { get => stock_ingrediente; set => stock_ingrediente = value; }
        public int Stock_producto { get => stock_producto; set => stock_producto = value; }
    }
}
