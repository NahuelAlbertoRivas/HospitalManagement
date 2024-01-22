create database Hospital
go
use Hospital
go
create table Paciente(
	id bigint Identity(0, 1) Primary Key not null, -- Notice that although some RDBMSs by default don't allow null values for ' PK ' fields, the fact is that *not that all of them* behave in the same way, so it would be a good practice to set ' not null ' even though it sounds redundant/unnecessary for some
	cedula varchar(10) not null,
	nombre varchar(50) not null,
	apellidoPaterno varchar(50) not null,
	apellidoMaterno varchar(50),
	direccion varchar(500) not null,
	celular varchar(20) not null,
	email varchar(50) not null,
	borrado bit Default 0 not null
)
-- The same concept will be applied, as in the Patient table, regarding the ' PK ' 
create table Medico(
	id bigint Identity(0, 1) Primary Key not null,
	cedula varchar(10) not null,
	nombre varchar(50) not null,
	apellidoPaterno varchar(50) not null,
	apellidoMaterno varchar(50),
	esEspecialista bit not null,
	habilitado bit Default 1 not null,
	borrado bit Default 0 not null
)

create table Ingreso(
	id bigint Identity(0, 1) not null, 
	fecha datetime not null,
	nroSala int not null,
	nroCama int not null,
	diagnostico varchar(max) not null,
	observacion varchar(max),
	borrado bit Default 0 not null,
)
alter table Ingreso drop constraint PK_Ingreso

create table Egreso(
	id bigint Identity(0, 1) not null, 
	fecha datetime not null,
	tratamiento varchar(max),
	monto decimal(18, 2) not null,
	borrado bit Default 0 not null,
	
)

/*
	Emite

	idPaciente bigint Foreign Key references Paciente(id) on delete cascade on update cascade not null,
	idMedico bigint Foreign Key references Medico(id) on delete cascade on update cascade not null,
	
	constraint PK_Ingreso Primary Key (id, idPaciente, idMedico)

	Concede

	idMedico bigint Foreign Key references Medico(id) on delete cascade on update cascade not null,
	idIngreso bigint Foreign Key references Ingreso(id) on delete cascade on update cascade not null,

	constraint PK_Egreso Primary Key (id, idMedico, idIngreso)
*/
go
insert Paciente (
	cedula, 
	nombre,
	apellidoPaterno,
	apellidoMaterno,
	direccion,
	celular,
	email) values (
	'cedula',
	'Paciente1',
	'apellidoP',
	'apellidoM',
	'dirección',
	'(+54) 12 1234 4523',
	'email'
)
go
select * from Paciente
select * from Medico
select * from Ingreso

drop table Paciente
drop table Medico
drop table Ingreso