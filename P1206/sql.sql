drop database if exists cardb;
create database if not exists cardb;

use cardb;

create table maker(
	id int not null auto_increment,
	name varchar(20) not null,
    country varchar(20) not null,
    primary key(id)
);

insert into maker values(0, '현대', '한국');

create table car(
	id int not null auto_increment,
    model_name varchar(20) not null,
    maker_id int not null,
    production_date date not null,
    color varchar(20) not null,
    rental_price int not null,
	primary key(id),
    foreign key(maker_id) references maker(id)
);

insert into car values(0, '소나타', 1, '2023-01-01', '검정', 10000);
insert into car values(0, '그랜저', 1, '2023-01-01', '하양', 20000);

create table customer(
	id int not null auto_increment,
    name varchar(20) not null,
    age int not null,
	primary key(id)
);

insert into customer values(0, '홍길동', 40);

create table rental(
	id int not null auto_increment,
    car_id int not null,
    customer_id int not null,
    rental_date date not null,
    return_date date,
    primary key(id),
    foreign key(car_id) references car(id),
    foreign key(customer_id) references customer(id)
);

insert into rental values(0, 1, 1, '2023-12-05', null);