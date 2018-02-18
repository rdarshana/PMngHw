CREATE PROCEDURE [dbo].[GetEmployeeBySearchKey]
@SearchValue varchar (20),
@ColumnName varchar (20)
AS
BEGIN
DECLARE @SearchQuery VARCHAR (500);

SET @SearchQuery= 'SELECT * FROM [dbo].[Employee] WHERE ' + @ColumnName +' LIKE ' + ' ''%' + @SearchValue+'%'' ';

exec (@SearchQuery)

END