USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[CheckUserExistence]    Script Date: 7/9/2016 4:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckUserExistence]
	@username nvarchar(30),
	@password nvarchar(30)
AS
BEGIN

SET NOCOUNT ON;

	IF EXISTS(SELECT * FROM james_users
		where username = @username and password = @password) 
		SELECT 'true' As UserExists
	ELSE
		SELECT 'false' AS UserExists;
	END