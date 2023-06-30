

create table manager
(
id int IDENTITY(1,1) ,
[name] nvarchar(30),
[family_name] nvarchar(30),
[phone_number] nvarchar(30),
[email_address] nvarchar(30),
[rest_name] nvarchar(30) ,
[account_number] nvarchar(30),
[username] nvarchar(30) unique,
[password] nvarchar(30),
is_admin bit,
[job] nvarchar(30),
primary key ([name],[family_name],[rest_name],[job])
)


create table food
(
[name] nvarchar(20) ,
meal nvarchar(20) ,
kind nvarchar(20),
price int ,
time_prepare int ,
rest_name nvarchar(30),
image_path nvarchar(100),
score int,
primary key ([name],meal,rest_name)
)



create table employee
(
[name] nvarchar(20),
family_name nvarchar(20),
job nvarchar(20),
salary int,
phone_number nvarchar(20),
app_access bit,
image_path nvarchar(100),
rest_name nvarchar(30),
score int,
[email_address] nvarchar(30),
[account_number] nvarchar(30),
[username] nvarchar(30) unique,
[password] nvarchar(30),
primary key ([name],family_name,rest_name)
)


drop table manager