use DB_SISTEMA_VENTAS

select * from USUARIO
use DB_SISTEMA_VENTAS
/*--- PROCEDIMIENTO PARA AGREGAR USUARIO ---*/

CREATE PROC SP_REGISTRARUSUARIO(
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

go

/*----- PROCEDIMIENTO PARA ACTUALIZAR USUARIO -----*/

CREATE PROC SP_EDITARUSUARIO(
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

declare @respuesta bit
declare @mensaje varchar(500)

exec SP_EDITARUSUARIO 3,'404040','jhon jaider','Jhon@gmail','123',1,1,@Respuesta output,@Mensaje output

select @Respuesta

select @Mensaje

select * from USUARIO

/*----- PROCEDIMIENTO PARA ELIMINAR USUARIO -----*/

CREATE PROC SP_ELIMINARUSUARIO(
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

declare @respuesta bit
declare @mensaje varchar(500)

exec SP_ELIMINARUSUARIO 5,@Respuesta output,@Mensaje output

select @Respuesta

select @Mensaje


/*----- PROCEDIMIENTO PARA AGREGAR CATEGORIA ------*/

CREATE PROC SP_AGREGAR_CATEGORIA(
@Descripcion varchar(100),
@Resultado int output,
@Mensaje varchar(500) output
)
as
begin
    set @Resultado = 0
	if not exists(select * from CATEGORIA where Descripcion = @Descripcion)
	begin
	     insert into CATEGORIA(Descripcion) values (@Descripcion)
		 set @Resultado = SCOPE_IDENTITY()
	end
	else
	     set @Mensaje = 'No se puede repetir la descripcion de una categoria'
end
go
/*----- PROCEDIMIENTO PARA ACTUALIZAR CATEGORIA ------*/

CREATE PROC SP_EDITAR_CATEGORIA(
@IdCategoria int,
@Descripcion varchar(500),
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
    set @Resultado = 1
	if not exists(select * from CATEGORIA where Descripcion = @Descripcion and IdCategoria != @IdCategoria)
	begin
	   update CATEGORIA 
	   set Descripcion = @Descripcion
	   where IdCategoria = @IdCategoria
	end
	else
	begin
	    set @Resultado = 0
		set @Mensaje = 'No se puede repetir la descripcion de una categoria'
	end
end

go

/*----- PROCEDIMIENTO PARA ELIMINAR CATEGORIA ------*/

CREATE PROC SP_ELIMINAR_CATEGORIA(
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