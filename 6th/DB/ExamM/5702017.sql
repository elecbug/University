drop database if exists middle;
create database if not exists middle;

use middle;

create table middle(
	date datetime not null,
    price int not null,
    state int not null,
    primary key(date)
);

insert into middle
values ('2023-10-20 18:00:00', 5000, 0);
insert into middle
values ('2023-10-22 20:00:00', 10000, 1);
insert into middle
values ('2023-10-23 21:00:00', 20000, 1);
insert into middle
values ('2023-10-24 08:00:00', 5000, 2);
insert into middle
values ('2023-10-24 10:00:00', 10000, 2);
insert into middle
values ('2023-10-24 15:00:00', 10000, 3);
insert into middle
values ('2023-10-24 20:00:00', 20000, 4);

select * from middle;