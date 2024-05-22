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

        public async Task<IEnumerable<Cliente>> ObtenerTodosLosClientes()
        {
            using (var db = dbConecction())
            {
                await db.OpenAsync();
                var sql = @"SELECT * FROM cliente;";
                return await db.QueryAsync<Cliente>(sql, new{});
            }
        }

        public async Task<bool> InsertarCliente(Cliente cliente)
        {
            using (var db = dbConecction())
            {
                await db.OpenAsync();
                var sql = @"INSERT INTO cliente(nombre, direccion, email, telefono, NIT, regContable) VALUES(@Nombre, @Direccion, @Email, @Telefono, @NIT, @RegContable); ";
                var result = await db.ExecuteAsync(sql, new { cliente.Nombre, cliente.Direccion, cliente.Email, cliente.Telefono, cliente.NIT, cliente.RegContable});

                return result > 0;
            }
                
        }
    }
}
