create database BD;

use BD;

create table login
(
	codigo int primary key auto_increment,
    usuario varchar(40),
    senha varchar(40)
);

insert into login (usuario, senha) values ('Admin', '1234567');