using ApiRestaurante.Model.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Data.Repositorios
{
    public interface ISalonRepository
    {
        Task<IEnumerable<Salon>> ObtenerTodosLosSalones();
        Task<Salon> ObtenerSalonPorId(int id);
        Task<bool> InsertarSalon(Salon salon);
        Task<bool> ActualizarSalon(Salon salon);
        Task<bool> EliminarSalon(Salon salon);

    }
}
