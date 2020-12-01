/*******************************************************************************************
-- AUTHOR: Diego Matarrita Pereira
-- CREATE DATE: 11/29/2020
-- DESCRIPTION: Obtiene todos los productos
********************************************************************************************
MODIFICATION
********************************************************************************************
USER                                DATE(MM/dd/YYYY)                        DESCRIPTION
********************************************************************************************/
CREATE PROCEDURE [dbo].[sp_ObtieneProductosPorCategoria]
	@IdCategoria INT
AS
BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		SELECT PR.IdProducto,
			   PR.NombreProducto,
			   PR.DescripcionProducto,
			   Pr.PrecioProducto,
			   PR.ImagenProducto,
			   PR.IdCategoria
		FROM dbo.Producto PR
		WHERE PR.IdCategoria = @IdCategoria

	END TRY

	BEGIN CATCH

	THROW;

	END CATCH

END