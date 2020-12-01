CREATE TABLE [dbo].[MetodoPago] (
    [IdMetodoPago]     INT          IDENTITY (1, 1) NOT NULL,
    [NombreMetodoPAgo] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_MetodoPago] PRIMARY KEY CLUSTERED ([IdMetodoPago] ASC)
);

