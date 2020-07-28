using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PizzaStore.Storing.Repositories
{
    public class OrderRepository
    {

        private PizzaStoreDbContext _db = new PizzaStoreDbContext();
        public void Create(PizzaStore.Domain.Models.Order order)//currently already added demo users
        {

        }

        public void CreateOrderCustomerPizzaRelation(PizzaStore.Domain.Models.User user)
        {//create an order, attach it to a user (customerOrderCustomer). make pizza, attach it to order (customerOrderPizza)
            var newCustomerOrderCustomer = new FkCustomerOrderCustomer();

            var newOrder = new CustomerOrder();

            int custID = 0;
            foreach (var item in _db.Name.ToList())//Will only work if the name of user is already in database
            {
                if (user.Name.TextName == item.NameText)
                {
                    custID = item.NameId;
                }
            }
            newCustomerOrderCustomer.Customer = new Customer() { NameId = custID };//linking user and order through customerOrderCustomer
            newCustomerOrderCustomer.CustomerOrder = newOrder;


            newOrder.OrderedFrom = user.ChosenStore.Name.TextName;
            newOrder.TotalPrice = (decimal)user.Orders[user.Orders.Count - 1].GetTotalPrice();

            var pizzaRepo = new PizzaRepository();
            foreach (var pizza in user.Orders[user.Orders.Count - 1].Pizzas)//linking pizza and order through customerOrderPizza
            {
                var newCustomerOrderPizza = new FkCustomerOrderPizza();
                newCustomerOrderPizza.CustomerOrder = newOrder;
                newCustomerOrderPizza.Pizza = pizzaRepo.Create(pizza);

                foreach (var top in pizza.Toppings)
                {
                    //make a new entry in fktoppingspizza to link each pizza and topping 

                    foreach (var t in _db.Topping.ToList())
                    {
                        if (t.Name == top.TopName)//requires toppings to be in database //db.Toppings.FirstOrDefault(c=c.Name==pizza.Crust.Name)
                        {
                            var topPizza = new PizzaStore.Storing.FkPizzaToppingId();
                            topPizza.Pizza = newCustomerOrderPizza.Pizza;
                            topPizza.Topping = t;
                            _db.FkPizzaToppingId.Add(topPizza);
                        }
                    }
                }

                _db.Pizza.Add(newCustomerOrderPizza.Pizza);
                _db.FkCustomerOrderPizza.Add(newCustomerOrderPizza);
            }

            _db.FkCustomerOrderCustomer.Add(newCustomerOrderCustomer);
            _db.CustomerOrder.Add(newOrder);

            _db.SaveChanges();
        }

        public string ReadOrderData()
        {
            var sb = new StringBuilder();

            /**  //works, but should not be used. The LINQ equivilent is below
            foreach (var order in _db.CustomerOrder.ToList())
            {
                foreach (var orderUserFK in _db.FkCustomerOrderCustomer.ToList())
                {
                    if (orderUserFK.CustomerOrderId == order.CustomerOrderId)//find order in the order-user table
                    {
                        foreach (var user in _db.Customer.ToList())
                        {
                            if (user.CustomerId == orderUserFK.CustomerId)//find user in the order-user table
                            {
                                foreach (var name in _db.Name.ToList())
                                {
                                    if (user.NameId == name.NameId)//find user name in name table
                                    {
                                        sb.Append($"User: {name.NameText}, From: {order.OrderedFrom}, Total: ${Math.Truncate(order.TotalPrice*100)/100} \n");

                                        foreach (var orderPizzaFK in _db.FkCustomerOrderPizza.ToList())
                                        {
                                            if (orderPizzaFK.CustomerOrderId == order.CustomerOrderId)//finding the order on the order-pizza table
                                            {
                                                foreach (var pizza in _db.Pizza.ToList())
                                                {
                                                    if (pizza.PizzaId == orderPizzaFK.PizzaId)//finding the pizza in the order pizza table
                                                    {
                                                        sb.Append($"           Pizza: {pizza.Name} \n");
                                                    }

                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }**/

            var query = from o in _db.CustomerOrder
                        join co in _db.FkCustomerOrderCustomer on o.CustomerOrderId equals co.CustomerOrderId  //link orders and orderUsers
                        join c in _db.Customer on co.CustomerId equals c.CustomerId //link orderUsers and users
                        join n in _db.Name on c.NameId equals n.NameId //link users and names
                        select new
                        {
                            orderID = o.CustomerOrderId,
                            Username = n.NameText,
                            TotalPrice = o.TotalPrice,
                            OrderedFrom = o.OrderedFrom
                        };

            foreach (var item in query.ToList())
            {
                sb.Append($"User: {item.Username}, From: {item.OrderedFrom}, Total: ${Math.Truncate(item.TotalPrice * 100) / 100} \n");

                var pizzas = from o in _db.CustomerOrder
                             join po in _db.FkCustomerOrderPizza on o.CustomerOrderId equals po.CustomerOrderId //link orders and orderPizza
                             join p in _db.Pizza on po.PizzaId equals p.PizzaId
                             where o.CustomerOrderId == item.orderID
                             select new
                             {
                                 PizzaId = p.PizzaId,
                                 Name = p.Name
                             };

                foreach (var pizza in pizzas.ToList())
                {
                    var sb2 = new StringBuilder();

                    var tops = from p in _db.Pizza
                               join tp in _db.FkPizzaToppingId on p.PizzaId equals tp.PizzaId
                               join t in _db.Topping on tp.ToppingId equals t.ToppingId
                               where p.PizzaId == pizza.PizzaId
                               select new
                               {
                                   Name = t.Name
                               };//Entity framework is an ORM
                    int i = 0;
                    foreach (var top in tops.ToList())
                    {
                        sb2.Append($"{top.Name},");
                        i += 1;
                    } //There is an issue displaying or adding the toppings, therefore we are not going to attempt to dispay them

                   // if (i > 0)
                   // {
                   //     sb.Append($"           Pizza: {pizza.Name} with {sb2.ToString()} \n");
                   // }
                   // else
                   // {
                        sb.Append($"           Pizza: {pizza.Name} \n");
                   // }
                }

            }

            return sb.ToString();

        }


    }
}