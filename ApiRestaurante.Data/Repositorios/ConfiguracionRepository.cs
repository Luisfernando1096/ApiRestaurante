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
        public async Task<IEnumerable<Configuracion>> ObtenerConfiguracion()
        {
            using (var db = dbConecction())
            {
                await db.OpenAsync();
                var sql = @"SELECT * FROM configuracion WHERE idConfiguracion = 1;";
                return await db.QueryAsync<Configuracion>(sql, new
                {
                });
            }
        }
    }
}
