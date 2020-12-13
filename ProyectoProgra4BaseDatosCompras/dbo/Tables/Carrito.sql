CREATE TABLE [dbo].[Carrito] (
    [IdCarrito]  INT IDENTITY (1, 1) NOT NULL,
    [IdCliente]  INT NOT NULL,
    [IdProducto] INT NULL,
    [Cantidad]   INT NULL,
    CONSTRAINT [PK_Carrito] PRIMARY KEY CLUSTERED ([IdCarrito] ASC),
    CONSTRAINT [FK_Carrito_Clientes] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Clientes] ([IdCliente]),
    CONSTRAINT [FK_Carrito_Producto] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Producto] ([IdProducto])
);
GO