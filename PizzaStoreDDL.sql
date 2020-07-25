use master;
go

-- CREATE 

create database PizzaStoreDb;
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
    UserModified datetime2(0) not null,
    Active bit not null default 1,
    constraint PK_CrustId primary key (CrustId)
);

create table Pizza.Size
(
    SizeId int not null,
    Name nvarchar(250) not null,
    DateModified datetime2(0) not null,
    UserModified datetime2(0) not null,
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
    UserModified datetime2(0) not null,
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
    UserModified datetime2(0) not null,
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
    DateModified datetime2(0) not null,
    UserModified datetime2(0) not null,
    Active bit not null default 1,
    constraint PK_NameId primary key (NameId)
);

create table Agent.Customer
(
    CustomerId int not null,
     NameId int not null,
    DateModified datetime2(0) not null,
    UserModified datetime2(0) not null,
    Active bit not null default 1,
    constraint PK_CustomerId primary key (CustomerId),
    constraint FK_Customer_NameId foreign key(NameId) references Agent.Name(NameId)
);

create table Agent.Shop
(
    ShopId int not null,
     NameId int not null,
    DateModified datetime2(0) not null,
    UserModified datetime2(0) not null,
    Active bit not null default 1,
    constraint PK_ShopId primary key (ShopId),
    constraint FK_Shop_NameId foreign key(NameId) references Agent.Name(NameId)
);



create table Agent.CustomerOrder
(
    CustomerOrderId int not null,
    DateModified datetime2(0) not null,
    UserModified datetime2(0) not null,
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