namespace PizzaStore.Domain.Models
{
    public class Crust: PaidItem
    {
        public string CrustName { get; set; }

         public Crust()
        {

        }

        public Crust(string crustName, double price)
        {
            CrustName = crustName;
            Price=price;
        }
    }
}