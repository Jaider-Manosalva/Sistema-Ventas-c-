
use DB_SISTEMA_VENTAS
select * from USUARIO

select * from ROL

insert into ROL(Descripcion)
values('EMPLEADO')

insert USUARIO(Documento,NombreCompleto,Correo,Clave,IdRol,Estado)
values ('303030','Jhon','@gmail.com',123,2,1)
--values('101010','ADMIN','@gmail','123',1,1)

--select * from PERMISO

--insert into PERMISO(IdRol,NombreMenu)
--values
--(1,'MenuUsuario'),
--(1,'MenuMantenedor'),
--(1,'MenuVentas'),
--(1,'MenuCompras'),
--(1,'MenuClientes'),
--(1,'MenuProveedores'),
--(1,'MenuReportes'),
--(1,'MenuAcercade')

--insert into PERMISO(IdRol,NombreMenu)
--values
--(2,'MenuVentas'),
--(2,'MenuCompras'),
--(2,'MenuClientes'),
--(2,'MenuProveedores'),
--(2,'MenuAcercade')

select * from ROL

select p.IdRol,p.NombreMenu from PERMISO p
inner join ROL r on r.IdRol = p.IdRol
inner join USUARIO u on u.IdRol = r.IdRol
where u.IdUsuario = 1

select * from PERMISO

use DB_SISTEMA_VENTAS

select u.IdUsuario,u.Documento,u.NombreCompleto,u.Correo,u.Clave,u.Estado,r.IdRol,r.Descripcion from USUARIO u
inner join rol r on r.IdRol = u.IdRol

update USUARIO set Estado = 0 where IdUsuario = 3