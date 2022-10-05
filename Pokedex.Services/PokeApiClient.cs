using Newtonsoft.Json;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pokedex.Services
{
    public class PokeApiClient : IPokeApiClient
    {
        private readonly HttpClient _httpClient;
        public PokeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Pokemon>> GetAllPokemons()
        {
            var pokeonList = JsonConvert.DeserializeObject<ResultObject>(
            await _httpClient.GetStringAsync($"pokemon?limit=25&offset=25"));

            var resultList = new List<Pokemon>();

            foreach (var pokemon in pokeonList.Pokemons)
                resultList.Add(await GetPokemon(pokemon.Name));

            return resultList;
                
        }

        public async Task<Pokemon> GetPokemon(string name)
        {
            return JsonConvert.DeserializeObject<Pokemon>(await _httpClient.GetStringAsync($"pokemon/{name}"));
        }

    }
}
