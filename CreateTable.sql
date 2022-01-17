create database BDLibreriaNexos
use  BDLibreriaNexos

create table Editoriales(
IdEditorial int  primary key,
Nombre varchar(50),
Direccion varchar (50),
Telefono varchar (50),
Correo varchar(30),
MaximoLibrosReg int 


)

create table Autores (
IdAutor int  primary key,
Nombre varchar (50),
FechaNacimiento datetime,
CiudadProced varchar (50),
Correo varchar (50)

)



create table Libros (
IDIsbn int  primary key,
Titulo varchar (50),
Anio int ,
Genero varchar (50),
NumeroPaginas int ,
IdEditorial int,
IdAutor int
FOREIGN KEY (IdAutor) REFERENCES Autores(IdAutor),
FOREIGN KEY (IdEditorial) REFERENCES Editoriales(IdEditorial)

)

select * from Libros

Scaffold-DbContext "Server=LAPTOP-9H09STR1\MSSQLSERVER_HANS;Database=BDLibreriaNexos;Integrated Security= true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data