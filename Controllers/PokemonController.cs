using Microsoft.AspNetCore.Mvc;

namespace PREFINAL_ASSIGNMENT_TWO_POKEMON_VALDEZ_KATEASHLEY_BSIT_32E1.Controllers
{
    public class PokemonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
