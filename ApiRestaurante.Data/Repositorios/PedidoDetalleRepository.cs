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

        public Task<PedidoDetalle> ObtenerDetallePedidoPorMesa(int id)
        {
            var db = dbConecction();
            var sql = @"SELECT pd.idPedido, pd.idProducto, pd.cantidad, pd.precio, pro.nombre, pd.subTotal, pe.fecha
                                    FROM
                                        pedido pe
                                    JOIN
                                        pedido_detalle pd ON pe.idPedido = pd.idPedido
                                    JOIN
                                        producto pro ON pd.idProducto = pro.idProducto
                                    JOIN
                                        mesa m ON pe.idMesa = m.idMesa
                                    WHERE
                                        pe.idMesa = @Id
                                        AND pe.cancelado = 0
                                        AND m.disponible = 0
                                    ORDER BY
                                        pd.horaPedido DESC; ";

            return db.QueryFirstOrDefaultAsync<PedidoDetalle>(sql, new { Id = id });
        }
    }
}
