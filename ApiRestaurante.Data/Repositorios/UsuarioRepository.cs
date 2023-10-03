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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MySqlConfiguration conectionString;
        public UsuarioRepository(MySqlConfiguration pConnectionString)
        {
            conectionString = pConnectionString;
        }

        protected MySqlConnection dbConecction()
        {
            return new MySqlConnection(conectionString.ConnectionString);
        }
        public Task<Usuario> InicioDeSesion(int id)
        {
            var db = dbConecction();
            var sql = @"SELECT r.idRol, r.rol, u.idUsuario, e.idEmpleado, e.nombres as username
                        FROM rol r, usuario u, empleado e
                        WHERE u.idRol=r.idRol AND u.pinCode=MD5(@Id) AND u.idUsuario=e.idEmpleado;";
            return db.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = id });
        }
    }
}
