
use test;

GO
CREATE PROCEDURE CreateUser
	@username nvarchar(30),
	@password nvarchar(30)
AS
BEGIN

SET NOCOUNT ON;

	IF NOT EXISTS(SELECT * FROM james_users
		where username = @username and password = @password) 
		BEGIN
			INSERT INTO james_users(username, password)
			values (@username, @password)
		END
END

