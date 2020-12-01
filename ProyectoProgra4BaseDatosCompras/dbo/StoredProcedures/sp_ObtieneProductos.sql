/*******************************************************************************************
-- AUTHOR: Arturo Romero Zamora
-- CREATE DATE: 11/29/2020
-- DESCRIPTION: Obtiene todos los productos
********************************************************************************************
MODIFICATION
********************************************************************************************
USER                                DATE(MM/dd/YYYY)                        DESCRIPTION
********************************************************************************************/
CREATE PROCEDURE [dbo].[sp_ObtieneProductos]
AS
BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		SELECT PR.IdProducto,
			   PR.NombreProducto,
			   PR.DescripcionProducto,
			   PR.PrecioProducto,
			   PR.ImagenProducto,
			   PR.IdCategoria
		FROM dbo.Producto PR


	END TRY

	BEGIN CATCH

	THROW;

	END CATCH

END