USE [PntMngOpeWrd]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[EmployeeRegistration]
		@EmployeeId = N'1',
		@EmployeeType = N'Director',
		@IsNewPatient = N'false',
		@FirstName = N'Nilanka',
		@LastName = N'Harshana',
		@NIC = N'873383070V',
		@Address = N'Kelaniya',
		@MobilePhone = N'0775691122',
		@LandPhone = N'0912276340',
		@Email = N'nharshana@gmail.coms',
		@IsActive = N'true'

SELECT	'Return Value' = @return_value

GO

--INSERT INTO [dbo].Doctor(EmployeeId, FirstName,LastName,NIC,Address,MobilePhone,LandPhone,Email,IsActive,CreationDate) VALUES ('3','Rukshan','Darshana','873383070V','Kelaniya','0775691122','0912276340','rukshan.asela87@gmail.coms','true',getdate());

--INSERT INTO [dbo].Doctor(EmployeeId, FirstName,LastName,NIC,Address,MobilePhone,LandPhone,Email,IsActive,CreationDate) VALUES ('2','Rukshan','Darshana','873383070V','Kelaniya','0775691122','0912276340','rukshan.asela87@gmail.coms','true', getdate())

--UPDATE [dbo].Doctor SET FirstName ='Rukshan' ,LastName = 'Asele' ,NIC = '873383070V',Address = 'Kelaniya',MobilePhone = '0775691122',LandPhone = '0912276340',Email = 'rukshan.asela87@gmail.coms',IsActive = 'true' WHERE EmployeeId = '1'

select * from Director
