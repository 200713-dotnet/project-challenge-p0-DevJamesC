using System.Collections.Generic;
using Xunit;
using model = PizzaStore.Domain.Models;

namespace PizzaStore.Testing
{
    public class CreateOrderCustomerPizzaRelationTest
    {
        [Fact]
        public void CreateOrderCustomerPizzaRelationT()
        {
            var sut = new PizzaStore.Storing.Repositories.OrderRepository();
            var user = new model.User("TestUser", "TestUser");
            var order = new model.Order();
            order.Pizzas = new List<model.Pizza>();
            order.CreatePizza(
                                        "Cheese",
                                        new List<Domain.Models.Topping>(){
                                        new Domain.Models.Topping("Marinara Sauce",0),
                                        new Domain.Models.Topping("Regular Cheese",0)
                                            },
                                            new Domain.Models.Crust("Plain", 0),
                                            new Domain.Models.Size("Large", 4),
                                            6);


            user.Orders.Add(order);
            //action
            bool passed = false;

            try
            {
                sut.CreateOrderCustomerPizzaRelation(user);
                passed = true;
            }
            catch
            {
                passed = false;
            }

            //assert

            Assert.True(passed);
        }
    }
}
