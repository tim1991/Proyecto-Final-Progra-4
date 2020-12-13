/*******************************************************************************************
-- AUTHOR: Diego Matarrita Pereira
-- CREATE DATE: 04/12/2020
-- DESCRIPTION: Elimina el carrito por cliente
********************************************************************************************
MODIFICATION
********************************************************************************************
USER                                DATE(MM/dd/YYYY)                        DESCRIPTION
********************************************************************************************/
CREATE PROCEDURE [dbo].[sp_EliminarCarritoPorCliente]
	@IdCarrito INT
AS

BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		DELETE FROM dbo.Carrito
		WHERE IdCarrito = @IdCarrito

	END TRY

	BEGIN CATCH

		THROW;

	END CATCH

END