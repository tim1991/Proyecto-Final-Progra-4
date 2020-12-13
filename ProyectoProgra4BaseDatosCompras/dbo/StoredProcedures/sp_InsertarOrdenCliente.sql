/*******************************************************************************************
-- AUTHOR: Diego Matarrita Pereira
-- CREATE DATE: 12/11/2020
-- DESCRIPTION: Inserta los datos de la orden del cliente
********************************************************************************************
MODIFICATION
********************************************************************************************
USER                                DATE(MM/dd/YYYY)                        DESCRIPTION
********************************************************************************************/
CREATE PROCEDURE [dbo].[sp_InsertarOrdenCliente]
	@IdCliente INT,
	@IdMetodoPago INT,
	@Total DECIMAL(18,2)
AS

BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		INSERT INTO dbo.Orden
			(IdCliente, IdMetodoPago, Total)
		VALUES (@IdCliente,@IdMetodoPago,@Total)

	END TRY

	BEGIN CATCH

	THROW;

	END CATCH

END