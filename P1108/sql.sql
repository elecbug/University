drop database if exists bookdb;
create database if not exists bookdb;

use bookdb;

create table book(
	id int not null auto_increment,
	title varchar(20) not null,
    author varchar(20) not null,
    company varchar(20) not null,
    primary key(id)
);

create table member(
	id int not null auto_increment,
	name varchar(20) not null,
    phone varchar(20) not null,
    primary key(id)
);

create table book_member(
	id int not null auto_increment,
    book_id int not null,
    member_id int not null,
    start_date date not null,
    end_date date not null,
    primary key(id),
    foreign key(book_id) references book(id),
    foreign key(member_id) references member(id)
);

insert into book values(0, "hello world", "lowercase", "program");
insert into book values(0, "Hello World", "uppercase", "program");
insert into book values(0, "hello", "lowercase", "hello");

insert into member values(0, "Nick", "010-1234-5678");
insert into member values(0, "John", "010-1234-5679");
insert into member values(0, "Hill", "010-1234-5670");
insert into member values(0, "Anna", "010-2234-5678");