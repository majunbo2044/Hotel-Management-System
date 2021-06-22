CREATE TABLE Customer
(CustomerID nvarchar(10) primary key,
	CustomerName nvarchar(10) not null,
	CustomerSex nvarchar(2) default '男' check (CustomerSex = '男' or CustomerSex = '女'),
	CustomerIDNumber nvarchar(18) not null,
	CustomerType nvarchar(10) not null,
	CustomerPhone nvarchar(11) not null,
	CustomerCreateDate date not null,
	foreign key(CustomerType) references CustomerType(TypeName),
);

CReate table Room
(RoomID nvarchar(10) primary key,
RoomType nvarchar(10) not null,
RoomPrice float not null,
RoomState nvarchar(10) default '未入住' check(RoomState = '已入住' or RoomState = '未入住')
);

create table Worker
(WorkerID nvarchar(10) primary key,
WorkerName nvarchar(10) not null,
WorkerSex nvarchar(2)  default '男' check (WorkerSex = '男' or WorkerSex = '女') ,
WorkerIDNumber nvarchar(18) not null,
WorkerPosition nvarchar(10) not null,
WorkerPassword nvarchar(20) not null,
);

create table Manager
(ManagerID nvarchar(10) primary key,
ManagerName nvarchar(10) not null,
ManagerPassword nvarchar(20) not null,
);


create table CustomerType
(TypeName nvarchar(10) primary key,
Discount float not null,
Fine float not null,
);

create table InHistory
(InID nvarchar(10) primary key,
CustomerID nvarchar(10) not null,
CustomerType nvarchar(10) not null,
CustomerInDate date not null,
CustomerOutDate date not null,
RoomID nvarchar(10) not null,
Worker nvarchar(10) not null,
foreign key(CustomerID) references Customer(CustomerID),
foreign key(CustomerType) references CustomerType(TypeName),
foreign key(RoomID) references Room(RoomID),
foreign key(Worker) references Worker(WorkerID),
);

create table OutHistory
(OutID nvarchar(10) primary key,
CustomerID nvarchar(10) not null,
CustomerType nvarchar(10) not null,
CustomerInDate nvarchar(10) not null,
CustomerOutDate nvarchar(10) not null,
RoomID nvarchar(10) not null,
Fine float not null,
Worker nvarchar(10) not null,
foreign key(CustomerID) references Customer(CustomerID),
foreign key(CustomerType) references CustomerType(TypeName),
foreign key(RoomID) references Room(RoomID),
foreign key(Worker) references Worker(WorkerID),
);

go
create view CustomerView(客户编号,客户姓名,客户性别,客户类型,客户联系方式,办卡时间)
as
select CustomerID,CustomerName,CustomerSex,CustomerType,CustomerPhone,CustomerCreateDate from Customer
go

go
create view RoomView(房间号,房间类型,房间价格)
as
select RoomID,RoomType,RoomPrice from Room
go

go
create view InHistoryView(入住编号,客户编号,客户类型,客户入住时间,客户应退房时间,房间号)
as
select InID,CustomerID,CustomerType,CustomerInDate,CustomerOutDate,RoomID from InHistory
go

go
create view OutHistoryView(退房编号,客户编号,客户类型,客户入住时间,客户退房时间,房间号,超时罚款)
as
select OutID,CustomerID,CustomerType,CustomerInDate,CustomerOutDate,RoomID,Fine from OutHistory
go

select * from Customer where CustomerName like '张%'