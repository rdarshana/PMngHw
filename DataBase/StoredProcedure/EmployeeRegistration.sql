ALTER PROCEDURE [dbo].[EmployeeRegistration]
	@EmployeeId VARCHAR (20),
	@EmployeeType VARCHAR (15),
	@IsNewPatient BIT,
	@FirstName VARCHAR (50),
	@LastName VARCHAR (50),
	@NIC CHAR (10),
	@Address VARCHAR (200),
	@MobilePhone VARCHAR (20),
	@LandPhone VARCHAR (20),
	@Email VARCHAR (100),
	@IsActive VARCHAR (8)

AS
BEGIN

DECLARE @Insertquery VARCHAR (1000);
DECLARE @UpdateQuery VARCHAR (1000);

SET @Insertquery = 'INSERT INTO [dbo].' +@EmployeeType+ '(EmployeeId, FirstName,LastName,NIC,Address,MobilePhone,LandPhone,Email,IsActive,CreationDate) 
					VALUES ('''+ @EmployeeId +''','''+ @FirstName+''','''+@LastName+''','''+@NIC +''','''+@Address +''','''+ @MobilePhone+''','''+@LandPhone +''','''+@Email +''','''+ @IsActive+''', getdate())';

SET @UpdateQuery = 'UPDATE [dbo].'+@EmployeeType+' SET FirstName ='''+ @FirstName+''' ,LastName = '''+@LastName+ ''' ,NIC = '''+@NIC+ ''',Address = '''+@Address+ ''',MobilePhone = '''+@MobilePhone+ ''',LandPhone = '''+@LandPhone+ ''',Email = '''+@Email+ ''',IsActive = '''+@IsActive+ ''' WHERE EmployeeId = '''+@EmployeeId+'''';


	IF(@IsNewPatient = 'true')
		BEGIN
			exec (@Insertquery);
			PRINT @Insertquery;
			--INSERT INTO [dbo].[Doctor](EmployeeId, FirstName,LastName,NIC,Address,MobilePhone,LandPhone,Email,IsActive,CreationDate)
			--VALUES (@EmployeeId,@FirstName,@LastName,@NIC,@Address,@MobilePhone,@LandPhone,@Email,@IsActive, getdate())
			

	END
	ELSE
		BEGIN
			exec (@UpdateQuery);
			PRINT @UpdateQuery;
			--UPDATE [dbo].[Doctor]
			--SET FirstName = @FirstName,LastName = @LastName,NIC= @NIC,Address= @Address,MobilePhone= @MobilePhone,LandPhone=@LandPhone,Email=@Email,IsActive=@IsActive
			--WHERE EmployeeId = @EmployeeId
		END
	END
