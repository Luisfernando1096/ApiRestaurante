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
        public async Task<bool> InsertarPedido(Pedido pedido)
        {
            var db = dbConecction();
            var sql = @"INSERT INTO pedido(idMesa, idCuenta, cancelado, fecha, listo, total, descuento, iva, propina, totalPago, saldo, nFactura, anular, efectivo, credito, btc) VALUES(@idMesa, @idCuenta, @cancelado, @fecha, @listo, @total, @descuento, @iva, @propina, @totalPago, @saldo, @nFactura, @anular, @efectivo, @credito, @btc)";
            var result = await db.ExecuteAsync(sql, new {pedido.IdMesa, pedido.IdCuenta, pedido.Cancelado, pedido.Fecha,pedido.Listo,pedido.Total, pedido.Descuento, pedido.Iva, pedido.Propina, pedido.TotalPago,pedido.Saldo,pedido.NFactura,pedido.Anular,pedido.Efectivo,pedido.Credito,pedido.Btc});

            return result > 0;
        }
    }
}