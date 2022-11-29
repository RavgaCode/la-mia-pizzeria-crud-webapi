using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria.Models;
using la_mia_pizzeria.Models.Repositories;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        IPizzeriaRepository _pizzeriaRepository;

        public PizzaController(IPizzeriaRepository pizzeriaRepository)
        {
            _pizzeriaRepository = pizzeriaRepository;
        }

        public IActionResult Test()
        {

            return Ok("test");

        }

        public IActionResult Get()
        {
            List<Pizza> pizzas = _pizzeriaRepository.All();
            return Ok(pizzas);

        }
        public IActionResult Search(string? title)
        {

            List<Pizza> pizzas = _pizzeriaRepository.SearchByTitle(title);

            return Ok(pizzas);

        }
    }
}
