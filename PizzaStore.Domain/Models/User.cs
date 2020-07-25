using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
    public class User
    {
        public List<Order> Orders { get; set; }
        public Name Name { get; set; }
        public Store ChosenStore { get; set; }

        public User(string userDisplay, string userID)
        {
            Orders = new List<Order>();
            Name = new Name(userDisplay, userID);
        }


    }
}