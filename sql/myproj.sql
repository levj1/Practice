use test;

select * from INFORMATION_SCHEMA.TABLES
	WHERE table_name like '%james%'

	-- QUERY TO CREATE USERS
	create table james_users (id int identity(1,1),
	username varchar(20),
	password varchar(26),
	primary key(id)
	);

	-- INSERT QUERY 
	INSERT INTO james_users(username, password)
	values('james', 'secret');


	SELECT * FROM james_users
	where username = 'james' and password = 'secret';