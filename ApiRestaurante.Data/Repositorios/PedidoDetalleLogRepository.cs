using ApiRestaurante.Model.CLS;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Data.Repositorios
{
    public class PedidoDetalleLogRepository : IPedidoDetalleLogRepository
    {
        private readonly MySqlConfiguration conectionString;

        public PedidoDetalleLogRepository(MySqlConfiguration pConnectionString)
        {
            conectionString = pConnectionString;
        }

        protected MySqlConnection dbConecction()
        {
            return new MySqlConnection(conectionString.ConnectionString);
        }

        public async Task<PedidoDetalleLog> ObtenerPedidoEliminado(int idDetalle)
        {
            using (var db = dbConecction())
            {
                await db.OpenAsync();
                var sql = @"SELECT idDeleted, idDetalle, idPedido, cantidad, precio FROM pedido_detalle_log WHERE idDetalle = @IdDetalle;";
                return await db.QueryFirstOrDefaultAsync<PedidoDetalleLog>(sql, new { IdDetalle = idDetalle });
            }
                
        }

        public async Task<bool> InsertarPedidoDetalleLog(PedidoDetalleLog pDetalle)
        {
            using (var db = dbConecction())
            {
                await db.OpenAsync();
                var sql = @"INSERT INTO pedido_detalle_log(idDetalle, cocinando, horaEntregado, horaPedido, idProducto, idPedido, cantidad, precio, subTotal, usuarioDelete, fechaDelete) VALUES(@IdDetalle, @Cocinando, @HoraEntregado, @HoraPedido, @IdProducto, @IdPedido, @Cantidad, @Precio, @SubTotal, @UsuarioDelete, @FechaDelete);";
                var result = await db.ExecuteAsync(sql, new { pDetalle.IdDetalle, pDetalle.Cocinando, pDetalle.HoraEntregado, pDetalle.HoraPedido, pDetalle.IdProducto, pDetalle.IdPedido, pDetalle.Cantidad, pDetalle.Precio, pDetalle.SubTotal, pDetalle.UsuarioDelete, pDetalle.FechaDelete });

                return result > 0;
            }
                
        }

        public async Task<bool> ActualizarPedidoDetalleLog(PedidoDetalleLog pDetalle)
        {
            using (var db = dbConecction())
            {
                await db.OpenAsync();
                var sql = @"UPDATE pedido_detalle_log SET cantidad = @Cantidad, subTotal = @SubTotal, usuarioDelete = @UsuarioDelete, fechaDelete = @FechaDelete WHERE idDeleted = @IdDeleted;";
                var result = await db.ExecuteAsync(sql, new { pDetalle.Cantidad, pDetalle.SubTotal, pDetalle.UsuarioDelete, pDetalle.FechaDelete, pDetalle.IdDeleted });

                return result > 0;
            }
        }
    }
}
