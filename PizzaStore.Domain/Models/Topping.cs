namespace PizzaStore.Domain.Models
{
    public class Topping: PaidItem
    {
        public string TopName { get; set; }

        public Topping()
        {

        }

        public Topping(string topName, double price)
        {
            TopName = topName;
            Price=price;
        }
    }
}