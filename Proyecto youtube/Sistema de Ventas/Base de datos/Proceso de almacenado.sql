use DB_SISTEMA_VENTAS

select * from USUARIO

-- Proceso de Agregar

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

-- proceso para actualizar

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

-- proceso para eliminar

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
