
--Sample :      qry_GetB2CItemInfo '1'

IF OBJECT_ID (N'qry_GetB2CItemInfo') IS NOT NULL DROP PROCEDURE qry_GetB2CItemInfo
GO
CREATE PROCEDURE qry_GetB2CItemInfo  (
		  @Barcode Char(20)
)

AS

	BEGIN TRY

		--- ProductInformation
		 	
		SELECT	  StokKodu	 = tbStok.sKodu
				, StokAdi	 = ISNULL(tbsSinif5.sAciklama , SPACE(0))
				, RenkKodu	 = tbStok.sRenk
				, RenkAdi	 = ISNULL(tbRenk.sRenkAdi,SPACE(0))
				, Beden	 = tbStok.sBeden
			 FROM tbStok WITH(NOLOCK) 
				INNER JOIN tbStokBarkodu WITH(NOLOCK) 
					ON tbStok.nStokID = tbStokBarkodu.nStokID
					AND tbStokBarkodu.sBarkod = @Barcode
				 LEFT OUTER JOIN tbRenk  WITH(NOLOCK) 
					ON	tbStok.sRenk = tbRenk.sRenk
				 LEFT OUTER JOIN tbStokSinifi  WITH(NOLOCK)
					ON tbStok.nStokID = tbStokSinifi.nStokID
				 LEFT OUTER JOIN tbsSinif5  WITH(NOLOCK)
					ON tbStokSinifi.sSinifKodu5 = tbsSinif5.sSinifKodu
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
