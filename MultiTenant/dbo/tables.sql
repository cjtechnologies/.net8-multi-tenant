--## default database, database 1, database 2
CREATE TABLE [Members] (
    Id INT NOT NULL IDENTITY(1, 1),
    Name VARCHAR(250) NOT NULL,
    Email VARCHAR(100),
    Mobile VARCHAR(50)
);
GO
--##
select * from members;
GO
--## default database
insert into Members(name, email, mobile) values ('DefaultMember','defaultl@gmail.com','9999999999');
GO
--## database 1
insert into Members(name, email, mobile) values ('Member1','email1@gmail.com','1111111111');
GO
--## database 2
insert into Members(name, email, mobile) values ('Member2','email2@gmail.com','2222222222');
GO
--##