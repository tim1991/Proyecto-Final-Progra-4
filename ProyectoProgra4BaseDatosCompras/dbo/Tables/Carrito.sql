CREATE TABLE [dbo].[Carrito] (
    [IdCliente]  INT NOT NULL,
    [IdProducto] INT NULL,
    [Cantidad]   INT NULL,
    CONSTRAINT [PK_Carrito] PRIMARY KEY CLUSTERED ([IdCliente] ASC),
    CONSTRAINT [FK_Carrito_Clientes] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Clientes] ([IdCliente]),
    CONSTRAINT [FK_Carrito_Producto] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Producto] ([IdProducto])
);

