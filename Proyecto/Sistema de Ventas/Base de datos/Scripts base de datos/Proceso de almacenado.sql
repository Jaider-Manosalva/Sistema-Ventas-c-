use DB_SISTEMA_VENTAS

select count(*) + 1 from COMPRA
select * from DETALLE_COMPRA

/*--- PROCEDIMIENTO PARA AGREGAR USUARIO ---*/

CREATE PROCEDURE SP_REGISTRARUSUARIO(
@Documento varchar(50),
@NombreCompleto varchar(100),
@Correo varchar(50),
@Clave varchar(50),
@IdRol int,
@Estado bit,
@IdUsuarioResultado int output,
@Mensaje varchar(500) output
)
as
begin
  set @IdUsuarioResultado = 0
  set @Mensaje = ''

  if not exists(select * from USUARIO where Documento = @Documento)
  begin
      insert into usuario(Documento,NombreCompleto,Correo,Clave,IdRol,Estado)
	  values(@Documento,@NombreCompleto,@Correo,@Clave,@IdRol,@Estado)

	  set @IdUsuarioResultado = SCOPE_IDENTITY()
  end
  else
      set @Mensaje = 'El documento ya se encuentra registrado en la base de datos'
end


declare @idusuariogenerado int
declare @mensaje varchar(500)

exec SP_REGISTRARUSUARIO '505050','carlos andres','carlos@gmail','123',1,0,@idusuariogenerado output,@Mensaje output

select @idusuariogenerado

select @Mensaje

GO

/*----- PROCEDIMIENTO PARA ACTUALIZAR USUARIO -----*/

CREATE PROCEDURE SP_EDITARUSUARIO(
@IdUsuario int,
@Documento varchar(50),
@NombreCompleto varchar(100),
@Correo varchar(50),
@Clave varchar(50),
@IdRol int,
@Estado bit,
@Respuesta bit output,
@Mensaje varchar(500) output
)
as
begin
  set @Respuesta = 0
  set @Mensaje = ''

  if not exists(select * from USUARIO where Documento = @Documento and IdUsuario != @IdUsuario)
  begin
      update usuario set
	  Documento = @Documento,
	  NombreCompleto = @NombreCompleto,
	  Correo = @Correo,
	  Clave = @Clave,
	  IdRol = @IdRol,
	  Estado = @Estado
	  where IdUsuario = @IdUsuario

	  set @Respuesta = 1
  end
  else
      set @Mensaje = 'El documento ya se encuentra registrado en la base de datos'
end

GO

declare @respuesta bit
declare @mensaje varchar(500)

exec SP_EDITARUSUARIO 3,'404040','jhon jaider','Jhon@gmail','123',1,1,@Respuesta output,@Mensaje output

select @Respuesta

select @Mensaje

select * from USUARIO

/*----- PROCEDIMIENTO PARA ELIMINAR USUARIO -----*/

CREATE PROCEDURE SP_ELIMINARUSUARIO(
@IdUsuario int,
@Respuesta bit output,
@Mensaje varchar(500) output
)
as
begin
  set @Respuesta = 0
  set @Mensaje = ''
  declare @pasoreglas bit = 1;

  if exists(select * from COMPRA C
  inner join USUARIO U on U.IdUsuario = C.IdUsuario
  where u.IdUsuario = @IdUsuario
  )
  begin
      set @pasoreglas = 0;
      set @Respuesta = 0
      set @Mensaje = @Mensaje + 'No se puede eliminar porque el usuario se encuentra relacionado a una compra\n'
  end
  if exists(select * from VENTA V
  inner join USUARIO U on U.IdUsuario = V.IdUsuario
  where u.IdUsuario = @IdUsuario
  )
  begin
      set @pasoreglas = 0;
      set @Respuesta = 0
      set @Mensaje = @Mensaje +'No se puede eliminar porque el usuario se encuentra relacionado a una Venta\n'
  end
  if(@pasoreglas = 1)
  begin
     delete from USUARIO where IdUsuario = @IdUsuario
	 set @Respuesta = 1
  end
end

GO

declare @respuesta bit
declare @mensaje varchar(500)

exec SP_ELIMINARUSUARIO 5,@Respuesta output,@Mensaje output

select @Respuesta

select @Mensaje


/*----- PROCEDIMIENTO PARA AGREGAR CATEGORIA // modificado por falta de parametro------*/ 

CREATE PROCEDURE SP_AGREGAR_CATEGORIA(
@Descripcion varchar(100),
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)
as
begin
    set @Resultado = 0
	if not exists(select * from CATEGORIA where Descripcion = @Descripcion)
	begin
	     insert into CATEGORIA(Descripcion, estado) values (@Descripcion,@Estado)
		 set @Resultado = SCOPE_IDENTITY()
	end
	else
	     set @Mensaje = 'No se puede repetir la descripcion de una categoria'
end

GO

/*----- PROCEDIMIENTO PARA ACTUALIZAR CATEGORIA ------*/

Alter Procedure SP_EDITAR_CATEGORIA(
@IdCategoria int,
@Descripcion varchar(500),
@Estado bit,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
    set @Resultado = 1
	if not exists(select * from CATEGORIA where Descripcion = @Descripcion and IdCategoria != @IdCategoria)
	begin
	   update CATEGORIA 
	   set Descripcion = @Descripcion,
	       estado = @Estado
	   where IdCategoria = @IdCategoria
	end
	else
	begin
	    set @Resultado = 0
		set @Mensaje = 'No se puede repetir la descripcion de una categoria'
	end
end

GO

/*----- PROCEDIMIENTO PARA ELIMINAR CATEGORIA ------*/

CREATE PROCEDUREC SP_ELIMINAR_CATEGORIA(
@IdCategoria int,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
    set @Resultado = 1
	if not exists(
	  select * from CATEGORIA as c inner join PRODUCTO as p on p.IdCategoria = c.IdCategoria
	  where c.IdCategoria = @IdCategoria
	)
	begin
	   delete top(1) from CATEGORIA where IdCategoria = @IdCategoria
	end
	else
	begin
	    set @Resultado = 0
		set @Mensaje = 'La categoria se encuentra relacionada a un producto, por lo tanto no se puede eliminar!!'
	end
end

GO

insert into CATEGORIA(Descripcion,estado) values ('Lacteos',1)
insert into CATEGORIA(Descripcion,estado) values ('Embutidos',1)
insert into CATEGORIA(Descripcion,estado) values ('Enlatados',1)

select * from CATEGORIA

update CATEGORIA set estado = 0 where Descripcion = 'prueba2'

/*--PROCEDIMIENTO ALMACENADO PARA AGREGAR PRODUCTO --*/

CREATE PROCEDURE SP_AGREGAR_PRODUCTO(
@Codigo varchar(50),
@Nombre varchar(50),
@Descripcion varchar(50),
@IdCategoria int,
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)
AS
BEGIN
   set @Resultado = 0
   if NOT EXISTS(select * from PRODUCTO where Codigo = @Codigo)
   begin
      insert into PRODUCTO(Codigo,Nombre,Descripcion,IdCategoria,Estado) values (@Codigo,@Nombre,@Descripcion,@IdCategoria,@Estado)
	  set @Resultado = SCOPE_IDENTITY()
   end
   else
     set @Mensaje = 'Ya existe un producto con el mismo codigo' 
END

GO
/*--PROCEDIMIENTO ALMACENADO PARA EDITAR PRODUCTO --*/

CREATE PROCEDURE SP_EDITAR_PRODUCTO(
@IdProducto int,
@Codigo varchar(50),
@Nombre varchar(50),
@Descripcion varchar(50),
@IdCategoria int,
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)
AS
BEGIN
   set @Resultado = 1
   if NOT EXISTS(select * from PRODUCTO where Codigo = @Codigo and IdProducto != @IdProducto)
   begin
      update PRODUCTO set
	  Codigo = @Codigo,
	  Nombre = @Nombre,
	  Descripcion = @Descripcion,
	  IdCategoria = @IdCategoria,
	  Estado = @Estado
	  where IdProducto = @IdProducto
   end
   else
     set @Resultado = 0 
     set @Mensaje = '¡ Ya existe un producto con el mismo codigo !' 
END

GO
/*--PROCEDIMIENTO ALMACENADO PARA ELIMINAR PRODUCTO --*/

CREATE PROCEDURE SP_ELIMINAR_PRODUCTO(
@IdProducto int,
@Resultado int output,
@Mensaje varchar(500) output
)
AS
BEGIN

   set @Resultado = 0
   set @Mensaje = ''
   declare @pasoreglas bit = 1

   if exists (select * from DETALLE_COMPRA as dc 
   inner join PRODUCTO as p on p.IdProducto = dc.IdProducto
   where p.IdProducto = @IdProducto)
   begin
      set @pasoreglas = 0
	  set @Resultado = 0
	  set @Mensaje = 'No se Puede Eliminar el producto por que se encuentra relacionado a una COMPRA\n'
   end

   if exists (select * from DETALLE_VENTA as dv inner join PRODUCTO as p on p.IdProducto = dv.IdProducto where p.IdProducto = @IdProducto)
   begin
      set @pasoreglas = 0
	  set @Resultado = 0
	  set @Mensaje = 'No se Puede Eliminar el producto por que se encuentra relacionado a una VENTA\n'
   end

   if(@pasoreglas = 1)
   begin
      delete from PRODUCTO where IdProducto = @IdProducto
	  set @Resultado = 1
   end
END

GO

/*--- PROCEDIMIENTO PARA AGREGAR CLIENTE ---*/

CREATE PROC SP_REGISTRARCLIENTE(
@Documento varchar(50),
@NombreCompleto varchar(100),
@Correo varchar(50),
@Telefono varchar(50),
@Estado bit,
@IdResultado int output,
@Mensaje varchar(500) output
)
as
begin
  set @IdResultado = 0

  if not exists(select * from CLIENTE where Documento = @Documento)
  begin
      insert into CLIENTE(Documento,NombreCompleto,Correo,Telefono,Estado)
	  values(@Documento,@NombreCompleto,@Correo,@Telefono,@Estado)

	  set @IdResultado = SCOPE_IDENTITY()
  end
  else
      set @Mensaje = 'El documento ya se encuentra registrado en la base de datos'
end

GO

/*----- PROCEDIMIENTO PARA ACTUALIZAR USUARIO -----*/

CREATE PROC SP_EDITARCLIENTE(
@IdCliente int,
@Documento varchar(50),
@NombreCompleto varchar(100),
@Correo varchar(50),
@Telefono varchar(50),
@Estado bit,
@Respuesta bit output,
@Mensaje varchar(500) output
)
as
begin
  set @Respuesta = 1

  if not exists(select * from CLIENTE where Documento = @Documento and IdCliente != @IdCliente)
  begin
      update CLIENTE set
	  Documento = @Documento,
	  NombreCompleto = @NombreCompleto,
	  Correo = @Correo,
	  Telefono = @Telefono,
	  Estado = @Estado
	  where IdCliente = @IdCliente

  end
  else
      set @Respuesta = 0
      set @Mensaje = 'El documento ya se encuentra registrado en la base de datos'
end

GO

/*--- PROCEDIMIENTO PARA AGREGAR PROVEEDOR ---*/

CREATE PROC SP_REGISTRARPROVEEDOR(
@Documento varchar(50),
@RazonSocial varchar(100),
@Correo varchar(50),
@Telefono varchar(50),
@Estado bit,
@IdResultado int output,
@Mensaje varchar(500) output
)
as
begin
  set @IdResultado = 0

  if not exists(select * from PROVEEDOR where Documento = @Documento)
  begin
      insert into PROVEEDOR(Documento,RazonSocial,Correo,Telefono,Estado)
	  values(@Documento,@RazonSocial,@Correo,@Telefono,@Estado)

	  set @IdResultado = SCOPE_IDENTITY()
  end
  else
      set @Mensaje = 'El documento ya se encuentra registrado en la base de datos'
end

GO

/*----- PROCEDIMIENTO PARA ACTUALIZAR PROVEEDOR -----*/

CREATE PROC SP_EDITARPROVEEDOR(
@IdProveedor int,
@Documento varchar(50),
@NombreCompleto varchar(100),
@Correo varchar(50),
@Telefono varchar(50),
@Estado bit,
@Respuesta bit output,
@Mensaje varchar(500) output
)
as
begin
  set @Respuesta = 1

  if not exists(select * from PROVEEDOR where Documento = @Documento and IdProveedor != @IdProveedor)
  begin
      update PROVEEDOR set
	  Documento = @Documento,
	  RazonSocial = @NombreCompleto,
	  Correo = @Correo,
	  Telefono = @Telefono,
	  Estado = @Estado
	  where IdProveedor = @IdProveedor

  end
  else
      set @Respuesta = 0
      set @Mensaje = 'El documento ya se encuentra registrado en la base de datos'
end

GO

/*----- PROCEDIMIENTO PARA ELIMINAR PROVEEDOR -----*/

CREATE PROC SP_ELIMINARPROVEEDOR(
@IdProveedor int,
@Respuesta bit output,
@Mensaje varchar(500) output
)
as 
begin
    set @Respuesta = 1
	if not exists(
	   select * from PROVEEDOR as p
	   inner join COMPRA as c on p.IdProveedor = c.IdProveedor
	   where p.IdProveedor = @IdProveedor
	)
	begin
	 delete top(1) from PROVEEDOR where IdProveedor = @IdProveedor
	end
	else
	begin
	   set @Respuesta = 0
	   set @Mensaje = 'El proveedor se encuentra relacionado a una compra'
	end
end

select * from PROVEEDOR


/*----- PROCEDIMIENTO PARA REGISTRAR COMPRA -----*/

CREATE TYPE[dbo].[EDetalle_compra] AS TABLE(
  [IdProducto] int null,
  [PrecioCompra] Decimal(10,2) null,
  [PrecioVenta] Decimal(10,2) null,
  [Cantidad] int null,
  [MontoTotal] Decimal(10,2) null
)

GO

ALTER PROCEDURE SP_REGISTRARCOMPRA(
@IdUsuario int,
@IdProveedor int,
@TipoDocumento varchar(500),
@NumeroDocumento varchar(500),
@MontoTotal decimal(10,2),
@DetalleCompra [EDetalle_compra] readonly,
@resultado bit output,
@Mensaje varchar(500) output

)as
begin
    begin try

	declare @idcompra int = 0
	set @resultado = 1
	set @Mensaje = ''

	begin transaction registro

	insert into COMPRA(IdUsuario,IdProveedor,TipoDocumento,NumeroDocumento,MontoTotal)
	       values(@IdUsuario,@IdProveedor,@TipoDocumento,@NumeroDocumento,@MontoTotal)

    set @idcompra = SCOPE_IDENTITY()

	insert into DETALLE_COMPRA(IdCompra,IdProducto,PrecioCompra,Precioventa,Cantidad,MontoTotal)
	select @idcompra,IdProducto,PrecioCompra,PrecioVenta,Cantidad,MontoTotal from @DetalleCompra

	update p set p.Strock  = p.Strock + dc.Cantidad,
	             p.PrecioCompra = dc.PrecioCompra, 
				 p.Precioventa = dc.PrecioVenta 
	from PRODUCTO P 
	inner join @DetalleCompra as dc on dc.IdProducto = p.IdProducto
	commit transaction registro

	end try
	begin catch

	set @resultado = 0
	set @Mensaje = ERROR_MESSAGE()
	rollback transaction registro

	end catch

end

GO