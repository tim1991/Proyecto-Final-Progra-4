/*******************************************************************************************
-- AUTHOR: Diego Matarrita Pereira
-- CREATE DATE: 04/12/2020
-- DESCRIPTION: Inserta el carrito por cliente
********************************************************************************************
MODIFICATION
********************************************************************************************
USER                                DATE(MM/dd/YYYY)                        DESCRIPTION
********************************************************************************************/
CREATE PROCEDURE [dbo].[sp_InsertarCarritoPorCliente]
	@IdCliente INT,
	@IdProducto INT,
	@Cantidad INT
AS

BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		INSERT INTO dbo.Carrito
			(IdCliente, IdProducto, Cantidad)
		VALUES (@IdCliente,@IdProducto,@Cantidad)

	END TRY

	BEGIN CATCH

		THROW;

	END CATCH

END