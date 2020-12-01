/*******************************************************************************************
-- AUTHOR: Diego Matarrita Pereira
-- CREATE DATE: 11/29/2020
-- DESCRIPTION: Inserta los errores en errorlog
********************************************************************************************
MODIFICATION
********************************************************************************************
USER                                DATE(MM/dd/YYYY)                        DESCRIPTION
********************************************************************************************/
CREATE PROCEDURE [dbo].[sp_InsertarErrorLog]
	@MetodoError	VARCHAR(300),
	@Clase			VARCHAR(60),
	@ErrorReportado VARCHAR(400),
	@LineaError		VARCHAR(400)
AS

BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		INSERT INTO dbo.ErrorLog
			(FechaError, Clase, MetodoError, ErrorReportado, LineaError)
		VALUES (GETDATE(), @MetodoError, @Clase, @ErrorReportado, @LineaError)

	END TRY

	BEGIN CATCH

		THROW;

	END CATCH

END

