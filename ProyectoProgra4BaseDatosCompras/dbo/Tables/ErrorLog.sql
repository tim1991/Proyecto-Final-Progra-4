CREATE TABLE [dbo].[ErrorLog] (
    [IdError]        INT           IDENTITY (1, 1) NOT NULL,
    [FechaError]     DATETIME      NULL,
	[Clase]			 VARCHAR (60)  NULL,
    [MetodoError]    VARCHAR (300) NULL,
    [ErrorReportado] VARCHAR (400) NULL,
    [LineaError]     VARCHAR (400) NULL,
    CONSTRAINT [PK_ErrorLog] PRIMARY KEY CLUSTERED ([IdError] ASC)
);
GO