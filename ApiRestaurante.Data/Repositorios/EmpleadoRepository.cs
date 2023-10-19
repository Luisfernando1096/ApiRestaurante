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
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly MySqlConfiguration conectionString;
        public EmpleadoRepository(MySqlConfiguration pConnectionString)
        {
            conectionString = pConnectionString;
        }

        protected MySqlConnection dbConecction()
        {
            return new MySqlConnection(conectionString.ConnectionString);
        }

        public Task<IEnumerable<Empleado>> ObtenerEmpleados()
        {
            var db = dbConecction();
            var sql = @"SELECT e.idEmpleado, e.nombres FROM empleado e, rol r, usuario u 
                      WHERE e.idEmpleado=u.idUsuario AND u.idRol=r.idRol AND r.idRol=2;";
            return db.QueryAsync<Empleado>(sql, new { });
        }
    }
}
