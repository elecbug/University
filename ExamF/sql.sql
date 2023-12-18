drop database if exists bikedb;
create database if not exists bikedb;

use bikedb;

create table bike(
	id int not null auto_increment,
    used bool not null,
    battery int not null,
    primary key(id)
);

create table member(
	id int not null auto_increment,
    name varchar(20) not null,
    primary key(id)
);

create table rental_history(
	id int not null auto_increment,
    bike_id int not null,
    member_id int not null,
    rental_time datetime not null,
    return_time datetime,
    primary key(id),
    foreign key(bike_id) references bike(id),
    foreign key(member_id) references member(id)
);

create table recharge_history(
	id int not null auto_increment,
    bike_id int not null,
    recharge_time datetime not null,
    primary key(id),
    foreign key(bike_id) references bike(id)
);

insert into bike values(0, false, 100);
insert into bike values(0, false, 80);
insert into bike values(0, true, 100);
insert into bike values(0, true, 100);

insert into member values(0, '홍길동');
insert into member values(0, '홍길순');

insert into rental_history values(0, 2, 1, '2023-12-17 22:00:00', '2023-12-17 22:01:00');
insert into rental_history values(0, 3, 2, '2023-12-17 22:00:00', null);
insert into rental_history values(0, 4, 2, '2023-12-17 22:00:00', null);

insert into recharge_history values(0, 1, '2023-12-16 21:00:00');
insert into recharge_history values(0, 4, '2023-12-17 08:00:00');
insert into recharge_history values(0, 3, '2023-12-17 08:30:00');
insert into recharge_history values(0, 1, '2023-12-17 09:00:00');
insert into recharge_history values(0, 2, '2023-12-17 09:30:00');