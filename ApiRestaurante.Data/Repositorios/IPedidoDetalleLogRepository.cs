using ApiRestaurante.Model.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Data.Repositorios
{
    public interface IPedidoDetalleLogRepository
    {
        Task<PedidoDetalleLog> ObtenerPedidoEliminado(int idDetalle);
        Task<bool> InsertarPedidoDetalleLog(PedidoDetalleLog pDetalle);
        Task<bool> ActualizarPedidoDetalleLog(PedidoDetalleLog pDetalle);
    }
}
