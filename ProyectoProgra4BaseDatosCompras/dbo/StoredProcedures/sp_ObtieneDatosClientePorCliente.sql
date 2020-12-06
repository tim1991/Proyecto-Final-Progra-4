/*******************************************************************************************
-- AUTHOR: Diego Matarrita Pereira
-- CREATE DATE: 11/29/2020
-- DESCRIPTION: Obtiene los datos del cliente por IdCliente
********************************************************************************************
MODIFICATION
********************************************************************************************
USER                                DATE(MM/dd/YYYY)                        DESCRIPTION
********************************************************************************************/
CREATE PROCEDURE [dbo].[sp_ObtieneDatosClientePorCliente]
	@IdCliente INT
AS

BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		SELECT IdCliente,
			   Nombre,
			   Apellido,
			   Email,
			   Telefono,
			   Direccion,
			   Contrasena
		FROM dbo.Clientes

	END TRY

	BEGIN CATCH

		THROW;

	END CATCH

END