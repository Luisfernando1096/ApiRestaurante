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
    public class IngredienteRepository : IIngredienteRepository
    {
        private readonly MySqlConfiguration conectionString;

        public IngredienteRepository(MySqlConfiguration pConnectionString)
        {
            conectionString = pConnectionString;
        }
        protected MySqlConnection dbConecction()
        {
            return new MySqlConnection(conectionString.ConnectionString);
        }

        public Task<IEnumerable<Ingrediente>> ingredientesdeproducto(int id)
        {
            var db = dbConecction();
            var sql = @"SELECT p.idProducto, i.idIngrediente, ip.cantidad, i.stock as stock_ingrediente, p.stock as stock_producto FROM ingrediente_producto ip, producto p, ingrediente i WHERE p.idProducto = ip.idProducto AND i.idIngrediente = ip.idIngrediente AND p.idProducto = @Id;";

            return db.QueryAsync<Ingrediente>(sql, new { Id = id });
        }

        public async Task<bool> actualizarstock(Ingrediente ingrediente)
        {
            var db = dbConecction();
            var sql = @"UPDATE ingrediente SET stock = @Stock_ingrediente " +
                "WHERE idIngrediente = @IdIngrediente;";
            var result = await db.ExecuteAsync(sql, new { ingrediente.Stock_ingrediente, ingrediente.IdIngrediente });

            return result > 0;
        }
    }
}
