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
    public class SalonRepository : ISalonRepository
    {
        private readonly MySqlConfiguration conectionString;
        public SalonRepository(MySqlConfiguration pConnectionString)
        {
            conectionString = pConnectionString;
        }

        protected MySqlConnection dbConecction()
        {
            return new MySqlConnection(conectionString.ConnectionString);
        }
        public async Task<bool> ActualizarSalon(Salon salon)
        {
            var db = dbConecction();
            var sql = @"UPDATE salon SET nombre = @Nombre, fondo = @Fondo, nMesas = @NMesas WHERE idSalon = @IdSalon";
            var result = await db.ExecuteAsync(sql, new { salon.Nombre, salon.Fondo, salon.NMesas, salon.IdSalon});

            return result > 0;
        }

        public async Task<bool> EliminarSalon(Salon salon)
        {
            var db = dbConecction();
            var sql = @"DELETE FROM salon WHERE idSalon = @Id;";
            var result = await db.ExecuteAsync(sql, new { Id = salon.IdSalon });

            return result > 0;
        }

        public async Task<bool> InsertarSalon(Salon salon)
        {
            var db = dbConecction();
            var sql = @"INSERT INTO salon(nombre, fondo, nMesas) VALUES (@Nombre, @Fondo, @NMesas)";
            var result = await db.ExecuteAsync(sql, new { salon.Nombre, salon.Fondo, salon.NMesas });

            return result > 0;
        }

        public Task<Salon> ObtenerSalonPorId(int id)
        {
            var db = dbConecction();
            var sql = @"SELECT * FROM salon WHERE idSalon = @Id;";
            return db.QueryFirstOrDefaultAsync<Salon>(sql, new { Id = id });
        }

        public Task<IEnumerable<Salon>> ObtenerTodosLosSalones()
        {
            var db = dbConecction();
            var sql = @"SELECT idSalon, nombre, fondo, nMesas FROM salon ORDER BY nombre;";
            return db.QueryAsync<Salon>(sql, new { });
        }
    }
}
