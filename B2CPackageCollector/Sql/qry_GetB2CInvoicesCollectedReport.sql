
--Sample :      qry_GetB2CInvoicesCollectedReport  '01','25/10/2016','25/10/2016'

IF OBJECT_ID (N'qry_GetB2CInvoicesCollectedReport') IS NOT NULL DROP PROCEDURE qry_GetB2CInvoicesCollectedReport
GO
CREATE PROCEDURE qry_GetB2CInvoicesCollectedReport  (
		 @StoreCode  Char(4)
		, @StartDate  smalldatetime
		, @EndDate  smalldatetime
)

AS

	BEGIN TRY

--declare @StoreCode  Char(4)
--		, @StartDate  smalldatetime
--		, @EndDate  smalldatetime

--		set @StoreCode = '01'  
--		set @StartDate='20051212'
--		set @EndDate='20171212'

	 SELECT  AlisverisID = tbAlisveris.nAlisverisID
			, FaturaTarihi = tbAlisveris.dteFaturaTarihi
			, FaturaNumarasi = tbAlisveris.lFaturaNo
			, MusteriKodu = tbMusteri.lKodu
			, AdiSoyadi = RTRIM(LTRIM(ISNULL(tbAlisveris.sAlisverisYapanAdi,SPACE(0)))) + ' ' + RTRIM(LTRIM(ISNULL(tbAlisveris.sAlisverisYapanSoyadi,SPACE(0))))
			, FaturaTutari = tbAlisveris.lNetTutar
			, StokID = tbStok.nStokID
			, StokKodu = tbStok.sKodu
			, Barkod	 = ISNULL(Barcodes.Barkod , SPACE(0))
			, StokSinifi = ISNULL(tbsSinif5.sAciklama , SPACE(0))
			, RenkKodu = tbStok.sRenk
			, Beden = tbStok.sBeden
			, Miktar =  FLOOR(tbStokFisiDetayi.lCikisMiktar1)
			, IslemID = tbStokFisiDetayi.nIslemID
			, ToplananGun = CollectedProductsDetail.LastUpdatedDate
			, Gun = DATEDIFF(DAY, tbAlisveris.dteKayitTarihi,CollectedProductsDetail.LastUpdatedDate)
			, ToplananMiktar = FLOOR(ISNULL(CollectedProductsDetail.CollectedQty , 0))
			, KalanMiktar = Miktar - ToplananMiktar 
			, Yazdirildi = CollectedProductsMaster.IsPrinted
			, Tamamlandi = CollectedProductsMaster.IsCompleted

						FROM tbAlisveris  WITH(NOLOCK)
							 INNER JOIN tbStokFisiDetayi  WITH(NOLOCK)
								ON tbAlisveris.nAlisverisID = tbStokFisiDetayi.nAlisverisID
							 INNER JOIN tbStok  WITH(NOLOCK)
								ON tbStokFisiDetayi.nStokID = tbStok.nStokID
							 LEFT OUTER JOIN tbStokSinifi  WITH(NOLOCK)
								ON tbStok.nStokID = tbStokSinifi.nStokID
								 LEFT OUTER JOIN tbsSinif5  WITH(NOLOCK)
								ON tbStokSinifi.sSinifKodu5 = tbsSinif5.sSinifKodu
							 LEFT OUTER JOIN tbMusteri  WITH(NOLOCK) 
								ON	tbAlisveris.nMusteriID = tbMusteri.nMusteriID
							 INNER JOIN CollectedProductsMaster
								ON tbAlisveris.nAlisverisID = CollectedProductsMaster.AlisverisID
							 LEFT OUTER JOIN
								 (SELECT tbStok.nStokID,MAX(tbStokBarkodu.sBarkod) as Barkod
									FROM tbStok 
									INNER JOIN tbStokBarkodu WITH(NOLOCK) 
										 ON tbStokBarkodu.nStokID = tbStok.nStokID
									 GROUP BY tbStok.nStokID 
							     ) AS Barcodes 
							   ON tbStok.nStokID = Barcodes.nStokID 
							        INNER JOIN tbStokBarkodu 
									     ON tbStokBarkodu.sBarkod = Barcodes.Barkod
							 LEFT OUTER JOIN 
								 (SELECT CollectedProductsDetail.AlisverisID 
								 	  , CollectedProductsDetail.IslemID 
								 	  , CollectedQty = SUM(CollectedProductsDetail.CollectedQty) 
								 	  , LastUpdatedDate=Max(CollectedProductsDetail.LastUpdatedDate)
								  FROM CollectedProductsMaster  WITH(NOLOCK)
								  INNER JOIN  CollectedProductsDetail WITH(NOLOCK) 
								 		ON CollectedProductsMaster.AlisverisID = CollectedProductsDetail.AlisverisID 
					 
						GROUP BY CollectedProductsDetail.AlisverisID  , CollectedProductsDetail.IslemID , CollectedProductsMaster.IsPrinted) AS CollectedProductsDetail
			ON CollectedProductsDetail.AlisverisID = tbStokFisiDetayi.nAlisverisID
			AND CollectedProductsDetail.IslemID = tbStokFisiDetayi.nIslemID

						WHERE tbAlisveris.sMagaza = @StoreCode 
							  AND tbAlisveris.dteFaturaTarihi BETWEEN @StartDate AND @EndDate
							  AND tbAlisveris.nGirisCikis=3
			 
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

 