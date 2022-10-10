use DB_PARCIAL




create table Direccion(
IdCodigoPostal int constraint PK_DIRECCION primary key not null,
Calle varchar(100) not null,
Ciudad varchar(50) not null,
Departamento varchar(50) not null
);

create table Persona(
 Cedula int constraint PK_PERSONA primary key not null,
 Nombre varchar(50) not null,
 Apellidos varchar(50) not null,
 Correo varchar(100) not null,
 Telefono varchar(50) not null,
 Direccion int constraint FK_PERSONA_DIRECCION foreign key references Direccion(IdCodigoPostal)
);

select Cedula as [No de Identificacion], (Nombre+' '+Apellidos) as Nombres,Correo as [E-mail] from PERSONA

create table Descuento(
IdCodigoDescuento int constraint PK_DESCUENTO primary key not null,
Valor decimal(10,2) not null
);

create table Producto(
idCodigo int constraint PK_PRODUCTO primary key,
Nombre varchar(100) not null,
Precio Decimal(10,2) not null,
Descuento int constraint FK_PRODUCTO_DESCUENTO foreign key references Descuento(IdCodigoDescuento)
--falta el calculable 
);

create 

