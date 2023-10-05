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
    public class PedidoDetalleRepository : IPedidoDetalleRepository
    {
        private readonly MySqlConfiguration conectionString;
        public PedidoDetalleRepository(MySqlConfiguration pConnectionString)
        {
            conectionString = pConnectionString;
        }

        protected MySqlConnection dbConecction()
        {
            return new MySqlConnection(conectionString.ConnectionString);
        }

        public Task<IEnumerable<PedidoDetalle>> ObtenerDetallePedidoPorMesa(int id)
        {
            var db = dbConecction();
            var sql = @"SELECT pd.idPedido, pd.idProducto, pd.cantidad, pd.precio, pro.nombre, pd.subTotal, pe.fecha, f.grupoPrinter as grupo
                                    FROM
                                        pedido pe
                                    JOIN
                                        pedido_detalle pd ON pe.idPedido = pd.idPedido
                                    JOIN
                                        producto pro ON pd.idProducto = pro.idProducto
                                    JOIN
                                        mesa m ON pe.idMesa = m.idMesa
                                    JOIN
										familia f ON pro.idFamilia = f.idFamilia
                                    WHERE
                                        pe.idMesa = @Id
                                        AND pe.cancelado = 0
                                        AND m.disponible = 0
                                    ORDER BY
                                        pd.horaPedido DESC; ";

            return db.QueryAsync<PedidoDetalle>(sql, new { Id = id });
        }

        public async Task<bool> ActualizarCompra(PedidoDetalle pedidoDetalle)
        {
            var db = dbConecction();
            var sql = @"UPDATE pedido_detalle pd, pedido pe SET  pd.cantidad = @Cantidad, pd.subTotal = @SubTotal 
                            WHERE pe.idPedido=pd.idPedido AND pe.idPedido = @IdPedido AND pd.idProducto = @IdProducto;";
            var result = await db.ExecuteAsync(sql, new { pedidoDetalle.Cantidad, pedidoDetalle.SubTotal, pedidoDetalle.IdPedido, pedidoDetalle.IdProducto });

            return result > 0;
        }

        public async Task<bool> Insertar(PedidoDetalle pedidoDetalle)
        {
            var db = dbConecction();
            var sql = @"INSERT INTO pedido_detalle(cocinando, extras, horaEntregado, horaPedido, idProducto, idPedido, cantidad, precio, subTotal, grupo, usuario) VALUES(@Cocinando, @Extras, @HoraEntregado, @horaPedido, @IdProducto, @IdPedido, @Cantidad, @Precio, @SubTotal, @Grupo, @Usuario); ";
            var result = await db.ExecuteAsync(sql, new { pedidoDetalle.Cocinando, pedidoDetalle.Extras, pedidoDetalle.HoraEntregado, pedidoDetalle.HoraPedido, pedidoDetalle.IdProducto, pedidoDetalle.IdPedido, pedidoDetalle.Cantidad, pedidoDetalle.Precio, pedidoDetalle.SubTotal, pedidoDetalle.Grupo, pedidoDetalle.Usuario });

            return result > 0;
        }

        public async Task<bool> ActualizarDatos(PedidoDetalle pDetalle)
        {
            var db = dbConecction();
            var sql = @"UPDATE pedido_detalle SET cocinando = @Cocinando, extras = @Extras, horaEntregado= @HoraEntregado, horaPedido = @HoraPedido, idProducto = @IdProducto, idPedido = @IdPedido, cantidad = @Cantidad, precio = @Precio, subTotal = @SubTotal, grupo = @Grupo, usuario = @Usuario, fecha = @Fecha " +
                "WHERE idDetalle = @IdDetalle;";
            var result = await db.ExecuteAsync(sql, new { pDetalle.Cocinando, pDetalle.Extras, pDetalle.HoraEntregado, pDetalle.HoraPedido, pDetalle.IdProducto, pDetalle.IdPedido, pDetalle.Cantidad, pDetalle.Precio, pDetalle.SubTotal, pDetalle.Grupo, pDetalle.Usuario, pDetalle.Fecha, pDetalle.IdDetalle });

            return result > 0;
        }
    }
}
