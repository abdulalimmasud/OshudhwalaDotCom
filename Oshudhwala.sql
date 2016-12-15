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
	SubCategoryId int foreign key references Medicine.SubCategory(Id),
	CategoryId int foreign key references Medicine.Category(Id), 
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
	Id int identity(1,1) primary key,
	Name varchar(50) not null,
	Email varchar(50),
	Phone varchar(20),
	[Password] nvarchar(25) not null,
	Photo nvarchar(200),
	[Address] nvarchar(200),
	UserType int foreign key references Person.[Type](Id)
)
alter table Person.Users add DateOfBirth varchar(12)
go
create table Person.Doctor
(
	Id int identity(1,1) primary key,
	Name varchar(50) not null,
	Email varchar(50),
	Phone varchar(20),
	[Password] nvarchar(25) not null,
	Designation varchar(50),
	Medical varchar(100),
	Photo nvarchar(200),
	[Address] nvarchar(200),
	UserType int foreign key references Person.[Type](Id)
)
go
create table Orders.OrderType
(
	Id int identity primary key,
	OrderType varchar(50)
)
go
create table Orders.Voucher
(
	Id int identity(1,1) primary key,
	UserId  int foreign key references Person.Users(Id),
	Total float,
	IsConfirm bit default 0,
	IsDelivered bit default 0,
	OrderDate date default getdate(),
	DeliveredTime time(0),
	OrderType int foreign key references Orders.OrderType(Id)
)
go
create table Orders.VoucherItem
(
	Id int identity(1,1) primary key,
	VoucherId int foreign key references Orders.Voucher(Id),
	ItemId int foreign key references Medicine.Items(Id),
	Quantity int,
	StartTime time(0) default '06:00:00',
	PerDay int default 3
)

select * from Medicine.Category
select s.CategoryId, c.CategoryName, s.Id, s.SubCategoryName from Medicine.SubCategory s join Medicine.Category c on s.CategoryId=c.Id

create proc spInsertCategory
@Name varchar(50)
as
insert into Medicine.Category(CategoryName) values(@Name)

create proc spGetCategory
as
select Id, CategoryName from Medicine.Category
go
create proc spGetSubCategory
@id int
as
select Id,SubCategoryName from Medicine.SubCategory where SubCategory.CategoryId=@id
go
create proc spGetSubSubCategory
@id int
as
select Id,SubSubCategroyName from Medicine.SubSubCategory where SubCategoryId=@id
go
create proc spInsertItems
@ItemName nvarchar(100),
@Photo nvarchar(200),
@Price float,
@Details nvarchar(500),
@SubSubCategoryId int,
@SubCategoryId int,
@CategoryId int,
@IsDanger int
as
insert into Medicine.Items(ItemName,Photo,Price,Details,SubSubCategoryId,SubCategoryId,CategoryId,IsDanger)
values(@ItemName,@Photo,@Price,@Details,@SubSubCategoryId,@SubCategoryId,@CategoryId,@IsDanger)
go
create proc spGetItemLikeAs
@text varchar(100)
as
select Id, ItemName,Photo, Price, Details, IsDanger from Medicine.Items where ItemName like @text+'%'
go
create proc spFilterItem
@cId int,
@sCId int,
@ssCId int
as
select Id, ItemName,Photo, Price, Details, IsDanger from Medicine.Items where CategoryId=@cId or SubCategoryId=@sCId or SubSubCategoryId = @ssCId
order by ItemName
go
create proc spInsertUser
@Name varchar(50),
@Email varchar(50),
@Phone varchar(20),
@Password nvarchar(25),
@Address nvarchar(200),
@DateOfBirth varchar(12)
as
insert Person.Users(Name,Email,Phone,[Password],[Address],DateOfBirth) values(@Name,@Email,@Phone,@Password,@Address,@DateOfBirth)

select * from Person.Users


spGetItemLikeAs 'ba'


spInsertItems 'Babys Diapers','E:\Study\Project\OshudhwalaDotCom\OshudhwalaDotCom\Image\Upload\ivcoverfarm.jpg',70,'This is use for baby',1,1,1,0

select * from Medicine.Items

spInsertCategory 'Baby & Mother'
go
spInsertCategory 'Personal Care'
go
spInsertCategory 'Eye Care'
go
spInsertCategory 'First Aid & Health Care'
go
spInsertCategory 'Sexual Wellness'
go
spInsertCategory 'Diabetes'
go
spInsertCategory 'Protien Diet & Vitamin'
go
spInsertCategory 'Others'

insert Medicine.SubCategory(SubCategoryName,CategoryId) values 
('Baby Diapers',1),('Feeding & Nursing',1),('Gift & Accessiories',1),('Health & Safety',1),('Nutrition',1),('Personal Care',1),
('Skin Care',2),('Bath & Body',2),('Adult Care',2),('Feminine Care',2),('Fragrance',2),('Hair Care',2),('Hand & Foot Care',2),('Home & Hygeine',2),('Oral Care',2),('Sexsual Wellness',2),('Shaving & Hair Removal',2),('Beauty',2),
('Pain Management',4),('First Aid & Care',4),('Anti Septic',4),('Adult Care',4),('Stomach & Acid Reflux',4),('Caugh, Cold & Flu',4),
('Monitoring Devices',6),('Testing Supplies',6),('Lancet',6),('Sugar Free Sweetners',6),
('Nutritional Product',7),('Supplements',7),('Calcium & Minerals',7),('Multi Vitamin',7),('Instant Energy Drinks',7)

insert Medicine.SubSubCategory(SubSubCategroyName,SubCategoryId) values
('Diapers',1),('Rash Creams',1),('Wipes',1),
('Bottles & Feeding Aids',2),('Nursing Aids',2),('Sterilizers & Cleaning Accessories',2),('Teethers & Soothers',2),
('Gift Set',3),('Other Accessiories',3),
('Health Needs',4),('Others',4),('Safety',4),('Cleaners Laundry & Detergent',4),
('Baby Food & Suppliments',5),('Mother Nutrition',5),
('Bath Gel Soap & Shampoo',6),('Creams & Lotions',6),('Grooming',6),('Oils',6),('Oral & Ear Care',6),('Powders',6),
('Body',7),('Eyes',7),('Face',7),('Lips',7),('Sun Care',7),
('Kits & Accessiories',8),('Shower Gel & Body Wash',8),('Soap',8),('Wipes',8),('Bath Oils',8),
('Diapers',9),
('Cleansing',10),('Pads & Liners',10),('Tampoons',10),('Sanitary Napkins',10),
('Cologne',11),('Deodorants',11),('Eau De Toilette',11),('Roll-on & Stick Deos',11),('Talcom Powder',11),
('Shampoo',12),('Conditioners',12),('Hair Appliances',12),('Hair Color',12),('Hair Styling',12),('Oils & Treatments',12),
('Accessiories',13),('Creams & Lotions',13),('Hand Wash & Sanitizers',13),
('Creams',14),('Home Freshners',14),('Insects & Mosquito Repellents',14),
('Accessiories & Packs',15),('Cleaning & Whitening',15),('Mouth Wash & Freshners',15),('Tooth Brush',15),('Tooth Paste',15),
('Men',16),('Women',16),
('Accessiories',17),('After Shape',17),('Hair Removing Cream & Wax',17),('Razors & Blades',17),('Shaving Creams & Gels',17),
('Beauty Accessiories',18),('Make Up',18)