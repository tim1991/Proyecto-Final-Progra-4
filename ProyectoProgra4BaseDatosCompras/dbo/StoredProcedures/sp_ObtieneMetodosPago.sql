/*******************************************************************************************
-- AUTHOR: Diego Matarrita Pereira
-- CREATE DATE: 12/10/2020
-- DESCRIPTION: Obtiene los metodos de pago
********************************************************************************************
MODIFICATION
********************************************************************************************
USER                                DATE(MM/dd/YYYY)                        DESCRIPTION
********************************************************************************************/
CREATE PROCEDURE [dbo].[sp_ObtieneMetodosPago]

AS
BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		SELECT IdMetodoPago,
			   NombreMetodoPAgo
		FROM dbo.MetodoPago

	END TRY

	BEGIN CATCH

		THROW;

	END CATCH

END