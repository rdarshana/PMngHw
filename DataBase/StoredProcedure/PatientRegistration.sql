CREATE PROCEDURE [dbo].[PatientRegistration]
	@PatientId VARCHAR (20),
    @FirstName VARCHAR (50),
    @LastName VARCHAR (50),
    @NIC CHAR (10),
    @Address VARCHAR (200),
    @MobilePhone VARCHAR (20),
    @LandPhone VARCHAR (20),
    @Email VARCHAR (100),
    @Gender VARCHAR (6),
    @MaritalStatus VARCHAR (9),
    @EmergencyContact VARCHAR (20),
    @DateOfBirth VARCHAR (10)

AS
BEGIN
	IF(@PatientId=NULL)
		BEGIN
			INSERT INTO [dbo].[Patient](FirstName,LastName,NIC,Address,MobilePhone,LandPhone,Email,Gender,MaritalStatus,EmergencyContact,DateOfBirth)
			VALUES (@FirstName,@LastName,@NIC,@Address,@MobilePhone,@LandPhone,@Email,@Gender,@MaritalStatus,@EmergencyContact,@DateOfBirth)
		END
	ELSE
		BEGIN
			UPDATE [dbo].[Patient]
			SET FirstName = @FirstName,LastName = @LastName,NIC= @NIC,Address= @Address,MobilePhone= @MobilePhone,LandPhone=@LandPhone,Email=@Email,Gender=@Gender,MaritalStatus=@MaritalStatus,EmergencyContact=@EmergencyContact,DateOfBirth=@DateOfBirth
			WHERE PatientId = @PatientId
		END
END
