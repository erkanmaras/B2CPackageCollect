
--Sample :      qry_GetB2CInvoiceLines '011258727'

IF OBJECT_ID (N'qry_GetB2CInvoiceLines') IS NOT NULL DROP PROCEDURE qry_GetB2CInvoiceLines
GO
CREATE PROCEDURE qry_GetB2CInvoiceLines  (

		  @AlisverisID Char(20)

)

AS
	BEGIN TRY	
				 
		SELECT  AlisverisID = tbAlisveris.nAlisverisID
			  , StokID = tbStok.nStokID
			  , StokKodu = tbStok.sKodu
			  , StokAdi	 = ISNULL(tbsSinif5.sAciklama , SPACE(0))
			  , RenkKodu = tbStok.sRenk
			  , Beden = tbStok.sBeden
			  , Miktar = FLOOR(tbStokFisiDetayi.lCikisMiktar1)
			  , IslemID = tbStokFisiDetayi.nIslemID
			  , ToplananMiktar = FLOOR(SUM(ISNULL(CollectedProductsDetail.CollectedQty,0)))

			FROM tbAlisveris  WITH(NOLOCK)
				INNER JOIN tbStokFisiDetayi  WITH(NOLOCK)
					ON tbAlisveris.nAlisverisID = tbStokFisiDetayi.nAlisverisID
				INNER JOIN tbStok  WITH(NOLOCK)
					ON tbStokFisiDetayi.nStokID = tbStok.nStokID
				LEFT OUTER JOIN CollectedProductsMaster
					ON AlisverisID = tbStokFisiDetayi.nAlisverisID
				LEFT OUTER JOIN CollectedProductsDetail
					ON CollectedProductsDetail.AlisverisID = tbStokFisiDetayi.nAlisverisID  AND CollectedProductsDetail.IslemID=tbStokFisiDetayi.nIslemID
				 LEFT OUTER JOIN tbStokSinifi  WITH(NOLOCK)
					ON tbStok.nStokID = tbStokSinifi.nStokID
				 LEFT OUTER JOIN tbsSinif5  WITH(NOLOCK)
					ON tbStokSinifi.sSinifKodu5 = tbsSinif5.sSinifKodu
			WHERE tbAlisveris.nAlisverisID = @AlisverisID

		GROUP BY	tbAlisveris.nAlisverisID 
				
			   , tbStok.nStokID
			   , tbStok.sKodu
			   , tbStok.sAciklama
			   , tbStok.sRenk
			   , tbStok.sBeden
			   , tbStokFisiDetayi.lCikisMiktar1
			   , tbStokFisiDetayi.nIslemID
			   , tbsSinif5.sAciklama
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


