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
        public IActionResult Search(string? name)
        {

            List<Pizza> pizzas = _pizzeriaRepository.SearchByName(name);

            return Ok(pizzas);

        }
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
           Pizza pizza = _pizzeriaRepository.GetById(id);

            return Ok(pizza);
        }
    }
}
