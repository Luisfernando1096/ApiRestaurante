using ApiRestaurante.Model.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Data.Repositorios
{
    public interface IPedidoDetalleRepository
    {
        Task<IEnumerable<PedidoDetalle>> ObtenerDetallePedidoPorMesa(int id);
        Task<bool> ActualizarCompra(PedidoDetalle pedidoDetalle);
        Task<bool> Insertar(PedidoDetalle pedidoDetalle);
        Task<bool> ActualizarDatos(PedidoDetalle pDetalle);
        Task<IEnumerable<PedidoDetalle>> ObtenerDetallePedidoPorMesaYPorIdPedido(int id, int idPedido);
        Task<bool> EliminarPedidoDetalle(int id);
    }
}
