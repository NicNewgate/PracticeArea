using ContosoPizza.Models;

namespace ContosoPizza.Services
{
    public class PizzaService
    {
        static List<Pizza> Pizzas { get; }
        static int nextId = 3;
        static PizzaService()
        {
            Pizzas = new List<Pizza>()
            {
                new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
                new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
            };
        }

        // Rufe alle Pizzas ab
        public static List<Pizza> GetAll() => Pizzas;
    
        // Rufe Pizza mit bestimmter id ab 
        public static Pizza? Get(int id) => Pizzas.FirstOrDefault(x => x.Id == id);

        // Füge Pizza hinzu
        public static void Add(Pizza pizza)
        {
            pizza.Id = nextId++;
            Pizzas.Add(pizza);
        }

        // Lösche Pizza mit bestimmter id
        public static void Delete(int id)
        {
            var pizza = Get(id);
            if (pizza is null)
                return;

            Pizzas.Remove(pizza);
        }

        // Aktualisiere daten einer bestimmten Pizza
        public static void Update(Pizza pizza)
        {
            var index = Pizzas.FindIndex(x =>  x.Id == pizza.Id);
            if (index == -1)
                return;

            Pizzas[index] = pizza;
        }
    }
}
