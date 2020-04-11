Create Database CafeProjectDB
Go
Use CafeProjectDB
Go
Create Table [User](
	Id int identity primary key,
	Username varchar(150),
	Email varchar(150),
	FirstName varchar(150),
	LastName varchar(150)
)
Go
Create Table Images
(
	Id int identity primary key,
	[Name] varchar(150)
)
Go
Create Table Menu
(
	Id int identity primary key,
	[Name] varchar(150),
	ImageId int
	Constraint FK_MImages Foreign Key(ImageId) References Images(Id) 
)
Go
Create Table Category
(
	Id int identity primary key,
	[Name] varchar(100),
	ImageId int
	Constraint FK_CImage Foreign Key(ImageId) References Images(Id) 
)
Go
Create Table Product
(
	Id int identity primary key,
	[Name] varchar(75),
	CategoryId int,
	ProductDetail text,
	Information text,
	Price int,
	Amount int,
	[Views] int,
	Rating int
	Constraint FK_PCategory Foreign Key(CategoryId) References Category(Id) 	
)
Go
Create Table Comment
(
	Id int identity primary key,
	UserId int,
	ProductId int,
	[Description] text,
	Constraint FK_CUser Foreign Key(UserId) References [User](Id),
	Constraint FK_CProduct Foreign Key(ProductId) References Product(Id) 	
)
Go
Create Table Campaign
(
	Id int identity primary key,
	[Description] text,
	OldPrice int,
	NewPrice int,
)
Go
Create Table CampProduct
(
	Id int identity primary key,
	CampaignId int,
	ProductId int,
    Constraint FK_CPCampaing Foreign Key(CampaignId) References Campaign(Id),
	Constraint FK_CPProduct Foreign Key(ProductId) References Product(Id) 	
)
Go
Create Table CompanyInformation
(
  Id int identity primary key,
  [Description] text,
)
Go
Create Table Contact
(
	Id int identity primary key,
	LocationGeneral varchar(100),	
)
Go
Create Table Phones
(
	Id int identity primary key,
	[Phone] char(11),
	ContactId int,
	Constraint FK_CPhones Foreign Key(ContactId) References Contact(Id),
)
Go
Create Table Emails
(
   Id int identity primary key,
   Email varchar(175),
   ContactId int,
   Constraint FK_Email Foreign Key(ContactId) References Contact(Id),

)
Go
Create Table Locations
(
  Id int identity primary key,
  LocationName varchar(175),
  ContactId int,
  Constraint FK_Location Foreign Key(ContactId) References Contact(Id)
)
Go
Create Table [Table]
(
	Id int identity primary key,
	Number int
)
Go
Create Table [Order]
(
	Id int identity primary key,
	UserId int,
	TableId int,
	ProductId int,
	Amount int,
	TotalPrice int,
	IsComplete bit default 0,
    Constraint FK_OUser Foreign Key(UserId) References [User](Id),
    Constraint FK_OTable Foreign Key(TableId) References [Table](Id),
	Constraint FK_OProduct Foreign Key(ProductId) References  Product(Id)
)
Go
Create Table [OrderHistory]
(
	Id int identity primary key,
	UserId int,
	OrderId int,
	Constraint FK_OHUser Foreign Key(UserId) References [User](Id),
    Constraint FK_OHTable Foreign Key(OrderId) References [Order](Id)
)
Go
Create Table LogStatus
(
	Id int identity primary key,
	[Name] varchar(150) 
)
Go
Create Table [Log]
(
	Id int identity primary key,
	[Description] text,
	LogStatusId int
    Constraint FK_LStatus Foreign Key(LogStatusId) References LogStatus(Id)	
)
Go
Create Table MusicClaim
(
	Id int identity primary key,
	MusicName text,
	IsApproved bit
)
Go
Create Table MusicList
(
	Id int identity primary key,
	MusicName text,
    [Order] int
)