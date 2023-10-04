using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Model.CLS
{
    public class PedidoDetalle
    {
        int idPedido;
        int idProducto;
        int cantidad;
        double precio;
        String nombre;
        double subTotal;
        DateTime fecha;

        public int IdPedido { get => idPedido; set => idPedido = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Precio { get => precio; set => precio = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double SubTotal { get => subTotal; set => subTotal = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
