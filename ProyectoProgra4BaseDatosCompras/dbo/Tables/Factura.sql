CREATE TABLE [dbo].[Factura] (
    [IdFactura]		INT             IDENTITY (1, 1) NOT NULL,
    [IdOrden]		INT             NOT NULL,
    [IdProducto]	INT             NOT NULL,
    [Cantidad]		INT             NOT NULL,
    [Precio]		DECIMAL (18, 2) NOT NULL,
	[FechaFactura]	DATETIME2(7)  NOT NULL
    CONSTRAINT [PK_Factura_1] PRIMARY KEY CLUSTERED ([IdFactura] ASC),
    CONSTRAINT [FK_Factura_Orden] FOREIGN KEY ([IdOrden]) REFERENCES [dbo].[Orden] ([IdOrden]),
    CONSTRAINT [FK_Factura_Producto] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Producto] ([IdProducto])
);
GO