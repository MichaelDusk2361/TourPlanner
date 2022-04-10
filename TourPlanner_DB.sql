--create database tourplannerdb;

--\c tourplannerdb

drop table if exists tours cascade;
drop table if exists logs cascade;

create table
if not exists
tours(
id uuid primary key,
name text null,
description text null,
start text null,
destination text null,
transporttype text null,
tourdistance text null,
estimatedtime text null,
imageurl text null,
version integer not null default 1);


create table
if not exists
logs(
id uuid primary key,
tourid uuid not null,
date text null,
comment text null,
difficulty integer null,
completiontime text null,
rating integer null,
version integer not null default 1,
constraint fk_logs_tours foreign key(tourid) references tours(id) on delete cascade);