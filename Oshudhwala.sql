create database Oshudhwala

use Oshudhwala


Create Schema Medicine
go
Create Schema Person
go
Create Schema Orders



Create table Medicine.Category
(
	Id int identity(1,1) primary key,
	CategoryName varchar(50) not null
)
go
create table Medicine.SubCategory
(
	Id int identity(1,1) primary key,
	SubCategoryName varchar(50) not null,
	CategoryId int foreign key references Medicine.Category(Id)
)
go
create table Medicine.SubSubCategory
(
	Id int identity(1,1) primary key,
	SubSubCategroyName varchar(50) not null,
	SubCategoryId int foreign key references Medicine.SubCategory(Id)
)
go
create table Medicine.Items
(
	Id int identity(1,1) primary key,
	ItemName nvarchar(100) not null,
	Photo nvarchar(200),
	Price float not null,
	Details nvarchar(500),
	SubSubCategoryId int foreign key references Medicine.SubSubCategory(Id),
	IsDanger bit default 0
)
go
Create table Person.[Type]
(
	Id int identity(1,1) primary key,
	TypeName varchar(20)
)
go
create table Person.Users
(
	Id int identity(1,1),
	Name varchar(50) not null,
	Email varchar(50),
	Phone varchar(20),
	[Password] nvarchar(25) not null,
	Photo nvarchar(200),
	[Address] nvarchar(200),
	UserType int foreign key references Person.[Type](Id)
)
go
