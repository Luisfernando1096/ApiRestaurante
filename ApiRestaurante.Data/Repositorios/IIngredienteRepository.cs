using ApiRestaurante.Model.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Data.Repositorios
{
    public interface IIngredienteRepository
    {
        Task<IEnumerable<Ingrediente>> ingredientesdeproducto(int id);
        Task<bool> actualizarstock(Ingrediente ingrediente);
    }
}
