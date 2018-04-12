CREATE TABLE [dbo].[PatientAdmission] (
    [WardNo]       VARCHAR (5)   NOT NULL,
    [PatientId]    VARCHAR (20) NOT NULL,
	[WardType]     VARCHAR (50)  NOT NULL,
	[NoOfBeds]     INTEGER  NOT NULL,
    [IsActive]     VARCHAR (8)   NOT NULL,
    PRIMARY KEY CLUSTERED ([WardNo]),
	CONSTRAINT FK_EmployeeWardOwner FOREIGN KEY (Owner) REFERENCES Employee (EmployeeId)
);


