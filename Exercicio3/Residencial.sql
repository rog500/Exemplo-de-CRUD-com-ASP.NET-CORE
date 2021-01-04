use Residencial

Create table Condominio(
Id int primary key,
Nome varchar(100),
Bairro varchar(100),
);

Create table Familia(
Id int primary key,
Nome varchar(100),
Id_Condominio int,
Apto int,
Constraint fk_CondFamilia Foreign key(Id_Condominio) References Condominio(Id)
);

Create table Morador(
Id int primary key,
Id_Familia int,
Nome varchar(100),
QuantidadeBichosEstimacao int
Constraint fk_FamiMorador Foreign Key(Id_Familia) References Familia(Id)
);

insert into Condominio(Nome,Bairro)
values('Serra Negra','Vila Nova');

insert into Condominio(Nome,Bairro)
values('Casa Branca','Moema');

insert into Condominio(Nome,Bairro)
values('Bom Recanto','Vila Guarani');

insert into Condominio(Nome,Bairro)
values('Imaré','Capuava');

insert into Condominio(Nome,Bairro)
values('Andorinha','Jardim América');

select * from Morador

--Insert Table Familia

insert into Familia(Nome,Id_Condominio,Apto)
values('Campineli',1,712);

insert into Familia(Nome,Id_Condominio,Apto)
values('Souza',1,715);

insert into Familia(Nome,Id_Condominio,Apto)
values('Gonçalvez',3,640);

insert into Familia(Nome,Id_Condominio,Apto)
values('Camargo',3,712);

insert into Familia(Nome,Id_Condominio,Apto)
values('Brito',5,507);

insert into Familia(Nome,Id_Condominio,Apto)
values('Oliveira',3,530);

insert into Familia(Nome,Id_Condominio,Apto)
values('Jovanelli',4,507);

--insert into Morador

insert into Morador(Id_Familia,Nome,QuantidadeBichosEstimacao)
values(4,'Amanda',1);

insert into Morador(Id_Familia,Nome,QuantidadeBichosEstimacao)
values(2,'Guilherme',0);

insert into Morador(Id_Familia,Nome,QuantidadeBichosEstimacao)
values(1,'Roberta',2);

insert into Morador(Id_Familia,Nome,QuantidadeBichosEstimacao)
values(1,'Ricardo',0);

insert into Morador(Id_Familia,Nome,QuantidadeBichosEstimacao)
values(3,'Giovane',1);

insert into Morador(Id_Familia,Nome,QuantidadeBichosEstimacao)
values(3,'Flavia',1);

insert into Morador(Id_Familia,Nome,QuantidadeBichosEstimacao)
values(5,'Fabiana',3);

insert into Morador(Id_Familia,Nome,QuantidadeBichosEstimacao)
values(5,'Marcio',0);

insert into Morador(Id_Familia,Nome,QuantidadeBichosEstimacao)
values(4,'Roberto',1);

insert into Morador(Id_Familia,Nome,QuantidadeBichosEstimacao)
values(6,'Marcos',4);

insert into Morador(Id_Familia,Nome,QuantidadeBichosEstimacao)
values(1,'Rafael',3);

insert into Morador(Id_Familia,Nome,QuantidadeBichosEstimacao)
values(7,'Bruna',1);

--Consulta Sql para resolução da proposta do exercício 2 Criação de Relatorio

select a.Bairro,sum(QuantidadeBichosEstimacao) as 'Bichos de Estimação' from Condominio as a join Familia
as b on a.Id=b.Id_Condominio 
join Morador c on b.Id=c.Id_Familia 
group by a.Bairro
Order By a.Bairro



