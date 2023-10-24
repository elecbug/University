create table table1(
	date datetime not null,
    phone char(11) not null,
    type int not null check(type >= 0 and type <= 1),
    state int not null check(state >= 0 and state <= 2),
    primary key(date)
);
    
create table table2(
	date datetime not null,
    fkdate datetime not null,
    menu char(20) not null,
    num int not null check(num >= 0),
    primary key(date),
    foreign key(fkdate) references table1(date)
);

insert into table1
values('2023-10-23 15:30:00', 01012341234, 0, 0);
insert into table1
values('2023-10-15 15:32:00', 01045674567, 1, 1);
insert into table1
values('2023-10-18 15:35:00', 01055556666, 1, 2);

insert into table2
values('2023-10-23 15:31:00', '2023-10-23 15:30:00', '짬뽕', 1);
insert into table2
values('2023-10-23 15:32:00', '2023-10-23 15:30:00', '짜장면', 1);
insert into table2
values('2023-10-23 15:33:00', '2023-10-15 15:32:00', '짬뽕', 4);
insert into table2
values('2023-10-23 15:34:00', '2023-10-15 15:32:00', '짜장면', 2);
insert into table2
values('2023-10-23 15:35:00', '2023-10-15 15:32:00', '탕수육', 1);
insert into table2
values('2023-10-23 15:36:00', '2023-10-18 15:35:00', '볶음밥', 2);


select * from table1;
select * from table2;