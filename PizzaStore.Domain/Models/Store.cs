using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
    public class Store
    {
        public List<Order> Orders { get; set; }
        public Name Name { get; set; }

        public Store()
        {

        }

        public Store(string displayName,string name)
        {
            Name = new Name(displayName,name);
            Orders = new List<Order>();
        }
        public Order CreateOrder()
        {
            return new Order();
        }
    }
}