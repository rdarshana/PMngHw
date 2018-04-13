CREATE PROCEDURE [dbo].[GetAllWardDataWithType]
AS
BEGIN
	SELECT CONCAT([WardNo],' - ',[WardType]) as Wards, [WardNo]
	FROM [dbo].[Ward]

END