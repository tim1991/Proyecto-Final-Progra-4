/*******************************************************************************************
-- AUTHOR: Diego Matarrita Pereira
-- CREATE DATE: 11/29/2020
-- DESCRIPTION: Actualiza los datos del cliente
********************************************************************************************
MODIFICATION
********************************************************************************************
USER                                DATE(MM/dd/YYYY)                        DESCRIPTION
********************************************************************************************/
CREATE PROCEDURE [dbo].[sp_ActualizarDatosCliente]
	@IdCliente	INT,
	@Nombre		VARCHAR(50),
	@Apellido	VARCHAR(50),
	@Email		VARCHAR(80),
	@Telefono	VARCHAR(30),
	@Direccion	VARCHAR(200),
	@Contrasena VARCHAR(100)
AS

BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		UPDATE dbo.Clientes
			SET Nombre		=   COALESCE(@Nombre, Nombre),
				Apellido	=   COALESCE(@Apellido, Apellido),
				Email		=   COALESCE(@Email, Email),
				Telefono	=   COALESCE(@Telefono, Telefono),
				Direccion	=	COALESCE(@Direccion, Direccion),
				Contrasena	=	COALESCE(@Contrasena, Contrasena)
		WHERE IdCliente = @IdCliente

	END TRY

	BEGIN CATCH

		THROW;

	END CATCH

END