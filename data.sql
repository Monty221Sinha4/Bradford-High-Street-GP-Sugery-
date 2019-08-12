create table Doctors 
(
DoctID int primary key Identity (1,1) not null,
Firstname varchar(50) not null,
Lastname varchar (50) not null,
DegreeID int not null,
);

create table MedicalDegree
(
DegreeID int primary key identity (1,1) not null,
MedicalDergee varchar (12) not null, 
);