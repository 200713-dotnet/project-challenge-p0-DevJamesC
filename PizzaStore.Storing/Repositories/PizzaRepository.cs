using System.Collections.Generic;
using System.Linq;

namespace PizzaStore.Storing.Repositories
{
    public class PizzaRepository
    {

        private PizzaStoreDbContext _db = new PizzaStoreDbContext();
        public void Create(PizzaStore.Domain.Models.Pizza pizza)
        {
            var newPizza = new PizzaStore.Storing.Pizza();
            newPizza.Crust = new Crust() { Name = pizza.Crust.CrustName };
            newPizza.Size = new Size() { Name = pizza.Size.SizeName };
            newPizza.Name = pizza.Name;

            _db.Pizza.Add(newPizza);
            _db.SaveChanges();
        }
        /**
            public List<Domain.Models.Pizza> ReadAll()
            {
                var domainPizzaList = new List<Domain.Models.Pizza>();
                foreach (var item in _db.Pizza.ToList())
                {
                    domainPizzaList.Add(new Domain.Models.Pizza()
                    {new Domain.Models.Crust(){CrustName=item.Crust.Name}
                    }
                    
                    );
                }

                return _db.Pizza.ToList();
            }
        **/
        public void Update()
        {

        }

        public void Delete()
        {

        }
    }
}