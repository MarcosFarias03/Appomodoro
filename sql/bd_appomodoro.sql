create table Usuario(
Id bigint identity(1,1) not null ,
Mail varchar(30) not null,

primary key (Id), 
);

create table Tareas(
Id bigint identity (1,1) not null ,
Tarea varchar(40) not null,
primary key (Id)
);