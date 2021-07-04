namespace PizzaStore.Domain.Models
{
    public class Size: PaidItem
    {
         public string SizeName { get; set; }

         public Size()
        {

        }

        public Size(string sizeName, double price)
        {
            SizeName = sizeName;
            Price=price;
        }
    }
}