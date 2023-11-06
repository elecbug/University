drop database if exists orderdb;
create database if not exists orderdb;

use orderdb;

create table member(
	id varchar(20) not null,
    name varchar(20) not null,
    age int not null,
    address varchar(20) not null,
    primary key(id)
);

create table porder(
	id int not null auto_increment, 
	created datetime not null,
    member_id varchar(20) not null,
    primary key(id),
    foreign key(member_id) references member(id)
);

create table product(
	id int not null auto_increment,
    name varchar(20) not null,
    price int not null,
    primary key(id)
);

create table porder_detail(
	id int not null auto_increment,
    order_id int not null,
    product_id int not null,
    quantity int not null,
    primary key(id),
    foreign key(order_id) references porder(id),
    foreign key(product_id) references product(id)
);


select * from porder;
select * from porder_detail;

insert into member values("John01", "John", 10, "America");
insert into member values("John02", "John", 20, "America");
insert into member values("Lenna01", "Lenna", 10, "Korea");

insert into product values(0, "iPhone", 1000000);
insert into product values(0, "macBook", 2000000);
insert into product values(0, "Monitor", 1500000);

