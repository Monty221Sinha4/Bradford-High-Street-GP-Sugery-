create table Addresses 
(
AddressID int primary key identity (1,1) not null,
HouseNo int not null,
Street varchar(50) not null,
CityID int not null,
PostcodeID int not null,
);

create table Cities 
(
CityID int primary key identity (1,1) not null,
City varchar(50) not null,
);



create table Postcodes
(
PostcodeID int primary key identity (1,1) not null,
Postcode varchar(20) not null,
);
