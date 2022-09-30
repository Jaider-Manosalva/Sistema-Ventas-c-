
CREATE DATABASE DB_SISTEMA_VENTAS;

USE DB_SISTEMA_VENTAS;

CREATE TABLE ROL(
 IdRol int constraint PK_ROL Primary key identity,
 Descripcion varchar(50),
 FechaRegistro datetime default getdate()
);

CREATE TABLE PERMISO(
 IdPermiso int constraint PK_PERMISO primary key identity,
 IdRol int constraint FK_ROL_PERMISO foreign key references ROL(IdRol),
 NombreMenu varchar(100),
 FechaRegistro datetime default getdate()
);

CREATE TABLE PROVEEDOR(
 IdProveedor int constraint PK_PROVEEDOR primary key identity,
 Documento varchar(50),
 RazonSocial varchar(50),
 Correo varchar(50),
 Telefono varchar(50),
 Estado bit,
 FechaRegistro datetime default getdate()
);

CREATE TABLE CLIENTE(
 IdCliente int constraint PK_CLIENTE primary key identity,
 Documento varchar(50),
 NombreCompleto varchar(100),
 Correo varchar(50),
 Telefono varchar(50),
 Estado bit,
 FechaRegistro datetime default getdate()
);

CREATE TABLE USUARIO(
 IdUsuario int constraint PK_USUARIO primary key identity,
 Documento varchar(50),
 NombreCompleto varchar(100),
 Correo varchar(50),
 Clave Varchar(50),
 IdRol int constraint FK_ROL_USUARIO foreign key references Rol(IdRol),
 Estado bit,
 FechaRegistro datetime default getdate()
);

CREATE TABLE CATEGORIA(
 IdCategoria int constraint PK_CATEGORIA primary key identity,
 Descripcion varchar(100),
 estado bit,
 FechaRegistro datetime default getdate()
);

CREATE TABLE PRODUCTO(
 IdProducto int constraint PK_PRODUCTO primary key identity,
 Codigo varchar(50),
 Nombre varchar(50),
 Descripcion varchar(50),
 IdCategoria int constraint FK_CATEGORIA_PRODUCTO foreign key references CATEGORIA(IdCategoria),
 Strock int not null default 0,
 PrecioCompra decimal(10,2) default 0,
 Precioventa decimal(10,2) default 0,
 Estado bit,
 FechaRegistro datetime default getdate()
);

CREATE TABLE COMPRA(
 IdCompra int constraint PK_COMPRA primary key identity,
 IdUsuario int constraint FK_USUARIO_COMPRA foreign key references USUARIO(IdUsuario),
 IdProveedor int constraint FK_PROVEEDOR_COMPRA foreign key references PROVEEDOR(IdProveedor),
 TipoDocumento varchar(50),
 NumeroDocumento varchar(50),
 MontoTotal decimal(10,2),
 FechaRegistro datetime default getdate()
);

CREATE TABLE DETALLE_COMPRA(
 IdDetalleCompra int constraint PK_DETALLE_COMPRA primary key identity,
 IdCompra int constraint FK_COMPRA_DETALLE_COMPRA foreign key references COMPRA(IdCompra),
 IdProducto int constraint FK_PRODUCTO_COMPRA foreign key references PRODUCTO(IdProducto),
 PrecioCompra decimal(10,2) default 0,
 Precioventa decimal(10,2) default 0,
 Cantidad int,
 MontoTotal decimal(10,2),
 FechaRegistro datetime default getdate()
);

CREATE TABLE VENTA(
 IdVenta int constraint PK_VENTA primary key identity,
 IdUsuario int constraint FK_USUARIO_VENTA foreign key references USUARIO(IdUsuario),
 TipoDocumento varchar(50),
 NumeroDocumento varchar(50),
 DocumentoCliente varchar(50),
 NombreCliente varchar(100),
 MontoPago decimal(10,2),
 MontoCambio decimal(10,2),
 MontoTotal decimal(10,2),
 FechaRegistro datetime default getdate()
);

CREATE TABLE DETALLE_VENTA(
 IdDetalleVenta int constraint PK_DETALLE_VENTA primary key identity,
 IdVenta int constraint FK_VENTA_DETALLE_VENTA foreign key references VENTA(IdVenta),
 IdProducto int constraint FK_PRODUCTO_DETALLE_VENTA foreign key references PRODUCTO(IdProducto),
 Precioventa decimal(10,2),
 Cantidad int,
 SubTotal decimal(10,2),
 FechaRegistro datetime default getdate()
);
