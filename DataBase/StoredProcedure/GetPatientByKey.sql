CREATE PROCEDURE [dbo].[GetPatientBySearchKey]
@SearchValue varchar (20),
@ColumnName varchar (20)
AS
BEGIN
DECLARE @SearchQuery VARCHAR (500);

SET @SearchQuery= 'SELECT * FROM [dbo].[Patient] WHERE ' + @ColumnName +' LIKE ' + ' ''%' + @SearchValue+'%'' ';

exec (@SearchQuery)

END