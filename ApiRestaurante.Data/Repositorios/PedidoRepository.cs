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
    public class PedidoRepository : IPedidoRepository
    {
        private readonly MySqlConfiguration conectionString;

        public PedidoRepository(MySqlConfiguration pConnectionString) 
        {
            conectionString = pConnectionString;
        }
        protected MySqlConnection dbConecction()
        {
            return new MySqlConnection(conectionString.ConnectionString);
        }
        public async Task<int> InsertarPedido(Pedido pedido)
        {
            var db = dbConecction();
            var sql = @"INSERT INTO pedido(idMesa, idCuenta, cancelado, fecha, listo, total, descuento, iva, propina, totalPago, saldo, nFactura, anular, efectivo, credito, btc) VALUES(@IdMesa, @IdCuenta, @Cancelado, @Fecha, @Listo, @Total, @Descuento, @Iva, @Propina, @TotalPago, @Saldo, @NFactura, @Anular, @Efectivo, @Credito, @Btc); SELECT LAST_INSERT_ID();";
            var lastInsertedId = await db.ExecuteScalarAsync<int>(sql, new {pedido.IdMesa, pedido.IdCuenta, pedido.Cancelado, pedido.Fecha,pedido.Listo,pedido.Total, pedido.Descuento, pedido.Iva, pedido.Propina, pedido.TotalPago,pedido.Saldo,pedido.NFactura,pedido.Anular,pedido.Efectivo,pedido.Credito,pedido.Btc});

            return lastInsertedId;
        }

        public async Task<bool> ActualizarTotal(Pedido pedido)
        {
            var db = dbConecction();
            var sql = @"UPDATE pedido SET total = @Total " +
                "WHERE idMesa = @IdMesa AND idPedido=@IdPedido;";
            var result = await db.ExecuteAsync(sql, new { pedido.Total, pedido.IdMesa, pedido.IdPedido });

            return result > 0;
        }

        public Task<Pedido> ObtenerUltimoPedido()
        {
            var db = dbConecction();
            var sql = @"SELECT idPedido FROM pedido order by idPedido desc limit 1;";
            return db.QueryFirstOrDefaultAsync<Pedido>(sql, new { });
        }

        public Task<IEnumerable<int>> ObtenerPedidosEnMesa(int idMesa)
        {
            var db = dbConecction();
            var sql = @"SELECT
                            pd.idPedido
                        FROM
                            pedido pe
                        JOIN
                            pedido_detalle pd ON pe.idPedido = pd.idPedido
                        JOIN
                            producto pro ON pd.idProducto = pro.idProducto
                        JOIN
                            mesa m ON pe.idMesa = m.idMesa
                        WHERE
                            pe.idMesa = @IdMesa
                            AND pe.cancelado = 0
                            AND m.disponible = 0
                        GROUP BY
                            pd.idPedido;";
            return db.QueryAsync<int>(sql, new { IdMesa = idMesa});
        }
    }
}
