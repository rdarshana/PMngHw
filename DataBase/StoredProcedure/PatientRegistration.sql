ALTER PROCEDURE [dbo].[PatientRegistration]
	@PatientId VARCHAR (20),
	@IsNewPatient BIT,
    @FirstName VARCHAR (50),
    @LastName VARCHAR (50),
    @NIC CHAR (10),
    @Address VARCHAR (200),
    @MobilePhone VARCHAR (20),
    @LandPhone VARCHAR (20),
    @Email VARCHAR (100),
	@BloodGroup VARCHAR (10),
    @Gender VARCHAR (6),
    @MaritalStatus VARCHAR (9),
    @EmergencyContact VARCHAR (20),
    @DateOfBirth VARCHAR (10),
	@GardianName VARCHAR (50),
	@GardianAddress VARCHAR (250)

AS
BEGIN
	IF(@IsNewPatient = 'true')
		BEGIN
			INSERT INTO [dbo].[Patient](PatientId, FirstName,LastName,NIC,Address,MobilePhone,LandPhone,Email,BloodGroup,Gender,MaritalStatus,EmergencyContact,DateOfBirth,GardianName,GardianAddress,CreationDate)
			VALUES (@PatientId,@FirstName,@LastName,@NIC,@Address,@MobilePhone,@LandPhone,@Email,@BloodGroup,@Gender,@MaritalStatus,@EmergencyContact,@DateOfBirth,@GardianName,@GardianAddress, getdate())
		END
	ELSE
		BEGIN
			UPDATE [dbo].[Patient]
			SET FirstName = @FirstName,LastName = @LastName,NIC= @NIC,Address= @Address,MobilePhone= @MobilePhone,LandPhone=@LandPhone,Email=@Email,BloodGroup=@BloodGroup,Gender=@Gender,MaritalStatus=@MaritalStatus,EmergencyContact=@EmergencyContact,DateOfBirth=@DateOfBirth,GardianName=@GardianName,GardianAddress=@GardianAddress
			WHERE PatientId = @PatientId
		END
END
