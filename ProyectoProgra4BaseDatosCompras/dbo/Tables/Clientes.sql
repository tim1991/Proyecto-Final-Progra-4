CREATE TABLE [dbo].[Clientes] (
    [IdCliente]         INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]            VARCHAR (50)  NOT NULL,
    [Apellido]          VARCHAR (50)  NOT NULL,
    [Email]             VARCHAR (80)  NOT NULL,
    [Telefono]          VARCHAR (30)  NOT NULL,
    [Direccion]         VARCHAR (200) NOT NULL,
    [FechaCreacion]     DATETIME2 (7) NOT NULL,
    [FechaModificacion] DATETIME2 (7) NULL,
    [Contrasena]        VARCHAR (100) NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED ([IdCliente] ASC)
);

