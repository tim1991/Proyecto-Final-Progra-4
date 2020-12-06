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
	@IdCliente INT
AS

BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		DELETE FROM dbo.Carrito
		WHERE IdCliente = @IdCliente

	END TRY

	BEGIN CATCH

		THROW;

	END CATCH

END