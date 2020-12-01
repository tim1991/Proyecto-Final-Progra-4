CREATE TABLE [dbo].[Producto] (
    [IdProducto]          INT             IDENTITY (1, 1) NOT NULL,
    [NombreProducto]      VARCHAR (100)   NOT NULL,
    [DescripcionProducto] VARCHAR (200)   NOT NULL,
    [PrecioProducto]      DECIMAL (18, 2) NOT NULL,
    [ImagenProducto]      VARCHAR (MAX)   NULL,
    [IdCategoria]         INT             NOT NULL,
    CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED ([IdProducto] ASC),
    CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY ([IdCategoria]) REFERENCES [dbo].[Categoria] ([IdCategoria])
);
GO