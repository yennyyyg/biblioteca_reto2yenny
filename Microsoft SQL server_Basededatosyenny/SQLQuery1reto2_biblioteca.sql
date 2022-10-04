create database DBTeam
go

use DBTeam

create table libros(
   codigo int identity,
   titulo varchar(40),
   autor varchar(30),
   editorial varchar(20),
   precio decimal(5,2),
   cantidad smallint,
   primary key(codigo)
  );
  go

  create proc pc_listar_libros
  as 
  select * from libros order by codigo
  go

  create proc pc_buscar_libros 
  @titulo varchar (40)
  as
  select codigo,titulo,autor,editorial,precio,cantidad 
  from libros
  where titulo = @titulo  
  go

  create proc pc_mantenimiento_libros
  @codigo int,
   @titulo varchar(40),
   @autor varchar(30),
   @editorial varchar(20),
   @precio decimal(5,2),
   @accion varchar (50),
   @cantidad smallint output
   as
   if(@accion = '1')
   begin
      declare @codnuevo varchar(40), @codmax varchar(40)
	  set @codmax = (select max(codigo) from libros)
	  set @codmax = isnull(@codmax, 'A0000')
	  set @codnuevo = 'A'+RIGHT(RIGHT(@codmax,4)+10001,4)
	  insert into libros(codigo,titulo,autor,editorial,precio,cantidad)
	  values(@codnuevo,@titulo,@autor,@editorial,@precio,@cantidad)
	  set @accion = 'Se genero el codigo amix' +@codnuevo
    end
else if(@accion = '2')
begin
   update libros set titulo = @titulo,autor =@autor,editorial = @editorial,precio = @precio,cantidad = @cantidad where codigo = @codigo
   set @accion = 'Se modifico el codigo' + @codigo
   end

else if (@accion = '3')
begin
  delete from libros where codigo = @codigo
  set @accion= 'Se borro el codigo' + @codigo
  end
