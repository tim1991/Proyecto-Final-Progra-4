/*******************************************************************************************
-- AUTHOR: Diego Matarrita Pereira
-- CREATE DATE: 11/29/2020
-- DESCRIPTION: Inserta los datos del cliente
********************************************************************************************
MODIFICATION
********************************************************************************************
USER                                DATE(MM/dd/YYYY)                        DESCRIPTION
********************************************************************************************/
CREATE PROCEDURE [dbo].[sp_InsertarDatosCliente]
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

		INSERT INTO dbo.Clientes
			(Nombre, Apellido, Email, Telefono, Direccion, FechaCreacion, Contrasena)
		VALUES (@Nombre,@Apellido,@Email,@Telefono,@Direccion,GETDATE(),@Contrasena)

	END TRY

	BEGIN CATCH

		THROW;

	END CATCH

END

