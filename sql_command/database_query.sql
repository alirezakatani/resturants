

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
id int IDENTITY(1,1) ,
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


create table list
(
list_id int IDENTITY(1,1) ,
list_name nvarchar(20),
list_meal nvarchar(20),
list_date date,
rest_name nvarchar(30),
primary key([list_name],list_meal,rest_name)
)


create table list_match
(
food_name nvarchar(20),
food_meal nvarchar(20) ,
list_name nvarchar(20),
list_meal nvarchar(20) ,
rest_name nvarchar(30),
foreign key (food_name,food_meal,rest_name) references food([name],meal,rest_name),
foreign key (food_name,list_meal,rest_name) references list([list_name],list_meal,rest_name)
)


drop table manager

select * from list inner join list_match on(list_name=name and meal=list_meal) inner join food on (food_name=food.name and food_meal=food.meal and food.rest_name=list_match.rest_name)


select * from list inner join list_match on(list_name=name and meal=list_meal) right join food on (food_name=food.name and food_meal=food.meal and food.rest_name=list_match.rest_name) where list.id=2,food.rest_name='dscsdc'


select * from list inner join list_food_match on(list_name=name and meal=list_meal)





select * from food left join list_match on (food_name=food.name and food_meal=food.meal and food.rest_name=list_match.rest_name) left join list on(list_name=name and meal=list_meal)   where list.id=2 and food.rest_name='dscsdc'

