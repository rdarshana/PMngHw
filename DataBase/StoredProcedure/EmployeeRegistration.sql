﻿ALTER PROCEDURE [dbo].[EmployeeRegistration]
	@EmployeeId VARCHAR (20),
	@EmployeeType VARCHAR (15),
	@Password VARCHAR (50),
	@IsNewEmployee BIT,
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

	IF(@IsNewEmployee = 'true')
		BEGIN
			INSERT INTO [dbo].[Employee](EmployeeId, EmployeeType, Password, FirstName,LastName,NIC,Address,MobilePhone,LandPhone,Email,IsActive,CreationDate) 
					VALUES (@EmployeeId, @EmployeeType, @Password, @FirstName, @LastName, @NIC, @Address, @MobilePhone, @LandPhone, @Email, @IsActive, getdate());
	END

	ELSE
		BEGIN
			UPDATE [dbo].[Employee] SET Password = @Password, FirstName = @FirstName, EmployeeType = @EmployeeType, LastName = @LastName , NIC = @NIC, Address = @Address, MobilePhone =  @MobilePhone, LandPhone = @LandPhone, Email = @Email, IsActive = @IsActive WHERE EmployeeId = @EmployeeId;
		END
	END
