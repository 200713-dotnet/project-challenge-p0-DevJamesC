namespace PizzaStore.Domain.Models
{
    public class Name
    {
       public string TextName { get; set; }
       public string IdName {get; set;}

       public Name()
       {

       }

       public Name(string textName, string idName)
       {
           TextName= textName;
           IdName = idName;
       }
    }
}