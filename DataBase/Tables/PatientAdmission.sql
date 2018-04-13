CREATE TABLE [dbo].[PatientAdmission] (
	[ID] int IDENTITY(1,1),
    [WardNo]          VARCHAR (5)   NOT NULL,
    [PatientId]       VARCHAR (20) NOT NULL,
	[AdnissuinDate]   DATE  NOT NULL,
	[AdmissionStatus] VARCHAR(10)  NOT NULL,
    [Description]     VARCHAR (500)   NOT NULL,
	[]
    PRIMARY KEY CLUSTERED ([WardNo]),
	CONSTRAINT FK_EmployeeWardOwner FOREIGN KEY (Owner) REFERENCES Employee (EmployeeId)
);


