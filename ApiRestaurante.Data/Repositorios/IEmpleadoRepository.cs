using ApiRestaurante.Model.CLS;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRestaurante.Data.Repositorios
{
    public interface IEmpleadoRepository
    {
        Task<IEnumerable<Empleado>> ObtenerEmpleados();
    }
}