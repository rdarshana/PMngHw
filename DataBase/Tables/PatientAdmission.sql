CREATE TABLE [dbo].[PatientAdmission] (
	[AdmissionId]			INT IDENTITY(1,1),
    [WardNo]				VARCHAR (5)   NOT NULL,
    [PatientId]				VARCHAR (20) NOT NULL,
	[AdmissionDate]			DATE  NOT NULL,
	[AdmissionStatus]		VARCHAR(10) NOT NULL,
    [AdmissionDescription]  VARCHAR (500) NULL,
	[AdmittedBy]			VARCHAR(20) NULL,
	[DischageDate]			DATE,
	[DischargeDescription]  VARCHAR (500) NULL,
	[DischargedBy]			VARCHAR (20) NULL,
	[SurgeryId]				INT,
    PRIMARY KEY CLUSTERED (AdmissionId),
	CONSTRAINT FK_AdmissionWard FOREIGN KEY (WardNo) REFERENCES [Ward] (WardNo),
	CONSTRAINT FK_AdmissionPatient FOREIGN KEY (PatientId) REFERENCES [Patient](PatientId),
	CONSTRAINT FK_AdmissionEmployeeAdmitted FOREIGN KEY (AdmittedBy) REFERENCES [Employee] (EmployeeId),
	CONSTRAINT FK_AdmissionEmployeeDischarge FOREIGN KEY (DischargedBy) REFERENCES [Employee] (EmployeeId)
);


