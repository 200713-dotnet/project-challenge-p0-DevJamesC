using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PizzaStore.Storing.Repositories
{
    public class PizzaRepository
    {

        private PizzaStoreDbContext _db = new PizzaStoreDbContext();
        public PizzaStore.Storing.Pizza Create(PizzaStore.Domain.Models.Pizza pizza)
        {
            var newPizza = new PizzaStore.Storing.Pizza();
            newPizza.Crust = new Crust() { Name = pizza.Crust.CrustName, Price = (decimal)pizza.Crust.Price };
            newPizza.Size = new Size() { Name = pizza.Size.SizeName, Price = (decimal)pizza.Size.Price };
            newPizza.Name = pizza.Name;
            newPizza.Price = (decimal)pizza.Price;
            
            /**
                        foreach (var top in pizza.Toppings)
                        {
                            //make a new entry in fktoppingspizza to link each pizza and topping 

                            foreach (var t in _db.Topping.ToList())
                            {
                                if(t.Name==top.TopName)//requires toppings to be in database //db.Toppings.FirstOrDefault(c=c.Name==pizza.Crust.Name)
                                {
                                    var topPizza= new PizzaStore.Storing.FkPizzaToppingId();
                                    topPizza.Pizza=newPizza;
                                    topPizza.Topping=t;
                                    _db.FkPizzaToppingId.Add(topPizza);
                                }
                            }
                        }
            **/
           // _db.Pizza.Add(newPizza);
           // _db.SaveChanges();
            return newPizza;
        }

        public List<Domain.Models.Pizza> ReadAll()
        {
            var domainPizzaList = new List<Domain.Models.Pizza>();
            foreach (var item in _db.Pizza.ToList())
            {
                var tops = new List<PizzaStore.Domain.Models.Topping>();
                foreach (var topPizza in _db.FkPizzaToppingId.ToList())
                {
                    if (topPizza.PizzaId == item.PizzaId)
                    {
                        foreach (var top in _db.Topping.ToList())
                        {
                            if (top.ToppingId == topPizza.ToppingId)
                            {
                                tops.Add(new Domain.Models.Topping() { TopName = top.Name, Price = (double)top.Price });
                            }
                        }


                    }
                }
                //var pizzaWithCrust = _db.Pizza.Include(t = tops.Crust).Include(t = tops.Size);
               // var pizzasWithToppings = _db.FkPizzaToppingId.Include(t = tops.pizza).Include(t = tops.Topping);

                domainPizzaList.Add(new Domain.Models.Pizza(item.Name,
                    tops,
                    new Domain.Models.Crust { CrustName = item.Crust.Name },
                    new Domain.Models.Size { SizeName = item.Size.Name },
                    (double)item.Price
                )
                );
            }

            return domainPizzaList;
        }

        public void Update()
        {

        }

        public void Delete()
        {

        }
    }
}