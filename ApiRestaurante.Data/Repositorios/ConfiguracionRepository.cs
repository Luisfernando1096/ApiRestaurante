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
    public class ConfiguracionRepository : IConfiguracionRepository
    {
        private readonly MySqlConfiguration conectionString;
        public ConfiguracionRepository(MySqlConfiguration pConnectionString)
        {
            conectionString = pConnectionString;
        }
        protected MySqlConnection dbConecction()
        {
            return new MySqlConnection(conectionString.ConnectionString);
        }
        public Task<IEnumerable<Configuracion>> ObtenerConfiguracion()
        {
            var db = dbConecction();
            var sql = @"SELECT * FROM configuracion;";
            return db.QueryAsync<Configuracion>(sql, new { });
        }
    }
}
