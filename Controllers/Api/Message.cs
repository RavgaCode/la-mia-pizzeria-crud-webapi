using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria.Models;
using la_mia_pizzeria.Data;

namespace la_mia_pizzeria.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private PizzaDbContext db;

        public MessageController(PizzaDbContext _db)
        {
            db = _db;
        }
        [HttpPost]
        // public void Post(Message message) equivalente anche senza [FormBody]
        public IActionResult Create([FromBody] Message message)
        {

            try
            {
                db.Messages.Add(message);
                db.SaveChanges();

            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }

            return Ok(message);
        }
    }
}

