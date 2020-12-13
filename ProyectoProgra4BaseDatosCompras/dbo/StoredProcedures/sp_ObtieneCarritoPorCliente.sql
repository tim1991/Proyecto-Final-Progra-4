/*******************************************************************************************
-- AUTHOR: Diego Matarrita Pereira
-- CREATE DATE: 04/12/2020
-- DESCRIPTION: Actualiza el carrito por cliente
********************************************************************************************
MODIFICATION
********************************************************************************************
USER                                DATE(MM/dd/YYYY)                        DESCRIPTION
********************************************************************************************/
CREATE PROCEDURE [dbo].[sp_ObtieneCarritoPorCliente]
	@IdCliente INT
AS

BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		SELECT CAR.IdCarrito,
			   CL.IdCliente,
			   CL.Nombre,
			   CL.Apellido,
			   PR.IdProducto,
			   PR.NombreProducto,
			   PR.ImagenProducto,
			   PR.DescripcionProducto,
			   PR.PrecioProducto,
			   PR.IdCategoria,
			   CAR.Cantidad,
			   PR.CantidadDisponibles
		FROM dbo.Carrito CAR      
		INNER JOIN dbo.Clientes CL
			ON CAR.IdCliente = CL.IdCliente
		INNER JOIN dbo.Producto PR
			ON CAR.IdProducto = PR.IdProducto
		WHERE CL.IdCliente = @IdCliente

	END TRY

	BEGIN CATCH

		THROW;

	END CATCH

END