using ApiRestaurante.Model.CLS;
using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
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
            using (var db = dbConecction())
            {
                await db.OpenAsync();
                var sql = @"UPDATE salon SET nombre = @Nombre, fondo = @Fondo, nMesas = @NMesas WHERE idSalon = @IdSalon";
                var result = await db.ExecuteAsync(sql, new { salon.Nombre, salon.Fondo, salon.NMesas, salon.IdSalon });
                return result > 0;
            }
        }

        public async Task<bool> EliminarSalon(Salon salon)
        {
            using (var db = dbConecction())
            {
                await db.OpenAsync();
                var sql = @"DELETE FROM salon WHERE idSalon = @Id;";
                var result = await db.ExecuteAsync(sql, new { Id = salon.IdSalon });
                return result > 0;
            }
        }

        public async Task<bool> InsertarSalon(Salon salon)
        {
            using (var db = dbConecction())
            {
                await db.OpenAsync();
                var sql = @"INSERT INTO salon(nombre, fondo, nMesas) VALUES (@Nombre, @Fondo, @NMesas)";
                var result = await db.ExecuteAsync(sql, new { salon.Nombre, salon.Fondo, salon.NMesas });
                return result > 0;
            }
        }

        public async Task<Salon> ObtenerSalonPorId(int id)
        {
            using (var db = dbConecction())
            {
                await db.OpenAsync();
                var sql = @"SELECT * FROM salon WHERE idSalon = @Id;";
                return await db.QueryFirstOrDefaultAsync<Salon>(sql, new { Id = id });
            }
        }

        public async Task<IEnumerable<Salon>> ObtenerTodosLosSalones()
        {
            using (var db = dbConecction())
            {
                await db.OpenAsync();
                var sql = @"SELECT idSalon, nombre, fondo, nMesas FROM salon ORDER BY nombre;";
                return await db.QueryAsync<Salon>(sql);
            }
        }
    }
}
