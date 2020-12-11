
--Sample :      qry_CheckB2CInvoiceReturns '011258727'

IF OBJECT_ID (N'qry_CheckB2CInvoiceReturns') IS NOT NULL DROP PROCEDURE qry_CheckB2CInvoiceReturns
GO
CREATE PROCEDURE qry_CheckB2CInvoiceReturns  (

		  @AlisverisID Char(20)

)

AS
	BEGIN TRY
		
		IF EXISTS (
				 
		SELECT    AlisverisID = Satis.nAlisverisID
				, MusteriID = Satis.nMusteriID
				, NetTutar = Satis.lNetTutar
				, ToplamMiktar = Satis.lToplamMiktar
				, FaturaTarihi = Satis.dteFaturaTarihi
			  
		FROM tbAlisveris AS Satis  WITH(NOLOCK) 
				
		WHERE Satis.nAlisverisID = @AlisverisID
					AND EXISTS 
					(
						SELECT TOP 1 * FROM tbAlisveris WITH(NOLOCK)  WHERE 
						tbAlisVeris.dteFaturaTarihi >= Satis.dteFaturaTarihi
						AND ABS(tbAlisVeris.lToplamMiktar) = Satis.lToplamMiktar
						AND ABS(tbAlisveris.lNetTutar) = Satis.lNetTutar
						AND tbAlisVeris.nGirisCikis = 4
						AND tbAlisVeris.nMusteriID = Satis.nMusteriID
						AND tbAlisVeris.sMagaza = Satis.sMagaza)
					)

		SELECT HasReturn =  1

		ELSE SELECT  HasReturn =  0
		
	END TRY
	BEGIN CATCH
		IF (XACT_STATE()) <> 0 	ROLLBACK TRANSACTION;
		DECLARE @ErrorMessage	NVARCHAR(4000)
		DECLARE @ErrorSeverity	INT
		DECLARE @ErrorState		INT

		SELECT  @ErrorMessage	= ERROR_MESSAGE(),
				@ErrorSeverity	= ERROR_SEVERITY(),
				@ErrorState		= ERROR_STATE()
			
		RAISERROR (@ErrorMessage,	-- Message text
				   @ErrorSeverity,	-- Severity
				   @ErrorState		-- State  
				   )
	END CATCH	
GO


