CREATE TABLE [dbo].[Categoria] (
    [IdCategoria]     INT           IDENTITY (1, 1) NOT NULL,
    [NombreCategoria] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED ([IdCategoria] ASC)
);
GO