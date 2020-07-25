using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Domain.Models
{
    public class Order
    {
        public List<Pizza> Pizzas { get; set; }

        public DateTime timeOrdered;

        public Order()
        {
            Pizzas = new List<Pizza>();
        }

        public void CreatePizza()
        {
            Pizzas.Add(new Pizza());
        }

        public void CreatePizza(string name, List<Topping> toppings, Crust crust, Size size, double basePrice)
        {
            if (Pizzas.Count < 50)
            {
                Pizza newPizz = new Pizza(name, toppings, crust, size, basePrice);
                if (GetTotalPrice() + newPizz.GetTotalPrice() < 250)
                {
                    Pizzas.Add(newPizz);
                }

            }
        }

        public void RemovePizza(int input)
        {
            Pizzas.RemoveAt(input);
        }

        public override string ToString()
        {
            if (Pizzas.Count == 0)
            {
                return "Your cart is Empty";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                int iteration = 0;
                foreach (Pizza pizza in Pizzas)
                {
                    iteration += 1;
                    sb.Append($"{iteration}: {pizza.ToString()}\n");
                }
                sb.Append($"Total: ${GetTotalPrice()}\n");
                return sb.ToString();
            }
        }

        public double GetTotalPrice()
        {
            double totalPrice = 0;
            foreach (Pizza pizza in Pizzas)
            {
                totalPrice += pizza.GetTotalPrice();
            }
            return totalPrice;
        }


    }
}