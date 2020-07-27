# pizzabox

The goal of the project is to build a Pizza Ordering System. 

## architecture (REQUIRED) [CHECK]

+ [solution] PizzaBox.sln
  + [project - console] PizzaBox.Client.csproj
  + [project - classlib] PizzaBox.Domain.csproj
    + [folder] Abstracts
    + [folder] Interfaces
    + [folder] Models
  + [project - classlib ] PizzaBox.Storing.csproj
    + [folder] Repositories
  + [project - xunit] PizzaBox.Testing.csproj
    + [folder] Tests

## requirements

The project should support objects of User, Store, Order, Pizza.

### store

+ [required] there should exist at least 2 stores for a user to choose from [CHECK]
+ [required] each store should be able to view/list any and all of their completed/placed orders
+ [required] each store should be able to view/list any and all of their sales (amount of revenue weekly or monthly)

### order

+ [required] each order must be able to view/list/edit its collection of pizzas [CHECK]
+ [required] each order must be able to compute its pricing [CHECK]
+ [required] each order must be limited to a total pricing of no more than $250 [CHECK--NOT-DISPLAYED-TO-USERS]
+ [required] each order must be limited to a collection of pizzas of no more than 50 [CHECK--NOT-DISPLAYED-TO-USERS]

### pizza

+ [required] each pizza must be able to have a crust [CHECK]
+ [required] each pizza must be able to have a size [CHECK]
+ [required] each pizza must be able to have toppings [CHECK]
+ [required] each pizza must be able to compute its pricing [CHECK]
+ [required] each pizza must have no less than 2 default toppings [Check--Not-Enforced-By-Code]
+ [required] each pizza must limit its toppings to no more 5 [CHECK--NOT-DISPLAYED-TO-USERS]

### user

+ [required] must be able to view/list its order history
+ [required] must be able to only order from 1 location in a 24-hour period with no reset
+ [required] must be able to only order once every 2-hour period

## technologies

+ .NET Core - C# [CHECK]
+ .NET Core - EF + SQL [CHECK]
+ .NET Core - xUnit [CHECK]

## timelines

+ due on Jul-27 at 11p Central
+ present on Jul-29 starting at 9.30a Central
+ implement as many requirements as you can

## user story

as a user, i should be able to do this:

+ access the application [CHECK]
+ see a list of locations [CHECK]
+ select a location [CHECK]
+ place an order [CHECK]
+ with either custom or preset pizzas
+ if custom
+ select crust, size and toppings
+ if preset
+ select pizza and its size
+ see a tally of my order [CHECK]
+ add or remove more pizzas [Check]
+ and checkout when complete with latest order [CHECK]
+ see my order history
+ make a new order [CHECK]

## store story

as a store, i should be able do this:

+ access the application [CHECK]
+ select options for order history, sales [CHECK]
+ if order history
+ select options for all store orders and orders associated to a user (filtering)
+ if sales
+ see pizza type, count, revenue by week or by month

> the goal is to try to complete as many reqs as you can in the time alloted. :)
