use DB_SISTEMA_VENTAS

select * from PERMISO

update PERMISO set NombreMenu = 'Usuarios' where IdRol= 1;
update PERMISO set NombreMenu = 'Mantenedor' where IdPermiso =2;
update PERMISO set NombreMenu = 'Ventas' where IdPermiso = 3;
update PERMISO set NombreMenu = 'Compras' where IdPermiso = 4;
update PERMISO set NombreMenu = 'Clientes' where IdPermiso = 5;
update PERMISO set NombreMenu = 'Proveedores' where IdPermiso = 6;
update PERMISO set NombreMenu = 'Reportes' where IdPermiso = 7;
update PERMISO set NombreMenu = 'Acerca De' where IdPermiso = 8;

