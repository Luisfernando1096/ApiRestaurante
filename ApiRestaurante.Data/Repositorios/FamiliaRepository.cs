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
    public class FamiliaRepository : IFamiliaRepository
    {
        private readonly MySqlConfiguration conectionString;
        public FamiliaRepository(MySqlConfiguration pConnectionString)
        {
            conectionString = pConnectionString;
        }

        protected MySqlConnection dbConecction()
        {
            return new MySqlConnection(conectionString.ConnectionString);
        }

        public Task<IEnumerable<Familia>> ObtenerTodasLasFamilias()
        {
            var db = dbConecction();
            var sql = @"SELECT idFamilia, activo, familia as nombre, grupoPrinter FROM familia ORDER BY familia;";
            return db.QueryAsync<Familia>(sql, new { });
        }
    }
}
