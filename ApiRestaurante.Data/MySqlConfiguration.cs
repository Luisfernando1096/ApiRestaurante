using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Data
{
        public class MySqlConfiguration
    {
        public MySqlConfiguration(string cadena) => ConnectionString = cadena;


        public string ConnectionString { get; set; }
    }
}
