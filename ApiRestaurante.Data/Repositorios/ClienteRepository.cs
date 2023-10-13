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
    public class ClienteRepository : IClienteRepository
    {
        private readonly MySqlConfiguration conectionString;
        public ClienteRepository(MySqlConfiguration pConnectionString)
        {
            conectionString = pConnectionString;
        }

        protected MySqlConnection dbConecction()
        {
            return new MySqlConnection(conectionString.ConnectionString);
        }

        public Task<IEnumerable<Cliente>> ObtenerTodosLosClientes()
        {
            var db = dbConecction();
            var sql = @"SELECT * FROM cliente;";
            return db.QueryAsync<Cliente>(sql, new { });
        }
    }
}
