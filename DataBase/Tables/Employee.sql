CREATE TABLE [dbo].[Employee] (
    [EmployeeId]       VARCHAR (20)  NOT NULL,
	[EmployeeType]	   VARCHAR (20)  NOT NULL,
    [FirstName]        VARCHAR (50)  NULL,
	[Password]		   VARCHAR (50)  NOT NULL,
	[UserGuid]		   VARCHAR (100) NOT NULL,
    [LastName]         VARCHAR (50)  NULL,
    [NIC]              CHAR    (10)  NULL,
    [Address]          VARCHAR (200) NULL,
    [MobilePhone]      VARCHAR (20)  NULL,
    [LandPhone]        VARCHAR (20)  NULL,
    [Email]            VARCHAR (100) NULL,
	[IsActive]		   VARCHAR (8) NULL,
	[CreationDate]	   DATE,
    PRIMARY KEY CLUSTERED ([EmployeeId] ASC)
);


