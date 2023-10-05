using ApiRestaurante.Model.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Data.Repositorios
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> ObtenerProductoPorIdFamilia(int id);
        Task<Producto> ObtenerProductoPorId(int id);
    }
}
