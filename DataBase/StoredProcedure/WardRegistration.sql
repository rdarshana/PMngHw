CREATE PROCEDURE [dbo].[WardRegistration]
	@WardNo VARCHAR (5),
	@Owner VARCHAR(20),
    @WardType VARCHAR (50),
	@NoOfBeds INTEGER,
	@IsActive VARCHAR(8),
	@IsNewWard VARCHAR(6)

AS
BEGIN
	IF(@IsNewWard = 'true')
		BEGIN
			INSERT INTO [dbo].[Ward](WardNo, Owner, WardType, NoOfBeds, IsActive)
			VALUES (@WardNo,@Owner,@WardType,@NoOfBeds,@IsActive)
		END
	ELSE
		BEGIN
			UPDATE [dbo].[Ward]
			SET Owner = @Owner, WardType = @WardType, NoOfBeds= @NoOfBeds,IsActive = @IsActive
			WHERE WardNo = @WardNo
		END
END
