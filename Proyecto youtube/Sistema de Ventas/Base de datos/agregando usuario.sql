
select * from USUARIO

select * from ROL

insert into ROL(Descripcion)
values('ADMINISTRADOR')

insert USUARIO(Documento,NombreCompleto,Correo,Clave,IdRol,Estado)
values('101010','ADMIN','@gmail','123',1,1)