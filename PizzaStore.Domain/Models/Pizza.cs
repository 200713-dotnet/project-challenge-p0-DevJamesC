
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Domain.Models
{
    public class Pizza : PaidItem
    {
        public List<Topping> Toppings { get; set; }

        public Crust Crust { get; set; }

        public Size Size { get; set; }

        public string Name { get; set; }

        public Pizza()
        {

        }

        public Pizza(string name, List<Topping> toppings, Crust crust, Size size, double price)
        {
            Name = name;
            Toppings = toppings;
            Crust = crust;
            Size = size;
            Price = price;
        }

        public Pizza(Pizza pizza)
        {
            Name = pizza.Name;
            Toppings= new List<Topping>();
            foreach (Topping top in pizza.Toppings)
            {
                Toppings.Add(top);
            }
            Crust = new Crust { CrustName = pizza.Crust.CrustName, Price = pizza.Crust.Price };
            Size = new Size { SizeName = pizza.Size.SizeName, Price = pizza.Size.Price };
            Price = pizza.Price;
        }

        public void AddTopping(Topping topping)
        {
            if (Toppings.Count < 5)
            {
                Toppings.Add(topping);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Topping top in Toppings)
            {
                sb.Append(top.TopName + ", ");
            }
            string topString = sb.ToString();

            topString.TrimEnd();
            topString.Remove(topString.Length - 2);


            return $"${GetTotalPrice()} ...... {Size.SizeName}, {Crust.CrustName} Crust {Name} Pizza with {topString}";


        }

        public double GetTotalPrice()
        {
            double totalPrice = Crust.Price + Size.Price + Price;
            foreach (Topping top in Toppings)
            {
                totalPrice += top.Price;
            }
            return totalPrice;
        }

        public bool CheckHasTopping(string topName)
        {
            foreach (Topping top in Toppings)
            {
                if (top.TopName == topName)
                {
                    return true;
                }
            }
            return false;
        }

        public void RemoveTopping(string topName)
        {
            Topping topping = null;
            foreach (Topping top in Toppings)
            {
                if (top.TopName == topName)
                {
                    topping = top;
                    break;
                }
            }

            Toppings.Remove(topping);
        }
    }
}