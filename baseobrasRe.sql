create database obraspublic;
use obraspublic;


create table Constructora(
	idconst int primary key identity NOT NULL,
    nombre varchar(100),
	direccion varchar(100),
	numerocon int
);

create table Proyecto(
	idProyecto int primary key identity NOT NULL,
    Nombre varchar(400),
    NumFrenteObra int,
    Descripcion varchar(400),
    FechaInicio date,
    FechaEstimadaTermino date
);


create table Proyectofrente(
	idProyectofrent int primary key identity NOT NULL,
	IDProyecto int, --Faltaba poner la llave foranea
	--CONSTRAINT para declararla dentro de la estructura 
    CONSTRAINT FK_IDProyecto foreign key(IDProyecto) references Proyecto(idProyecto),
	Nombre varchar(400),
	Descripcion varchar(400),
    FechaInicio date,
    FechaEstimadaTermino date
);

create table FrenteObra(
	idFrenteObra int primary key identity NOT NULL,
	--Declaración de FK
	idconst int,
	idProyectofrent int,
	--Validación de FK 
    CONSTRAINT FK_idconst foreign key (idconst)references constructora(idconst),
    CONSTRAINT FK_idProyectofrent foreign key (idProyectofrent) references Proyectofrente(idProyectofrent),
    Nombre varchar(200),
    Descripcion varchar(400),
    FechaInicio date,
    FechaEstimadaTermino date
);

create table RolUsuario(
	idRol int primary key identity NOT NULL,
    Nombredelrol varchar(400)
  
);
	
    

create table Usuario(
	idUsuario int primary key identity NOT NULL,
	idFrenteObra int,
	idRol int,
    CONSTRAINT FK_FrenteObra foreign key(idFrenteObra) references FrenteObra(idFrenteObra),
	CONSTRAINT FK_idRol foreign key(idRol)references RolUsuario(idRol),
	NombreUsuario varchar(100),
    pass varchar(200),
    Nombre varchar(100),
    ApellidoPaterno varchar(100),
    ApellidoMaterno varchar(100)
);

--INSERTO DATOS PARA HACER PRUEBAS EN LOGIN
INSERT INTO Usuario(NombreUsuario, pass, Nombre, ApellidoPaterno, ApellidoMaterno)
VALUES ('UserPruebas','contraseña1','Juanito','Cam','Aney')

select * from Usuario

create table Reportes(
	idReporte int primary key identity NOT NULL,
	idFrenteObra int,
	idUsuario int,
	CONSTRAINT FK_idFrenteObra foreign key(idFrenteObra) references FrenteObra(idFrenteObra),
	CONSTRAINT FK_idUsuario foreign key(idUsuario) references Usuario(idUsuario),
    Nombre varchar(400),
    archivopdf int,
    FechaRealizado date
    
);



/*******************************************/

/**AYUDA EN ESTA PARTE; No estan en la base de datos estas tablas porque hay una relación rara entre 
	idEstimacion de la tabla Estimaciones e id de la tabla Concepto**/
create table Estimaciones(
	idEstimacion int primary key identity NOT NULL,
	idFrenteObra int,
	idUsuario int, 
    CONSTRAINT FK_idFrenteObra foreign key(idFrenteObra) references FrenteObra(idFrenteObra),
	CONSTRAINT FK_idUsuario foreign key(idUsuario) references Usuario(idUsuario),
	archivo int,

);

create table Concepto(
	idReporte int primary key identity NOT NULL,
	idEstimacion int,
	foreign key(idEstimacion) references Estimaciones(idEstimacion),
);