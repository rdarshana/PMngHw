CREATE PROCEDURE [dbo].[GetWardById]
@WardNo varchar (6)
AS
BEGIN
	SELECT * FROM [dbo].[Ward]
	WHERE [WardNo] = @WardNo
END