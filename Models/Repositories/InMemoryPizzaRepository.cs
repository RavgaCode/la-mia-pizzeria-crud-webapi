using Azure;
using Microsoft.Extensions.Hosting;
using System.Runtime.Serialization;

namespace la_mia_pizzeria.Models.Repositories
{
   
    public class InMemoryPizzaRepository : IPizzeriaRepository
    {
        //public static Dictionary<int, string> IngredientList = new Dictionary<int, string>();
        
        //public static void GenerateIngredientList()
        //{
        //    IngredientList.Add(1, "Pomodoro");
        //    IngredientList.Add(2, "Mozzarella");
        //    IngredientList.Add(3, "Funghi");
        //    IngredientList.Add(4, "Prosciutto cotto");
        //    IngredientList.Add(5, "Prosciutto crudo");
        //    IngredientList.Add(6, "Bufala");
        //    IngredientList.Add(7, "Tonno");
        //}
        
        
        public static List<Pizza> Pizzas = new List<Pizza>();
        public List<Pizza> All()
        {
            return Pizzas;
        }

        public void Create(Pizza pizzaToCreate, List<int> SelectedIngredients)
        {
 
            pizzaToCreate.Id = Pizzas.Count;



            pizzaToCreate.Ingredients = new List<Ingredient>();

            IngredientsToPost(pizzaToCreate, SelectedIngredients);
    

            Pizzas.Add(pizzaToCreate);
        }

        public void Delete(Pizza pizzaToDelete)
        {
            Pizzas.Remove(pizzaToDelete);
        }

        public Pizza GetById(int id)
        {
            Pizza pizzaToSearch = Pizzas.Where(pizzaToSearch => pizzaToSearch.Id == id).FirstOrDefault();

            pizzaToSearch.Category = new Category() { Id = 1, Name = "Fake category" };

            return pizzaToSearch;
        }

        public void Update(Pizza pizzaToUpdate, Pizza formData, List<int>? SelectedIngredients)
        {
            pizzaToUpdate = formData;
            pizzaToUpdate.Category = new Category() { Id = 1, Name = "Fake cateogry" };

            pizzaToUpdate.Ingredients = new List<Ingredient>();

     

            IngredientsToPost(pizzaToUpdate, SelectedIngredients);
   
        }
        private static void IngredientsToPost(Pizza pizza, List<int> SelectedIngredients)
        {
            pizza.Category = new Category() { Id = 1, Name = "Fake cateogry" };

            foreach (int ingredientId in SelectedIngredients)
            {
                pizza.Ingredients.Add(new Ingredient() { Id = ingredientId, Title = "Fake ingredient title " + ingredientId });
            }
        }
    }
}
