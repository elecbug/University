drop database if exists tododb;
create database if not exists tododb;

use tododb;

create table todo(
	id date not null,
    name char(20) not null,
    primary key(id)
);

create table todo_detail(
	id datetime not null,
    todo_id date not null,
    descrip varchar(20) not null,
    is_done boolean not null,
    primary key(id),
    foreign key(todo_id) references todo(id)
);

insert into todo
values ("23-10-10", "이인규");
insert into todo
values ("23-10-15", "이인규");

insert into todo_detail
values ("23-10-10 14:00", "23-10-10", "차량수리", true);
insert into todo_detail
values ("23-10-10 14:01", "23-10-10", "학교수업", true);
insert into todo_detail
values ("23-10-15 15:00", "23-10-15", "업체미팅", false);

select * from todo;
select * from todo_detail;