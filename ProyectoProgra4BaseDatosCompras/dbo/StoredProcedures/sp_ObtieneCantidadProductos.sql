/*******************************************************************************************
-- AUTHOR: Arturo Romero Zamora
-- CREATE DATE: 12/10/2020
-- DESCRIPTION: Obtiene la Cantidad  del producto
********************************************************************************************
MODIFICATION
********************************************************************************************
USER                                DATE(MM/dd/YYYY)                        DESCRIPTION
********************************************************************************************/
CREATE PROCEDURE [dbo].[sp_ObtieneCantidadProductos]
	@IdProducto INT
AS
BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		SELECT PR.CantidadDisponibles
		FROM dbo.Producto PR
		WHERE PR.IdProducto = @IdProducto

	END TRY

	BEGIN CATCH

		THROW;

	END CATCH

END