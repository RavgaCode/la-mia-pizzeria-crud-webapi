using la_mia_pizzeria.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.SqlServer.Server;

namespace la_mia_pizzeria.Models.Repositories
{
    public class DbPizzeriaRepository: IPizzeriaRepository
    {
        private PizzaDbContext db;

        public DbPizzeriaRepository()
        {
            db = new PizzaDbContext();
        }


        public List<Pizza> All()
        {
            return AllWithRelations();
        }
        public List<Pizza> AllWithRelations()
        {
            return db.Pizzas.Include(pizza => pizza.Category).Include(pizza => pizza.Ingredients).ToList();
        }
        public Pizza GetById(int id)
        {
            return db.Pizzas.Where(p => p.Id == id).Include("Category").Include("Ingredients").FirstOrDefault();
        }
        public void Create(Pizza pizzaToCreate, List<int> SelectedIngredients )
        {
            pizzaToCreate.Ingredients = new List<Ingredient>();

            foreach (int ingredientId in SelectedIngredients)
            {
                Ingredient ingredient = db.Ingredients.Where(ingredient => ingredient.Id == ingredientId).FirstOrDefault();
               pizzaToCreate.Ingredients.Add(ingredient);
            }

            db.Pizzas.Add(pizzaToCreate);
            db.SaveChanges();
        }
        public void Update(Pizza pizzaToUpdate, Pizza formData, List<int>?SelectedIngredients)
        {
            if (SelectedIngredients == null)
            {
                SelectedIngredients = new List<int>();
            }

            pizzaToUpdate.Name = formData.Name;
            pizzaToUpdate.Description = formData.Description;
            pizzaToUpdate.Image = formData.Image;
            pizzaToUpdate.CategoryID = formData.CategoryID;

            pizzaToUpdate.Ingredients.Clear();

           

            foreach (int ingredientId in SelectedIngredients)
            {
                Ingredient ingredient = db.Ingredients.Where(i => i.Id == ingredientId).FirstOrDefault();
                pizzaToUpdate.Ingredients.Add(ingredient);
            }

            db.SaveChanges();
        }
        public void Delete(Pizza pizzaToDelete)
        {

            db.Pizzas.Remove(pizzaToDelete);
            db.SaveChanges();
        }
        public List<Pizza> SearchByTitle(string? title)
        {

            IQueryable<Pizza> query = db.Pizzas.Include("Category").Include("Ingredients");

            if (title == null)
                return query.ToList();

            return query.Where(pizzaToSearch => pizzaToSearch.Name.ToLower().Contains(title.ToLower())).ToList();
        }
    }
}
