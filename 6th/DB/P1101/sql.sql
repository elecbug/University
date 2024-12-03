drop database if exists hospitaldb;
create database if not exists hospitaldb;

use hospitaldb;

create table doctor(
	id int not null auto_increment, 
	name varchar(20) not null,
    dept varchar(20) not null,
    primary key(id)
);

insert into doctor values(0, '홍길동', '내과');
insert into doctor values(0, '김길동', '외과');

select * from doctor;


create table patient(
	id int not null auto_increment, 
	name varchar(20) not null,
    age int not null,
    primary key(id)
);

insert into patient values(0, '홍동길', 10);
insert into patient values(0, '김동길', 20);

select * from patient;


create table doctor_patient(
	id int not null auto_increment,
    doctor_id int not null,
    patient_id int not null,
    primary key(id),
    foreign key(doctor_id) references doctor(id),
    foreign key(patient_id) references patient(id)
);

insert into doctor_patient values(0, 1, 1);
insert into doctor_patient values(0, 1, 2);
insert into doctor_patient values(0, 2, 2);

select * from doctor_patient;


select * from doctor, patient, doctor_patient;
