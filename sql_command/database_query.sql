

create table manager
(
id int primary key IDENTITY(1,1) ,
[name] nvarchar(30),
[family_name] nvarchar(30),
[phone_number] nvarchar(30),
[email_address] nvarchar(30),
[rest_name] nvarchar(30) unique,
[account_number] nvarchar(30),
[username] nvarchar(30) unique,
[password] nvarchar(30),
is_admin bit,
[job] nvarchar(30)
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
FOREIGN KEY (rest_name) REFERENCES manager(rest_name),
 primary key ([name],meal)
)



)