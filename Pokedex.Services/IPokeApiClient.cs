using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Models;

namespace Pokedex.Services
{
    public interface IPokeApiClient
    {
        Task<IEnumerable<Pokemon>> GetAllPokemons();
        Task<Pokemon> GetPokemon(string name);
    }
}
