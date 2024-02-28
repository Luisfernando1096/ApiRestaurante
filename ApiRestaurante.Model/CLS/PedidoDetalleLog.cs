using System;

namespace ApiRestaurante.Model.CLS
{
    public class PedidoDetalleLog
    {
        int idDeleted;
        int idDetalle;
        bool cocinando;
        String extras;
        String horaEntregado;
        String horaPedido;
        int idCocinero;
        int idProducto;
        int idPedido;
        int cantidad;
        double precio;
        double subTotal;
        String grupo;
        int usuarioDelete;
        String fechaDelete;

        public int IdDetalle { get => idDetalle; set => idDetalle = value; }
        public bool Cocinando { get => cocinando; set => cocinando = value; }
        public string Extras { get => extras; set => extras = value; }
        public string HoraEntregado { get => horaEntregado; set => horaEntregado = value; }
        public string HoraPedido { get => horaPedido; set => horaPedido = value; }
        public int IdCocinero { get => idCocinero; set => idCocinero = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int IdPedido { get => idPedido; set => idPedido = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Precio { get => precio; set => precio = value; }
        public double SubTotal { get => subTotal; set => subTotal = value; }
        public string Grupo { get => grupo; set => grupo = value; }
        public int IdDeleted { get => idDeleted; set => idDeleted = value; }
        public int UsuarioDelete { get => usuarioDelete; set => usuarioDelete = value; }
        public string FechaDelete { get => fechaDelete; set => fechaDelete = value; }

    }
}
