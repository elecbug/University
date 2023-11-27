drop database if exists todoDB;
create database if not exists todoDB;

use todoDB;

create table todo
(
    id date not null,    
    person_name varchar(10) not null,
    primary key(id, person_name)
);

create table todo_detail
(
    id datetime not null,
    todo_id date not null,    
    todo_person_name varchar(10) not null,
    title varchar(20) not null,
    is_done bit not null,
    primary key(id),
    foreign key(todo_id, todo_person_name) references todo(id, person_name)
);


insert into todo values('2023-10-10', '이인규');
insert into todo_detail values('2023-10-10 10:00:00', '2023-10-10', '차량수리', true);
insert into todo_detail values('2023-10-10 10:01:00', '2023-10-10', '학교방문', true);

insert into todo values('2023-10-13', '이인규');
insert into todo_detail values('2023-10-13 14:00:00', '2023-10-13', '차량수리', true);
insert into todo_detail values('2023-10-10 14:01:00', '2023-10-13', '공부', false);

insert into todo values('2023-10-18', '이인규');
insert into todo_detail values('2023-10-18 11:00:00', '2023-10-18', '쇼핑', true);

select * from todo;
select * from todo_detail;
