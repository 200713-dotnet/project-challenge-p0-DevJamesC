use master;
go

-- CREATE 

create database PizzaStoreDb;
go

use PizzaStoreDb;
go

create schema Pizza; 
go

create schema Agent;
go




create table Pizza.Crust
(
    CrustId int not null,
    Name nvarchar(250) not null,
    DateModified datetime2(0) not null,
    Active bit not null default 1,
    constraint PK_CrustId primary key (CrustId)
);

create table Pizza.Size
(
    SizeId int not null,
    Name nvarchar(250) not null,
    DateModified datetime2(0) not null,
    Active bit not null,
    constraint PK_SizeId primary key (SizeId)
);

create table Pizza.Pizza
(
    PizzaId int not null,
    CrustId int null,
    SizeId int null,
    Name nvarchar(250) not null,
    DateModified datetime2(0) not null,
    Active bit not null default 1,
    constraint PK_PizzaId primary key (PizzaId),
    constraint FK_CrustId foreign key(CrustId) references Pizza.Crust(CrustId),
    constraint FK_SizeId foreign key(SizeId) references Pizza.Size(SizeId)
);

create table Pizza.Topping
(
    ToppingId int not null,
    Name nvarchar(250) not null,
    DateModified datetime2(0) not null,
    Active bit not null,
    constraint PK_ToppingID primary key (ToppingId)
);

create table Pizza.FK_Pizza_ToppingId
(
    PizzaToppingId int not null,
    PizzaId int not NULL,
    ToppingId int not null,
    Active bit not null,
    CONSTRAINT PK_PizzaToppingId Primary key (PizzaToppingId),
    CONSTRAINT PK_PizzaTopping_PizzaId foreign key(PizzaId) references Pizza.Pizza(PizzaId),
    Constraint PK_PizzaTopping_ToppingId foreign key(ToppingId) references Pizza.Topping(ToppingId)
);

create table Agent.Name
(
    NameId int not null,
    NameText nvarchar(250),
    DateModified datetime2(0) not null,
    Active bit not null default 1,
    constraint PK_NameId primary key (NameId)
);

create table Agent.Customer
(
    CustomerId int not null,
    NameId int not null,
    DateModified datetime2(0) not null,
    Active bit not null default 1,
    constraint PK_CustomerId primary key (CustomerId),
    constraint FK_Customer_NameId foreign key(NameId) references Agent.Name(NameId)
);

create table Agent.Shop
(
    ShopId int not null,
    NameId int not null,
    DateModified datetime2(0) not null,
    Active bit not null default 1,
    constraint PK_ShopId primary key (ShopId),
    constraint FK_Shop_NameId foreign key(NameId) references Agent.Name(NameId)
);



create table Agent.CustomerOrder
(
    CustomerOrderId int not null,
    totalPrice money not null,
    OrderedFrom nvarchar(250) not null,
    DateModified datetime2(0) not null,
    Active bit not null default 1,
    constraint PK_CustomerOrderId primary key (CustomerOrderId)
);

create table Agent.FK_CustomerOrder_Customer
(
    CustomerOrderCustomerId int not null,
    CustomerOrderId int not NULL,
    CustomerId int not null,
    Active bit not null,
    CONSTRAINT PK_CustomerOrderCustomerId Primary key (CustomerOrderCustomerId),
    CONSTRAINT PK_CustomerOrderCustomer_CustomerOrder foreign key(CustomerOrderId) references Agent.CustomerOrder(CustomerOrderId),
    Constraint PK_CustomerOrderCustomer_Customer foreign key(CustomerId) references Agent.Customer(CustomerId)
);

create table Agent.FK_CustomerOrder_Pizza
(
    CustomerOrderPizzaId int not null,
    CustomerOrderId int not NULL,
    PizzaId int not null,
    Active bit not null,
    CONSTRAINT PK_CustomerOrderPizzaId Primary key (CustomerOrderPizzaId),
    CONSTRAINT PK_CustomerOrderPizzaId_CustomerOrder foreign key(CustomerOrderId) references Agent.CustomerOrder(CustomerOrderId),
    Constraint PK_CustomerOrderPizzaId_Pizza foreign key(PizzaId) references Pizza.Pizza(PizzaId)
);

INSERT into Agent.NAME
    (NameId,NameText,DateModified,Active)
values(1, 'User', '20120618 10:34:09 AM', 1);

INSERT into Agent.NAME
    (NameId,NameText,DateModified,Active)
values(2, 'Shop', '20120618 10:34:09 AM', 1);

INSERT into Agent.Customer
    (CustomerId, NameId,DateModified,Active)
values
    (1, 1, '20120618 10:34:09 AM', 1);

Insert into Agent.Shop
    (ShopId,NameId,DateModified,Active)
values
    (1, 2, '20120618 10:34:09 AM', 1);

insert into pizza.Topping (ToppingId,Name,DateModified,Active)
VALUEs (0,'Pepperoni','20120618 10:34:09 AM',1);

insert into pizza.Topping (ToppingId,Name,DateModified,Active)
VALUEs (1,'Ham','20120618 10:34:09 AM',1);

insert into pizza.Topping (ToppingId,Name,DateModified,Active)
VALUEs (2,'Chicken','20120618 10:34:09 AM',1);

insert into pizza.Topping (ToppingId,Name,DateModified,Active)
VALUEs (3,'Pineapple','20120618 10:34:09 AM',1);

insert into pizza.Topping (ToppingId,Name,DateModified,Active)
VALUEs (4,'Buffalo Hot Sauce','20120618 10:34:09 AM',1);

insert into Pizza.Crust(CrustId,Name,DateModified,Active)
values(0,'Plain','20120618 10:34:09 AM',1),
(1,'Stuffed','20120618 10:34:09 AM',1),
(2,'Deep Dish','20120618 10:34:09 AM',1);

insert into Pizza.Size(SizeId,Name,DateModified,Active)
values(0,'Small','20120618 10:34:09 AM',1),
(1,'Medium','20120618 10:34:09 AM',1),
(2,'Large','20120618 10:34:09 AM',1);

insert into Pizza.Pizza(PizzaId, CrustId,SizeId, Name, DateModified,Active)
values (0,0,0,'Small Plain','20120618 10:34:09 AM',1),
(1,0,1,'Medium Plain','20120618 10:34:09 AM',1),
(2,0,2,'Large Plain','20120618 10:34:09 AM',1),
(3,1,0,'Small Stuffed','20120618 10:34:09 AM',1),
(4,1,1,'Medium Stuffed','20120618 10:34:09 AM',1),
(5,1,2,'Large Stuffed','20120618 10:34:09 AM',1),
(6,2,0,'Small Deep Dish','20120618 10:34:09 AM',1),
(7,2,1,'Medium Deep Dish','20120618 10:34:09 AM',1),
(8,2,2,'Large Deep Dish','20120618 10:34:09 AM',1);




--DESTROY
drop table Agent.FK_CustomerOrder_Pizza;
drop table Pizza.FK_Pizza_ToppingId;
drop table Pizza.Pizza;
drop table Pizza.Topping;
drop table Pizza.Crust;
drop table Pizza.Size;
drop table Agent.FK_CustomerOrder_Customer;
drop table Agent.Customer;
drop table Agent.Shop;
drop table Agent.CustomerOrder;
drop table Agent.Name;
drop SCHEMA Pizza;
Drop SCHEMA Agent;
Drop DATABASE PizzaStoreDb;

--Queries

Select *
From Agent.CustomerOrder;
Select *
From Agent.Customer;
SELECT *
from Agent.FK_CustomerOrder_Customer;
select *
From Agent.Name;



