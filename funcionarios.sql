/*O comando create database serve para criar um DB e o default serve
para identificar o latim que vai ser utilizado no BD*/
create database dbFuncionarios
default character set utf8mb4
default collate utf8mb4_general_ci;

/*O comando use faz o banco de dados ser ativo.*/
use dbFuncionarios;

create table if not exists funcionarios(
	id int not null auto_increment primary key,
    nome varchar(100) not null,
    email varchar(100) not null,
    cpf varchar(11) not null,
    endereco varchar(200) not null
)default char set utf8mb4;