drop database if exists moviedb;
create database if not exists moviedb;

use moviedb;

create table chair(
	number int not null,
    is_used boolean not null,
    primary key(number)
);