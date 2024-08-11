create database cricket_club;
use cricket_club;

create table member_details(
Player_Name varchar(100) not null,
NIC varchar(50),
DOB date,
Address varchar(100),
Contact_Number varchar(20),
Email varchar(50),
Jersey_Number varchar(10) not null,
Category varchar(100),
primary key (Jersey_Number)
);

create table match_details(
Match_Id int auto_increment,
Match_Date Date,
Match_type varchar(50),
Opposite_team varchar(50),
Players varchar(10000),
Score int,
Wickets int,
Match_status varchar(20),
primary key (Match_Id)
);

create table Batsman(
Batsman_Id varchar(20) not null,
Match_date date,
Player_Name varchar(100),
Jersey_Number varchar(10),
Personal_Score int,
Opposite_team varchar(100),
Match_Id varchar(10)
);

create table Bowler(
Bowler_Id varchar(20) not null,
Match_date date,
Player_Name varchar(100),
Jersey_Number varchar(10),
Personal_Wickets int,
Opposite_team varchar(100),
Match_Id varchar(10)
);