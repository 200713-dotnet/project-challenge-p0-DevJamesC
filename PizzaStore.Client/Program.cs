using System;
using System.Collections.Generic;
using System.Linq;
using PizzaStore.Domain.Models;
using PizzaStore.Storing;


namespace PizzaStore.Client
{
    //  menu index: Exit=-1 EntryMenu=0 Login=1 Register=2 SelectLocation=3 Main=4 SelectEdititem=5 EditRemoveItem=6 
    //   CustomPizzaBuilder=7 Checkout=8 OrderPlaced=9 UserProfileSettings=10 ShopMain=11 ShopChooseSales=12 PizzaEditSize=13 
    //   PizzaEditCrust=14 PizzaEditSauce=15 PizzaEditCheese=16 PizzaEditToppings=17
    public class Program
    {
        static void Main(string[] args)
        {
            RunApplication();
        }

        public static void RunApplication()
        {
            MenuManager menu = new MenuManager();
            bool terminateProgram = false;
            User currentUser = null;
            int currentEditRemoveIndex = 0;
            bool editingPizza = false;
            Domain.Models.Pizza CurrentCustomPizza = null;
            Domain.Models.Pizza CurrentCustomPizzaOld = null;
            do
            {
                int input = 0;
                //Entry menu
                while (menu.currentMenu == 0)
                {
                    menu.DisplayEntryText();
                    if (int.TryParse(Console.ReadLine(), out input))//if input passes as good input, then perform selected operation
                    {
                        switch (input)
                        {
                            case 1:
                                System.Console.WriteLine("To Login...");
                                menu.currentMenu = 1;
                                break;

                            case 2:
                                System.Console.WriteLine("To Register...");
                                menu.currentMenu = 2;
                                break;
                            case 3:
                                System.Console.WriteLine("Exiting...");
                                menu.currentMenu = -1;
                                terminateProgram = true;
                                break;


                            default:
                                System.Console.WriteLine("That is not an option");
                                break;
                        }
                        System.Console.WriteLine();
                    }
                }

                //Login menu
                while (menu.currentMenu == 1)
                {
                    menu.DisplayLoginMenu();

                    //logon function
                    string userName = Console.ReadLine();
                    if (int.TryParse(userName, out input))
                    {
                        switch (input)
                        {
                            case 1:
                                System.Console.WriteLine("To Register");
                                menu.currentMenu = 2;
                                break;

                            case 2:
                                System.Console.WriteLine("Returning...");
                                menu.currentMenu = 0;
                                break;

                            default:
                                System.Console.WriteLine("That is not an option");
                                break;
                        }
                    }
                    else
                    {
                        switch (userName)
                        {
                            case "User":
                                System.Console.WriteLine("Welcome User!");
                                currentUser = new User(userName, userName);//use sql to check and see if this user has set a "real" name
                                currentUser.Orders.Add(new Order());
                                menu.currentMenu = 3;
                                break;

                            case "Shop":
                                System.Console.WriteLine("Welcome Shop!");
                                menu.currentMenu = 3;
                                break;

                            default:
                                System.Console.WriteLine("Invalid Username");
                                break;

                        }
                    }
                    System.Console.WriteLine();
                }

                //Register menu
                while (menu.currentMenu == 2)
                {

                    menu.DisplayRegisterMenu();

                    //register function
                    string userName = Console.ReadLine();
                    if (int.TryParse(userName, out input))
                    {
                        switch (input)
                        {
                            case 1:
                                System.Console.WriteLine("To Login");
                                menu.currentMenu = 1;
                                break;

                            case 2:
                                System.Console.WriteLine("Returning...");
                                menu.currentMenu = 0;
                                break;

                            default:
                                System.Console.WriteLine("That is not a valid option");
                                break;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("You have Been Registered!");
                        menu.currentMenu = 1;
                    }
                    System.Console.WriteLine();
                }

                //SelectLocation menu
                while (menu.currentMenu == 3)
                {
                    menu.DisplayChooseLocationMenu();

                    if (int.TryParse(Console.ReadLine(), out input))
                    {
                        switch (input)
                        {
                            case 1:
                                Console.WriteLine("Selected Dev's Pizza - Downtown");
                                if (currentUser != null)
                                {
                                    currentUser.ChosenStore = new Store("Dev's Pizza - Downtown", "Store1");
                                    menu.currentMenu = 4;
                                }
                                else
                                {//if shop, go to ShopMainMenu instead
                                    menu.currentMenu = 11;
                                }
                                break;

                            case 2:
                                Console.WriteLine("Selected Dev's Pizza - Westside");
                                if (currentUser != null)
                                {
                                    currentUser.ChosenStore = new Store("Dev's Pizza - Westside", "Store2");
                                    menu.currentMenu = 4;
                                }
                                else
                                {//if shop, go to ShopMainMenu instead
                                    menu.currentMenu = 11;
                                }
                                break;

                            case 3:
                                Console.WriteLine("Logged Out");
                                menu.currentMenu = 0;
                                if (currentUser != null)
                                {
                                    currentUser = null;
                                }//if shop, destroy currentShopUser
                                break;

                            default:
                                System.Console.WriteLine("That is not an option");
                                break;
                        }
                    }
                }

                //MainMenu
                while (menu.currentMenu == 4)
                {
                    menu.DisplayMainMenu();

                    if (int.TryParse(Console.ReadLine(), out input))//if input passes as good input, then perform selected operation
                    {
                        switch (input)
                        {
                            case 1:
                                System.Console.WriteLine("Proceeding to Custom Pizza...");
                                menu.currentMenu = 7;
                                break;

                            case 2:
                                System.Console.WriteLine("Added Cheese Pizza");
                                currentUser.Orders[currentUser.Orders.Count - 1].CreatePizza(
                                    "Cheese",
                                    new List<Domain.Models.Topping>(){
                                        new Domain.Models.Topping("Marinara Sauce",0),
                                        new Domain.Models.Topping("Regular Cheese",0)
                                        },
                                        new Domain.Models.Crust("Plain", 0),
                                        new Domain.Models.Size("Large", 4),
                                        6);
                                break;

                            case 3:
                                System.Console.WriteLine("Added Pepperoni Pizza");
                                currentUser.Orders[currentUser.Orders.Count - 1].CreatePizza(
                                    "Pepperoni",
                                   new List<Domain.Models.Topping>(){
                                        new Domain.Models.Topping("Marinara Sauce",0),
                                        new Domain.Models.Topping("Regular Cheese",0),
                                        new Domain.Models.Topping("Pepperoni",1)
                                       },
                                       new Domain.Models.Crust("Plain", 0),
                                       new Domain.Models.Size("Large", 4),
                                       6);
                                break;

                            case 4:
                                System.Console.WriteLine("Added Hawaiian Pizza");
                                currentUser.Orders[currentUser.Orders.Count - 1].CreatePizza(
                                    "Hawaiian",
                                 new List<Domain.Models.Topping>(){
                                        new Domain.Models.Topping("Marinara Sauce",0),
                                        new Domain.Models.Topping("Regular Cheese",0),
                                        new Domain.Models.Topping("Pineapples",.75),
                                        new Domain.Models.Topping("Ham",1.25)
                                     },
                                     new Domain.Models.Crust("Plain", 0),
                                     new Domain.Models.Size("Large", 4),
                                     6);
                                break;

                            case 5:
                                System.Console.WriteLine("Added Buffalo Chicken Pizza");
                                currentUser.Orders[currentUser.Orders.Count - 1].CreatePizza(
                                    "Buffalo Chicken",
                                 new List<Domain.Models.Topping>(){
                                        new Domain.Models.Topping("Marinara Sauce",0),
                                        new Domain.Models.Topping("Regular Cheese",0),
                                        new Domain.Models.Topping("Chicken",2),
                                        new Domain.Models.Topping("Buffalo Hot Sauce",.25)
                                     },
                                     new Domain.Models.Crust("Plain", 0),
                                     new Domain.Models.Size("Large", 4),
                                     6);
                                break;

                            case 6:
                                System.Console.WriteLine("Displaying Cart...");
                                System.Console.WriteLine(currentUser.Orders[currentUser.Orders.Count - 1].ToString());
                                break;

                            case 7:
                                System.Console.WriteLine("Proceeding to Edit Items...");
                                menu.currentMenu = 5;
                                break;

                            case 8:
                                System.Console.WriteLine("Proceeding to Checkout...");
                                menu.currentMenu = 8;
                                break;

                            case 9:
                                System.Console.WriteLine("Proceeding to Profile Settings...");
                                break;

                            case 10:
                                System.Console.WriteLine("Logged out");
                                currentUser = null;
                                menu.currentMenu = 0;
                                break;

                            default:
                                System.Console.WriteLine("That is not an option");
                                break;
                        }
                        System.Console.WriteLine();
                    }
                }

                while (menu.currentMenu == 5)//Select item for Edit/Remove menu
                {

                    menu.DisplaySelectEditRemovePizzaMenu(currentUser.Orders[currentUser.Orders.Count - 1]);
                    if (int.TryParse(Console.ReadLine(), out input))//if input passes as good input, then perform selected operation
                    {
                        if (input > 0 && input < currentUser.Orders[currentUser.Orders.Count - 1].Pizzas.Count + 1)
                        {
                            currentEditRemoveIndex = input - 1;
                            menu.currentMenu = 6;

                        }
                        else if (input == currentUser.Orders[currentUser.Orders.Count - 1].Pizzas.Count + 1)
                        {
                            System.Console.WriteLine("Proceeding to Main Menu...");
                            menu.currentMenu = 4;
                        }
                        else
                        {
                            System.Console.WriteLine("That is not an option");
                        }
                    }
                }

                while (menu.currentMenu == 6) //edit/remove item menu
                {
                    menu.DisplayEditRemovePizzaMenu(currentUser.Orders[currentUser.Orders.Count - 1].Pizzas[currentEditRemoveIndex]);
                    if (int.TryParse(Console.ReadLine(), out input))//if input passes as good input, then perform selected operation
                    {
                        switch (input)
                        {
                            case 1:
                                Console.WriteLine("Proceeding to Edit Menu");
                                CurrentCustomPizza = currentUser.Orders[currentUser.Orders.Count - 1].Pizzas[currentEditRemoveIndex];
                                CurrentCustomPizzaOld = new PizzaStore.Domain.Models.Pizza(CurrentCustomPizza);
                                editingPizza = true;
                                menu.currentMenu = 7;
                                //set "edit pizza" to whatever selected pizza is
                                break;
                            case 2:
                                currentUser.Orders[currentUser.Orders.Count - 1].RemovePizza(currentEditRemoveIndex);
                                menu.currentMenu = 5;
                                currentEditRemoveIndex = 0;
                                Console.WriteLine("Item Removed");
                                Console.WriteLine("Returning to Edit/Remove menu...");
                                break;
                            case 3:
                                Console.WriteLine("Returning to Edit/Remove menu...");
                                currentEditRemoveIndex = 0;
                                break;
                            default:
                                Console.WriteLine("That is not an option");
                                break;
                        }
                    }
                }

                while (menu.currentMenu == 7)//edit pizza menu
                {
                    if (CurrentCustomPizza == null) //creates a new "large cheese" pizza if not editing a pizza
                    {
                        CurrentCustomPizza = new Domain.Models.Pizza(
                             "Cheese",
                                    new List<Domain.Models.Topping>(){
                                        new Domain.Models.Topping("Marinara Sauce",0),
                                        new Domain.Models.Topping("Regular Cheese",0)
                                        },
                                        new Domain.Models.Crust("Plain", 0),
                                        new Domain.Models.Size("Large", 4),
                                        6);
                    }

                    menu.DisplayCustomizePizzaMenu(CurrentCustomPizza);

                    if (int.TryParse(Console.ReadLine(), out input))//if input passes as good input, then perform selected operation
                    {
                        switch (input)
                        {
                            case 1:
                                System.Console.WriteLine("proceeding to Edit Size...");
                                menu.currentMenu = 13;
                                break;

                            case 2:
                                System.Console.WriteLine("proceeding to Edit Crust...");
                                menu.currentMenu = 14;
                                break;

                            case 3:
                                System.Console.WriteLine("proceeding to Edit Sauce...");
                                menu.currentMenu = 15;
                                break;

                            case 4:
                                System.Console.WriteLine("proceeding to Edit Cheese...");
                                menu.currentMenu = 16;
                                break;

                            case 5:
                                System.Console.WriteLine("proceeding to Edit Toppings...");
                                menu.currentMenu = 17;
                                break;

                            case 6:
                                System.Console.WriteLine("Pizza Added to Order");
                                if (!editingPizza)
                                {
                                    currentUser.Orders[currentUser.Orders.Count - 1].CreatePizza(CurrentCustomPizza);
                                }
                                editingPizza = false;
                                CurrentCustomPizza = null;
                                menu.currentMenu = 4;
                                break;

                            case 7:
                                System.Console.WriteLine("Proceeding to Main Menu...");
                                if (editingPizza)
                                {
                                    currentUser.Orders[currentUser.Orders.Count - 1].Pizzas[currentEditRemoveIndex] = CurrentCustomPizzaOld;
                                }

                                editingPizza = false;
                                menu.currentMenu = 4;
                                break;

                            default:
                                Console.WriteLine("That is not an option");
                                break;
                        }
                    }

                }

                //checkout menu
                while (menu.currentMenu == 8)
                {
                    menu.DisplayCheckoutMenu(currentUser.Orders[currentUser.Orders.Count - 1]);

                    if (int.TryParse(Console.ReadLine(), out input))
                    {
                        switch (input)
                        {
                            case 1:
                                Console.WriteLine("Placing Order...");
                                var connection = new PizzaStore.Storing.Repositories.OrderRepository();

                                connection.CreateOrderCustomerPizzaRelation(currentUser);

                                menu.currentMenu = 9;
                                break;

                            case 2:
                                Console.WriteLine("Returning to Main Menu...");
                                menu.currentMenu = 4;
                                break;

                            default:
                                Console.WriteLine("That is not an option");
                                break;
                        }
                    }
                }

                //Order Placed Menu
                while (menu.currentMenu == 9)
                {
                    menu.DisplayOrderConfirmedMenu(currentUser.Name);

                    if (int.TryParse(Console.ReadLine(), out input))
                    {
                        switch (input)
                        {
                            case 1:
                                Console.WriteLine("Starting Another order");
                                currentUser.Orders.Add(new Order());
                                menu.currentMenu = 4;
                                break;

                            case 2:
                                Console.WriteLine("Logging out...");
                                currentUser = null;
                                menu.currentMenu = 0;
                                break;

                            default:
                                Console.WriteLine("That is not an option");
                                break;
                        }
                    }
                }

                //store main menu
                while (menu.currentMenu == 11)
                {
                    menu.DisplayStoreMainMenu();

                    if (int.TryParse(Console.ReadLine(), out input))
                    {
                        switch (input)
                        {
                            case 1:
                                Console.WriteLine("Displaying Orders");
                                System.Console.WriteLine(new PizzaStore.Storing.Repositories.OrderRepository().ReadOrderData());
                                break;

                            case 2:
                                Console.WriteLine("Proceeding to Sales...");
                                //menu.currentMenu = ;
                                break;

                            case 3:
                                Console.WriteLine("Logging Out...");
                                menu.currentMenu = 0;
                                break;

                            default:
                                Console.WriteLine("That is not an option");
                                break;
                        }
                    }
                }

                while (menu.currentMenu == 13)//edit pizza Size menu
                {
                    menu.DisplayEditPizzaSizeMenu();
                    if (int.TryParse(Console.ReadLine(), out input))//if input passes as good input, then perform selected operation
                    {
                        switch (input)
                        {
                            case 1:
                                System.Console.WriteLine("Size set to Small");
                                CurrentCustomPizza.Size.SizeName = "Small";
                                CurrentCustomPizza.Size.Price = 0;
                                menu.currentMenu = 7;
                                break;

                            case 2:
                                System.Console.WriteLine("Size set to Medium");
                                CurrentCustomPizza.Size.SizeName = "Medium";
                                CurrentCustomPizza.Size.Price = 2;
                                menu.currentMenu = 7;
                                break;

                            case 3:
                                System.Console.WriteLine("Size set to Large");
                                CurrentCustomPizza.Size.SizeName = "Large";
                                CurrentCustomPizza.Size.Price = 4;
                                menu.currentMenu = 7;
                                break;

                            case 4:
                                System.Console.WriteLine("Returning to Customize Menu...");
                                menu.currentMenu = 7;
                                break;

                            default:
                                Console.WriteLine("That is not an option");
                                break;

                        }
                    }
                }
                while (menu.currentMenu == 14)//edit pizza Crust menu
                {
                    menu.DisplayEditPizzaCrusteMenu();
                    if (int.TryParse(Console.ReadLine(), out input))//if input passes as good input, then perform selected operation
                    {
                        switch (input)
                        {
                            case 1:
                                System.Console.WriteLine("Crust set to Plain");
                                CurrentCustomPizza.Crust.CrustName = "Plain";
                                CurrentCustomPizza.Crust.Price = 0;
                                menu.currentMenu = 7;
                                break;

                            case 2:
                                System.Console.WriteLine("Crust set to Deep Dish");
                                CurrentCustomPizza.Crust.CrustName = "Deep Dish";
                                CurrentCustomPizza.Crust.Price = 1;
                                menu.currentMenu = 7;
                                break;

                            case 3:
                                System.Console.WriteLine("Crust set to Stuffed");
                                CurrentCustomPizza.Crust.CrustName = "Stuffed";
                                CurrentCustomPizza.Crust.Price = 2;
                                menu.currentMenu = 7;
                                break;

                            case 4:
                                System.Console.WriteLine("Returning to Customize Menu...");
                                menu.currentMenu = 7;
                                break;

                            default:
                                Console.WriteLine("That is not an option");
                                break;

                        }
                    }
                }
                while (menu.currentMenu == 15)//edit pizza Sauce menu
                {
                    menu.DisplayEditPizzaSauceeMenu();
                    if (int.TryParse(Console.ReadLine(), out input))//if input passes as good input, then perform selected operation
                    {
                        switch (input)
                        {
                            case 1:
                                System.Console.WriteLine("Sauce set to Marinara");
                                CurrentCustomPizza.Toppings[0].TopName = "Marinara";
                                CurrentCustomPizza.Toppings[0].Price = 0;
                                menu.currentMenu = 7;
                                break;

                            case 2:
                                System.Console.WriteLine("Sauce set to Alfredo");
                                CurrentCustomPizza.Toppings[0].TopName = "Alfredo";
                                CurrentCustomPizza.Toppings[0].Price = .5;
                                menu.currentMenu = 7;
                                break;

                            case 3:
                                System.Console.WriteLine("Sauce set to Ranch");
                                CurrentCustomPizza.Toppings[0].TopName = "Ranch";
                                CurrentCustomPizza.Toppings[0].Price = .5;
                                menu.currentMenu = 7;
                                break;

                            case 4:
                                System.Console.WriteLine("Returning to Customize Menu...");
                                menu.currentMenu = 7;
                                break;

                            default:
                                Console.WriteLine("That is not an option");
                                break;

                        }
                    }
                }
                while (menu.currentMenu == 16)//edit pizza Cheese menu
                {
                    menu.DisplayEditPizzaCheeseMenu();
                    if (int.TryParse(Console.ReadLine(), out input))//if input passes as good input, then perform selected operation
                    {
                        switch (input)
                        {
                            case 1:
                                System.Console.WriteLine("Cheese set to None");
                                CurrentCustomPizza.Toppings[1].TopName = "No Cheese";
                                CurrentCustomPizza.Toppings[1].Price = 0;
                                menu.currentMenu = 7;
                                break;

                            case 2:
                                System.Console.WriteLine("Cheese set to Regular");
                                CurrentCustomPizza.Toppings[1].TopName = "Regular Cheese";
                                CurrentCustomPizza.Toppings[1].Price = 0;
                                menu.currentMenu = 7;
                                break;

                            case 3:
                                System.Console.WriteLine("Cheese set to Extra");
                                CurrentCustomPizza.Toppings[1].TopName = "Extra Cheese";
                                CurrentCustomPizza.Toppings[1].Price = .75;
                                menu.currentMenu = 7;
                                break;

                            case 4:
                                System.Console.WriteLine("Returning to Customize Menu...");
                                menu.currentMenu = 7;
                                break;

                            default:
                                Console.WriteLine("That is not an option");
                                break;

                        }
                    }
                }
                while (menu.currentMenu == 17)//edit pizza Toppings menu
                {
                    menu.DisplayEditPizzaToppingsMenu(CurrentCustomPizza);
                    if (int.TryParse(Console.ReadLine(), out input))//if input passes as good input, then perform selected operation
                    {
                        switch (input)
                        {
                            case 1:
                                string addRemove = (CurrentCustomPizza.CheckHasTopping("Pepperoni")) ? "Remove" : "Add";
                                System.Console.WriteLine($"Pepperoni {addRemove}ed");
                                if (addRemove == "Add")
                                {

                                    CurrentCustomPizza.AddTopping(new Domain.Models.Topping() { TopName = "Pepperoni", Price = 1 });
                                }
                                else
                                {
                                    CurrentCustomPizza.RemoveTopping("Pepperoni");
                                }
                                break;

                            case 2:
                                addRemove = (CurrentCustomPizza.CheckHasTopping("Ham")) ? "Remove" : "Add";
                                System.Console.WriteLine($"Ham {addRemove}ed");
                                if (addRemove == "Add")
                                {

                                    CurrentCustomPizza.AddTopping(new Domain.Models.Topping() { TopName = "Ham", Price = 1.25 });
                                }
                                else
                                {
                                    CurrentCustomPizza.RemoveTopping("Ham");
                                }
                                break;

                            case 3:
                                addRemove = (CurrentCustomPizza.CheckHasTopping("Chicken")) ? "Remove" : "Add";
                                System.Console.WriteLine($"Chicken {addRemove}ed");
                                if (addRemove == "Add")
                                {

                                    CurrentCustomPizza.AddTopping(new Domain.Models.Topping() { TopName = "Chicken", Price = 2 });
                                }
                                else
                                {
                                    CurrentCustomPizza.RemoveTopping("Chicken");
                                }
                                break;

                            case 4:
                                addRemove = (CurrentCustomPizza.CheckHasTopping("Pineapple")) ? "Remove" : "Add";
                                System.Console.WriteLine($"Pineapple {addRemove}ed");
                                if (addRemove == "Add")
                                {

                                    CurrentCustomPizza.AddTopping(new Domain.Models.Topping() { TopName = "Pineapple", Price = .75 });
                                }
                                else
                                {
                                    CurrentCustomPizza.RemoveTopping("Pineapple");
                                }
                                break;

                            case 5:
                                addRemove = (CurrentCustomPizza.CheckHasTopping("Buffalo Hot Sauce")) ? "Remove" : "Add";
                                System.Console.WriteLine($"Buffalo Hot Sauce {addRemove}ed");
                                if (addRemove == "Add")
                                {

                                    CurrentCustomPizza.AddTopping(new Domain.Models.Topping() { TopName = "Buffalo Hot Sauce", Price = .25 });
                                }
                                else
                                {
                                    CurrentCustomPizza.RemoveTopping("Buffalo Hot Sauce");
                                }
                                break;

                            case 6:
                                System.Console.WriteLine("Returning to Customize Menu...");
                                menu.currentMenu = 7;
                                break;

                            default:
                                Console.WriteLine("That is not an option");
                                break;

                        }
                    }
                }


                System.Console.WriteLine();
            } while (!terminateProgram);
        }





    }
}


