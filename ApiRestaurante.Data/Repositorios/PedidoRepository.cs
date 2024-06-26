﻿using ApiRestaurante.Model.CLS;
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
            
            using (var db = dbConecction()){
                await db.OpenAsync();
                var sql = @"INSERT INTO pedido(idMesa, idCliente, cancelado, fecha, listo, total, descuento, iva, propina, totalPago, saldo, nFactura, anular, efectivo, credito, btc, exento) VALUES(@IdMesa, @IdCliente, @Cancelado, @Fecha, @Listo, @Total, @Descuento, @Iva, @Propina, @TotalPago, @Saldo, @NFactura, @Anular, @Efectivo, @Credito, @Btc, @Exento); SELECT LAST_INSERT_ID();";
                var lastInsertedId = await db.ExecuteScalarAsync<int>(sql, new { pedido.IdMesa, pedido.IdCliente, pedido.Cancelado, pedido.Fecha, pedido.Listo, pedido.Total, pedido.Descuento, pedido.Iva, pedido.Propina, pedido.TotalPago, pedido.Saldo, pedido.NFactura, pedido.Anular, pedido.Efectivo, pedido.Credito, pedido.Btc, pedido.Exento });

                return lastInsertedId;
            }
        }

        public async Task<bool> ActualizarTotal(Pedido pedido)
        {
            using (var db = dbConecction())
            {
                await db.OpenAsync();
                var sql = @"UPDATE pedido SET total = @Total " +
                    "WHERE idMesa = @IdMesa AND idPedido=@IdPedido;";
                var result = await db.ExecuteAsync(sql, new { pedido.Total, pedido.IdMesa, pedido.IdPedido });

                return result > 0;
            }
                
        }

        public async Task<Pedido> ObtenerUltimoPedido()
        {
            using (var db = dbConecction())
            {
                await db.OpenAsync();
                var sql = @"SELECT idPedido FROM pedido order by idPedido desc limit 1;";
                return await db.QueryFirstOrDefaultAsync<Pedido>(sql, new { });
            }
                
            
        }

        public async Task<IEnumerable<int>> ObtenerPedidosEnMesa(int idMesa)
        {
            using (var db = dbConecction()){
                await db.OpenAsync();
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
                return await db.QueryAsync<int>(sql, new { IdMesa = idMesa });
            }
        }
        public async Task<IEnumerable<int>> ObtenerPedidos(int idMesa)
        {
            using (var db = dbConecction()){
                await db.OpenAsync();
                var sql = @"SELECT
                                pe.idPedido,
                                            pe.idMesa
                                        FROM
                                            pedido pe
                                        JOIN
                                            mesa m ON pe.idMesa = m.idMesa
                                        WHERE
                                pe.idMesa = @IdMesa
                                AND pe.cancelado = 0
                                AND m.disponible = 0
                            GROUP BY
                                pe.idPedido;";
                return await db.QueryAsync<int>(sql, new { IdMesa = idMesa });
            }
            
        }

        public async Task<bool> ActualizarMesa(Pedido pedido)
        {
            using (var db = dbConecction())
            {
                await db.OpenAsync();
                var sql = @"UPDATE pedido SET idMesa = @IdMesa " +
                        "WHERE idPedido = @IdPedido ;";
                var result = await db.ExecuteAsync(sql, new { pedido.IdMesa, pedido.IdPedido });

                return result > 0;
            }
                
        }

        public async Task<bool> ActualizarCliente(Pedido pedido)
        {
            using (var db = dbConecction())
            {
                await db.OpenAsync();
                var sql = @"UPDATE pedido SET idCliente = @IdCliente " + "WHERE idPedido = @IdPedido ;";
                var result = await db.ExecuteAsync(sql, new
                {
                    pedido.IdCliente,
                    pedido.IdPedido
                });
                return result > 0;
            }
        }

        public async Task<bool> ActualizarMesero(Pedido pedido)
        {
            using (var db = dbConecction())
            {
                await db.OpenAsync();
                var sql = @"UPDATE pedido SET idMesero = @IdMesero " + "WHERE idPedido = @IdPedido ;";
                var result = await db.ExecuteAsync(sql, new
                {
                    pedido.IdMesero,
                    pedido.IdPedido
                });
                return result > 0;
            }
        }

        public async Task<Pedido> ObtenerPedidoPorId(int idPedido)
        {
            using (var db = dbConecction())
            {
                await db.OpenAsync();
                var sql = @"SELECT p.idPedido, p.idCliente, c.nombre, m.nombre as mesa, p.idMesero, e.nombres, p.fecha, p.iva, p.descuento, p.propina,
                                p.totalPago
                            FROM pedido p
                            LEFT JOIN cliente c ON p.idCliente = c.idCliente
                            LEFT JOIN empleado e ON e.idEmpleado = p.idMesero
                            JOIN mesa m ON p.idMesa = m.idMesa
                            WHERE p.idPedido = @IdPedido ;";
                return await db.QueryFirstOrDefaultAsync<Pedido>(sql, new { IdPedido = idPedido });
            }
                
        }
        public async Task<bool> EliminarPedido(int id)
        {
            using (var db = dbConecction())
            {
                await db.OpenAsync();
                var sql = @"DELETE FROM pedido WHERE idPedido = @Id;";
                var result = await db.ExecuteAsync(sql, new
                {
                    Id = id
                });
                return result > 0;
            }
        }
    }
}
