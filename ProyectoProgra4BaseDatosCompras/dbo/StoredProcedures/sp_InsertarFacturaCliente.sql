/*******************************************************************************************
-- AUTHOR: Diego Matarrita Pereira
-- CREATE DATE: 12/11/2020
-- DESCRIPTION: Inserta los datos de la orden del cliente
********************************************************************************************
MODIFICATION
********************************************************************************************
USER                                DATE(MM/dd/YYYY)                        DESCRIPTION
********************************************************************************************/
CREATE PROCEDURE [dbo].[sp_InsertarFacturaCliente]
	@IdOrden	INT,
	@IdProducto INT,
	@Cantidad	INT,
	@Precio		DECIMAL (18,2)
AS

BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		INSERT INTO dbo.Factura
			(IdOrden, IdProducto, Cantidad, Precio, FechaFactura)
		VALUES (@IdOrden,@IdProducto,@Cantidad, @Precio, GETDATE())

	END TRY

	BEGIN CATCH

		THROW;

	END CATCH

END