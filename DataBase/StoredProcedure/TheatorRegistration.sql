CREATE PROCEDURE [dbo].[TheatorRegistration]
	@TheatorId VARCHAR (5),
	@Description VARCHAR(200),
    @IsNewTheator VARCHAR (50),
	@IsActive VARCHAR (5)

AS
BEGIN
	IF(@IsNewTheator = 'true')
		BEGIN
			INSERT INTO [dbo].[Theator](TheatorId, Description, IsActive)
			VALUES (@TheatorId,@Description,@IsActive)
		END
	ELSE
		BEGIN
			UPDATE [dbo].[Theator]
			SET Description = @Description,IsActive = @IsActive
			WHERE TheatorId = @TheatorId
		END
END
