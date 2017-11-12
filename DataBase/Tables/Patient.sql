CREATE TABLE [dbo].[Patient] (
    [PatientId]        VARCHAR (20)  NOT NULL,
    [FirstName]        VARCHAR (50)  NULL,
    [LastName]         VARCHAR (50)  NULL,
    [NIC]              CHAR (10)     NULL,
    [Address]          VARCHAR (200) NULL,
    [MobilePhone]      VARCHAR (20)  NULL,
    [LandPhone]        VARCHAR (20)  NULL,
    [Email]            VARCHAR (100) NULL,
    [Gender]           VARCHAR (6)   NULL,
    [MaritalStatus]    VARCHAR (9)   NULL,
    [EmergencyContact] VARCHAR (20)  NULL,
    [DateOfBirth]      VARCHAR (10)  NULL,
    PRIMARY KEY CLUSTERED ([PatientId] ASC)
);



CREATE SEQUENCE [dbo].[Patient_Seq]  AS
INT START WITH 1
INCREMENT BY 1 ;


ALTER TABLE [dbo].[Patient]
ADD CONSTRAINT Const_Patient_Seq
DEFAULT FORMAT((NEXT VALUE FOR [dbo].[Patient_Seq]),'PAT#') FOR [PatientId];

