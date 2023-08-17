create database CapstoneProjectRegister

use CapstoneProjectRegister

create table Semester(
Id int identity(1,1) primary key not null,
Code varchar(10) not null,
StartDate date,
EndDate date,
Status bit
)

create table Topic(
Id int identity(1,1) primary key not null,
Name nvarchar(50) not null,
Description nvarchar(200),
Status bit,
SemesterId int foreign key references Semester(Id)
)

create table GroupProject(
Id int identity(1,1) primary key not null,
Name nvarchar(50) not null,
SemesterId int foreign key references Semester(Id),
TopicId int foreign key references Topic(Id),
Status bit
)

create table Student(
Id int identity(1,1) primary key not null,
Code varchar(8) not null,
Name nvarchar(50) not null,
Email varchar(50) not null,
Password varchar(50) not null, 
Gender bit,
DateOfBirth date,
Avatar varchar
)

create table StudentInGroup(
Id int identity(1,1) primary key not null,
JoinDate date,
Status bit,
Role nvarchar(20),
Description nvarchar(200),
GroupId int foreign key references GroupProject(Id),
StudentId int foreign key references Student(Id)
)

create table StudentInSemester(
Id int identity(1,1) primary key not null,
Status bit,
StudentId int foreign key references Student(Id),
SemesterId int foreign key references Semester(Id)
)

create table Lecturer(
Id int identity(1,1) primary key not null,
Code varchar(8) not null,
Name nvarchar(50) not null,
Email varchar(50) not null,
Password varchar(50) not null, 
Phone varchar(10),
Avatar varchar
)

create table TopicOfLecturer(
Id int identity(1,1) primary key not null,
isSuperLecturer bit not null,
LecturerId int foreign key references Lecturer(Id),
TopicId int foreign key references Topic(Id)
)

insert into Semester(Code, StartDate, EndDate, Status) values('Summer 23', '2023-05-09', '2023-08-31',0)
insert into Semester(Code, StartDate, EndDate, Status) values('Fall 23', '2023-09-01', '2023-12-31',0)

insert into Topic(SemesterId, Name, Description) values(1,'NearEx', 'Selling products that are about to expire but still usable')
insert into Topic(SemesterId, Name, Description) values(1,'Vovinam3D', 'Vovinam martial arts training 3d game')
insert into Topic(SemesterId, Name, Description) values(1,'UrPet', 'Pet food sales application')

insert into GroupProject(SemesterId, TopicId, Name) values(1,1,'NearEx')
insert into GroupProject(SemesterId, TopicId, Name) values(1,2,'Vovinam3DFPT')
insert into GroupProject(SemesterId, TopicId, Name) values(1,3,'LoveUrPet')

insert into Lecturer(Code,Email,Name,Phone,Password) values('FUHCM101','VanVTT10@fe.edu.vn',N'Võ Thị Thanh Vân','0987654321','abc123')
insert into Lecturer(Code,Email,Name,Phone,Password) values('FUHCM090','phuonglhk@fe.edu.vn',N'Lâm Hữu Khánh Phương','0987654322','abc123')
insert into Lecturer(Code,Email,Name,Phone,Password) values('FUHCM010','admin@fe.edu.vn',N'Admin','0987654320','abc123')

insert into TopicOfLecturer(TopicId,LecturerId,isSuperLecturer) values(2,2,1)
insert into TopicOfLecturer(TopicId,LecturerId,isSuperLecturer) values(1,2,0)
insert into TopicOfLecturer(TopicId,LecturerId,isSuperLecturer) values(3,1,1)

insert into Student(Code,Email,Name,Password) values('SE161091','tramhnb@fpt.edu.vn',N'Hồ Ngọc Bảo Trâm','abc123')
insert into Student(Code,Email,Name,Password) values('SE161068','longnb@fpt.edu.vn',N'Nguyễn Bảo Long','abc123')
insert into Student(Code,Email,Name,Password) values('SE161154','anhnn@fpt.edu.vn',N'Nguyễn Nam Anh','abc123')
insert into Student(Code,Email,Name,Password) values('SE161210','anhtm@fpt.edu.vn',N'Trần Minh Anh','abc123')

insert into StudentInSemester(StudentId,SemesterId,Status) values(1,1,0)
insert into StudentInSemester(StudentId,SemesterId,Status) values(2,1,1)
insert into StudentInSemester(StudentId,SemesterId,Status) values(3,1,0)
insert into StudentInSemester(StudentId,SemesterId,Status) values(4,1,1)

insert into StudentInGroup(StudentId,GroupId,JoinDate,Role) values(2,1,'2023-05-09','Mobile Developer')
insert into StudentInGroup(StudentId,GroupId,JoinDate,Role) values(4,3,'2023-05-09','Backend Developer')