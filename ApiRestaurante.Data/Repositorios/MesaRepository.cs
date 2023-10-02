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
    public class MesaRepository : IMesaRepository
    {
        private readonly MySqlConfiguration conectionString;
        public MesaRepository(MySqlConfiguration pConnectionString)
        {
            conectionString = pConnectionString;
        }

        protected MySqlConnection dbConecction()
        {
            return new MySqlConnection(conectionString.ConnectionString);
        }
        public Task<IEnumerable<Mesa>> ObtenerMesasPorSalon(int id)
        {
            var db = dbConecction();
            var sql = @"SELECT m.idMesa, m.numero, m.nombre as nombre, m.capacidad, m.disponible, s.idSalon, s.nombre as salon FROM mesa m, salon s
                        WHERE m.idSalon=s.idSalon AND m.idSalon=@Id;";
            return db.QueryAsync<Mesa>(sql, new { Id = id });
        }
    }
}
