create table PatientsInfo
(
PatientID int primary key identity (1,1) not null,
Firstname varchar(50) not null,
Lastname varchar(50) not null,
DateOfBirth datetime not null,
AddressID int not null,
DocID int not null,
);