using System;
using System.Collections.Generic;
using PizzaStore.Domain.Models;

namespace PizzaStore.Client
{
    //  menu index: Exit=-1 EntryMenu=0 Login=1 Register=2 SelectLocation=3 Main=4 SelectEdititem=5 EditRemoveItem=6 CustomPizzaBuilder=7 Checkout=8 UserProfileSettings=9 ShopMain=10
    class Program
    {
        static void Main(string[] args)
        {
            RunApplication();
        }

        static void RunApplication()
        {
            MenuManager menu = new MenuManager();
            bool terminateProgram = false;
            User currentUser = null;
            int currentEditRemoveIndex = 0;
            Pizza CurrentCustomPizza = null;
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
                                }//if shop, go to ShopMainMenu instead
                                break;

                            case 2:
                                Console.WriteLine("Selected Dev's Pizza - Westside");
                                if (currentUser != null)
                                {
                                    currentUser.ChosenStore = new Store("Dev's Pizza - Westside", "Store2");
                                    menu.currentMenu = 4;
                                }//if shop, go to ShopMainMenu instead
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
                                    new List<Topping>(){
                                        new Topping("Marinara Sauce",0),
                                        new Topping("Cheese",0)
                                        },
                                        new Crust("Plain", 0),
                                        new Size("Large", 4),
                                        6);
                                break;

                            case 3:
                                System.Console.WriteLine("Added Pepperoni Pizza");
                                currentUser.Orders[currentUser.Orders.Count - 1].CreatePizza(
                                    "Pepperoni",
                                   new List<Topping>(){
                                        new Topping("Marinara Sauce",0),
                                        new Topping("Cheese",0),
                                        new Topping("Pepperoni",1)
                                       },
                                       new Crust("Plain", 0),
                                       new Size("Large", 4),
                                       6);
                                break;

                            case 4:
                                System.Console.WriteLine("Added Hawaiian Pizza");
                                currentUser.Orders[currentUser.Orders.Count - 1].CreatePizza(
                                    "Hawaiian",
                                 new List<Topping>(){
                                        new Topping("Marinara Sauce",0),
                                        new Topping("Cheese",0),
                                        new Topping("Pineapples",.75),
                                        new Topping("Ham",1.25)
                                     },
                                     new Crust("Plain", 0),
                                     new Size("Large", 4),
                                     6);
                                break;

                            case 5:
                                System.Console.WriteLine("Added Buffalo Chicken Pizza");
                                currentUser.Orders[currentUser.Orders.Count - 1].CreatePizza(
                                    "Buffalo Chicken",
                                 new List<Topping>(){
                                        new Topping("Marinara Sauce",0),
                                        new Topping("Cheese",0),
                                        new Topping("Chicken",2),
                                        new Topping("Buffalo Hot Sauce",.25)
                                     },
                                     new Crust("Plain", 0),
                                     new Size("Large", 4),
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

                while (menu.currentMenu == 7)
                {
                    if (CurrentCustomPizza == null) //creates a new "large cheese" pizza if not editing a pizza
                    {
                        CurrentCustomPizza = new Pizza(
                             "Cheese",
                                    new List<Topping>(){
                                        new Topping("Marinara Sauce",0),
                                        new Topping("Cheese",0)
                                        },
                                        new Crust("Plain", 0),
                                        new Size("Large", 4),
                                        6);
                    }

                    menu.DisplayCustomizePizzaMenu(CurrentCustomPizza);


                }

                System.Console.WriteLine();
            } while (!terminateProgram);
        }

    }
}


