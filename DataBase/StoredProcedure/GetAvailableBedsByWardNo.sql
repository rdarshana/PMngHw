ALTER PROCEDURE [dbo].[GetAvailableBedsByWardNo]
@selectedWard VARCHAR(5)
AS
BEGIN
DECLARE @AllBeds INTEGER;
DECLARE @ReservedBeds INTEGER;

SET @AllBeds = (SELECT NoOfBeds
	   FROM [dbo].[Ward]
	   WHERE [WardNo] = @selectedWard)

SET @ReservedBeds = (SELECT COUNT(AdmissionId)
	   FROM [dbo].[PatientAdmission]
	   WHERE [WardNo] = @selectedWard AND AdmissionStatus = 'Admitted')

SELECT (@AllBeds - @ReservedBeds) as AvailableBeds
END