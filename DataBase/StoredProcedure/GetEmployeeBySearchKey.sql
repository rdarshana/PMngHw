USE [PntMngOpeWrd]
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeBySearchKey]    Script Date: 4/21/2018 5:05:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetEmployeeBySearchKey]
@SearchValue varchar (50),
@ColumnName varchar (20)
AS
BEGIN
DECLARE @SearchQuery VARCHAR (500);

SET @SearchQuery= 'SELECT * FROM [dbo].[Employee] WHERE ' + @ColumnName +' LIKE ' + ' ''%' + @SearchValue+'%'' ';

exec (@SearchQuery)

END