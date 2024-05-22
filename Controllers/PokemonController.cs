using Microsoft.AspNetCore.Mvc;
using PokemonMVC.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace PREFINAL_ASSIGNMENT_TWO_POKEMON_VALDEZ_KATEASHLEY_BSIT_32E1.Controllers


{
    public class PokemonController : Controller
    {
        private readonly HttpClient _httpClient;

        public PokemonController()
        {
            _httpClient = new HttpClient { BaseAddress = new System.Uri("https://pokeapi.co/api/v2/") };
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var response = await _httpClient.GetStringAsync($"pokemon?offset={(page - 1) * 20}&limit=20");
            var pokemonList = JObject.Parse(response)["results"].ToObject<List<PokemonListItem>>();

            ViewBag.Page = page;
            return View(pokemonList);
        }

        public async Task<IActionResult> Details(string name)
        {
            var response = await _httpClient.GetStringAsync($"pokemon/{name}");
            var json = JObject.Parse(response);

            var pokemon = new Pokemon
            {
                Name = json["name"].ToString(),
                Moves = json["moves"].Select(m => m["move"]["name"].ToString()).ToList(),
                Abilities = json["abilities"].Select(a => a["ability"]["name"].ToString()).ToList()
            };

            return View(pokemon);
        }
    }

    public class PokemonListItem
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
