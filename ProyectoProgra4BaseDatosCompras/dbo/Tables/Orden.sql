CREATE TABLE [dbo].[Orden] (
    [IdOrden]      INT             IDENTITY (1, 1) NOT NULL,
    [IdCliente]    INT             NULL,
    [IdMetodoPago] INT             NULL,
    [Total]        DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED ([IdOrden] ASC),
    CONSTRAINT [FK_Factura_Clientes] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Clientes] ([IdCliente]),
    CONSTRAINT [FK_Factura_MetodoPago] FOREIGN KEY ([IdMetodoPago]) REFERENCES [dbo].[MetodoPago] ([IdMetodoPago])
);

