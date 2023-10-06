using ApiRestaurante.Model.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Data.Repositorios
{
    public interface IPedidoRepository
    {
        Task<bool> InsertarPedido(Pedido pedido);
        Task<bool> ActualizarTotal(Pedido pedido);
        Task<Pedido> ObtenerUltimoPedido();
    }
}
