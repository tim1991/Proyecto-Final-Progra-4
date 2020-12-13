/*******************************************************************************************
-- AUTHOR: Diego Matarrita Pereira
-- CREATE DATE: 04/12/2020
-- DESCRIPTION: Actualiza el carrito por cliente
********************************************************************************************
MODIFICATION
********************************************************************************************
USER                                DATE(MM/dd/YYYY)                        DESCRIPTION
********************************************************************************************/
CREATE PROCEDURE [dbo].[sp_ActualizarCarritoPorCliente]
	@IdCarrito	INT,
	@IdProducto INT,
	@Cantidad	INT
AS

BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		UPDATE dbo.Carrito
			SET IdProducto = COALESCE(@IdProducto, IdProducto),
				Cantidad =   COALESCE(@Cantidad, Cantidad)
		WHERE IdCarrito = @IdCarrito

	END TRY

	BEGIN CATCH

		THROW;

	END CATCH

END