using System;
using PizzaStore.Domain.Models;

namespace PizzaStore.Client
{
    public class MenuManager
    {
        public int currentMenu;

        public MenuManager()
        {
            currentMenu = 0;
        }


        public void DisplayEntryText()
        {
            System.Console.WriteLine("Welcome to Dev's Pizza App");
            System.Console.WriteLine("Please choose Login, or Register now!");
            System.Console.WriteLine("1: Login");
            System.Console.WriteLine("2: Register");
            System.Console.WriteLine("3: [ADMIN] TERMINATE PROGRAM");
        }

        public string DisplayEntryTextT()
        {
            System.Console.WriteLine("Welcome to Dev's Pizza App");
            System.Console.WriteLine("Please choose Login, or Register now!");
            System.Console.WriteLine("1: Login");
            System.Console.WriteLine("2: Register");
            System.Console.WriteLine("3: [ADMIN] TERMINATE PROGRAM");
            return "true";
        }

        public void DisplayLoginMenu()
        {
            System.Console.WriteLine("LOGIN");
            System.Console.WriteLine("Please Enter Username");
            System.Console.WriteLine("1: Register");
            System.Console.WriteLine("2: Return");
        }

        public void DisplayRegisterMenu()
        {
            System.Console.WriteLine("REGISTER");
            System.Console.WriteLine("Please Enter Username");
            System.Console.WriteLine("1: Login");
            System.Console.WriteLine("2: Return");
        }

        public void DisplayChooseLocationMenu()
        {
            System.Console.WriteLine("CHOOSE LOCATION");
            System.Console.WriteLine("Please select a location");
            System.Console.WriteLine("1: Dev's Pizza - Downtown");
            System.Console.WriteLine("2: Dev's Pizza - Westside");
            System.Console.WriteLine("3: Logout");
        }

        public void DisplayMainMenu()
        {
            System.Console.WriteLine("MAIN MENU");
            System.Console.WriteLine("Please make a selection");
            System.Console.WriteLine("---OUR POPULAR ITEMS---");
            System.Console.WriteLine("1: Custom Pizza");
            System.Console.WriteLine("2: Cheese Pizza");
            System.Console.WriteLine("3: Pepperoni Pizza");
            System.Console.WriteLine("4: Hawaiian Pizza");
            System.Console.WriteLine("5: Buffalo Chicken Pizza");
            System.Console.WriteLine("------------------------");
            System.Console.WriteLine("6: Display Cart");
            System.Console.WriteLine("7: Edit/Remove Items In Cart");
            System.Console.WriteLine("8: Checkout");
            System.Console.WriteLine("9: Profile Settings");
            System.Console.WriteLine("10: Logout");

        }

        public void DisplaySelectEditRemovePizzaMenu(Order currentOrder)
        {
            int iteration = 0;

            if (currentOrder.Pizzas.Count == 0)
            {
                System.Console.WriteLine("Your cart is empty");
            }
            else
            {
                foreach (Pizza pizza in currentOrder.Pizzas)
                {
                    iteration += 1;
                    Console.WriteLine($"{iteration}: Edit/Remove {pizza.ToString()}");
                }
                System.Console.WriteLine($"Total: ${currentOrder.GetTotalPrice()}");
            }
            Console.WriteLine($"{iteration + 1}: Return to Main Menu");
        }

        public void DisplayEditRemovePizzaMenu(Pizza pizza)
        {
            System.Console.WriteLine($"SELECTED {pizza.ToString()}");
            System.Console.WriteLine("1: Edit");
            System.Console.WriteLine("2: Remove");
            System.Console.WriteLine("3: Return to Select");
        }

        public void DisplayCustomizePizzaMenu(Pizza pizza)
        {
            System.Console.WriteLine($"{pizza.ToString()}");
            System.Console.WriteLine("1: Edit Size");
            System.Console.WriteLine("2: Edit Crust");
            System.Console.WriteLine("3: Edit Sauce");
            System.Console.WriteLine("4: Edit Cheese");
            System.Console.WriteLine("5: Edit Toppings");
            System.Console.WriteLine("6: Add to Order");
            System.Console.WriteLine("7: Cancel and Return to Menu");
        }

        public void DisplayCheckoutMenu(Order order)
        {
            System.Console.WriteLine($"Your order is \n{order.ToString()}");
            System.Console.WriteLine("1: Place Order");
            System.Console.WriteLine("2: Return to Main Menu");
        }

        public void DisplayOrderConfirmedMenu(Name username)
        {
            System.Console.WriteLine($"Order confirmed for {username.IdName}");
            System.Console.WriteLine("1: Start another Order");
            System.Console.WriteLine("2: Logout");
        }

        public void DisplayStoreMainMenu()
        {
            System.Console.WriteLine("MAIN MENU");
            System.Console.WriteLine("1: Display Orders");
            System.Console.WriteLine("2: Display Sales");
            System.Console.WriteLine("3: Logout");
        }

        public void DisplayEditPizzaSizeMenu()
        {
            System.Console.WriteLine("CUSTOM PIZZA: EDIT SIZE");
            System.Console.WriteLine("1: Small");
            System.Console.WriteLine("2: Medium");
            System.Console.WriteLine("3: Large");
            System.Console.WriteLine("4: Return To Customize Menu");
        }

        public void DisplayEditPizzaCrusteMenu()
        {
            System.Console.WriteLine("CUSTOM PIZZA: EDIT CRUST");
            System.Console.WriteLine("1: Plain");
            System.Console.WriteLine("2: Deep Dish");
            System.Console.WriteLine("3: Stuffed");
            System.Console.WriteLine("4: Return To Customize Menu");
        }

        public void DisplayEditPizzaSauceeMenu()
        {
            System.Console.WriteLine("CUSTOM PIZZA: EDIT SAUCE");
            System.Console.WriteLine("1: Marinara");
            System.Console.WriteLine("2: Alfredo");
            System.Console.WriteLine("3: Ranch");
            System.Console.WriteLine("4: Return To Customize Menu");
        }
        public void DisplayEditPizzaCheeseMenu()
        {
            System.Console.WriteLine("CUSTOM PIZZA: EDIT CHEESE");
            System.Console.WriteLine("1: No Cheese");
            System.Console.WriteLine("2: Regular Cheese");
            System.Console.WriteLine("3: Extra Cheese");
            System.Console.WriteLine("4: Return To Customize Menu");
        }

        public void DisplayEditPizzaToppingsMenu(Pizza pizza)
        {
            System.Console.WriteLine("CUSTOM PIZZA: EDIT TOPPINGS");
            //list toppings currently on pizza and select add or remove/edit
            string addRemove = (pizza.CheckHasTopping("Pepperoni")) ? "Remove" : "Add";
            System.Console.WriteLine($"1:{addRemove} Pepperoni");
            addRemove = (pizza.CheckHasTopping("Ham")) ? "Remove" : "Add";
            System.Console.WriteLine($"2:{addRemove} Ham");
            addRemove = (pizza.CheckHasTopping("Chicken")) ? "Remove" : "Add";
            System.Console.WriteLine($"3:{addRemove} Chicken");
            addRemove = (pizza.CheckHasTopping("Pineapple")) ? "Remove" : "Add";
            System.Console.WriteLine($"4:{addRemove} Pineapple");
            addRemove = (pizza.CheckHasTopping("Buffalo hot Sauce")) ? "Remove" : "Add";
            System.Console.WriteLine($"5:{addRemove} Buffalo hot Sauce");
            System.Console.WriteLine("6: Return To Customize Menu");
        }

    }
}