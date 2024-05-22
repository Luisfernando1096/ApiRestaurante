using ApiRestaurante.Model.CLS;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Data.Repositorios
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly MySqlConfiguration conectionString;
        public ProductoRepository(MySqlConfiguration pConnectionString)
        {
            conectionString = pConnectionString;
        }

        protected MySqlConnection dbConecction()
        {
            return new MySqlConnection(conectionString.ConnectionString);
        }

        public async Task<IEnumerable<Producto>> ObtenerProductoPorIdFamilia(int id)
        {
            using (var db = dbConecction())
            {
                await db.OpenAsync();
                var sql = @"SELECT p.idProducto, p.nombre, p.descripcion, p.precio, p.foto, p.costo, p.inventariable, p.conIngrediente, p.stock, p.stockMinimo, p.activo, s.idFamilia, s.familia, s.grupoPrinter
                FROM producto p, familia s
                WHERE p.idFamilia = s.idFamilia AND p.idFamilia = @Id AND p.activo = 1 ORDER BY p.nombre;";


                return await db.QueryAsync<Producto>(sql, new { Id = id });
            }
        }

        public async Task<Producto> ObtenerProductoPorId(int id)
        {
            using (var db = dbConecction())
            {
                await db.OpenAsync();
                var sql = @"SELECT p.idProducto, p.nombre, p.descripcion, p.precio, p.costo, p.foto, p.inventariable, p.conIngrediente, p.stock, p.stockMinimo, p.activo, s.idFamilia, s.familia, s.grupoPrinter FROM producto p, familia s
                        WHERE p.idFamilia = s.idFamilia AND idProducto = @Id;";
                return await db.QueryFirstOrDefaultAsync<Producto>(sql, new
                {
                    Id = id
                });
            }
        }

        public async Task<bool> actualizarstock(Producto producto)
        {
            using (var db = dbConecction()) {
                await db.OpenAsync();
                var sql = @"UPDATE producto SET stock = @Stock " +
                    "WHERE idProducto = @IdProducto;";
                var result = await db.ExecuteAsync(sql, new { producto.Stock, producto.IdProducto});

                return result > 0;
            }
        }
        public async Task<byte[]> ObtenerImagen(string nombreImagen)
        {
            var rutaDeImagen = Path.Combine(@"C:\inetpub\wwwroot\IISArchivos\Imagenes", nombreImagen);

            if (!File.Exists(rutaDeImagen))
            {
                // Manejar el caso en el que la imagen no existe
                return null; // o lanza una excepción o maneja de otra manera
            }

            byte[] imagenBytes;
            using (var fileStream = new FileStream(rutaDeImagen, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
            {
                imagenBytes = new byte[fileStream.Length];
                await fileStream.ReadAsync(imagenBytes, 0, imagenBytes.Length);
            }

            return imagenBytes;
        }

    }
}
