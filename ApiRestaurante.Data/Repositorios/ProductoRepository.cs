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
    public class ProductoRepository : IProductoRepository
    {
        private readonly MySqlConfiguration conectionString;
        public ProductoRepository(MySqlConfiguration pConnectionString)
        {
            conectionString = pConnectionString;
        }

        protected MySqlConnection dbConecction()
        {
            return new MySqlConnection(conectionString.ConnectionString);
        }

        public Task<IEnumerable<Producto>> ObtenerProductoPorIdFamilia(int id)
        {
            var db = dbConecction();
            var sql = @"SELECT p.idProducto, p.nombre, p.descripcion, p.precio, p.costo, p.inventariable, p.conIngrediente, p.stock, p.stockMinimo, p.activo, s.idFamilia, s.familia, s.grupoPrinter
            FROM producto p, familia s
            WHERE p.idFamilia = s.idFamilia AND p.idFamilia = @Id AND p.activo = 1;";

            return db.QueryAsync<Producto>(sql, new { Id = id });
        }
    }
}
