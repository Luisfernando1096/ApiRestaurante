using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Model.CLS
{
    public class PedidoDetalle
    {
        int idDetalle;
        bool cocinando;
        String extras;
        String horaEntregado;
        String horaPedido;
        int idCocinero;
        String cocinero;
        int idProducto;
        String nombre;
        int idPedido;
        int cantidad;
        double precio;
        double subTotal;
        String grupo;
        String usuario;
        String fecha;

        public int IdDetalle { get => idDetalle; set => idDetalle = value; }
        public bool Cocinando { get => cocinando; set => cocinando = value; }
        public string Extras { get => extras; set => extras = value; }
        public string HoraEntregado { get => horaEntregado; set => horaEntregado = value; }
        public string HoraPedido { get => horaPedido; set => horaPedido = value; }
        public int IdCocinero { get => idCocinero; set => idCocinero = value; }
        public string Cocinero { get => cocinero; set => cocinero = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int IdPedido { get => idPedido; set => idPedido = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Precio { get => precio; set => precio = value; }
        public double SubTotal { get => subTotal; set => subTotal = value; }
        public string Grupo { get => grupo; set => grupo = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Fecha { get => fecha; set => fecha = value; }
    }
}
