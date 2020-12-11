
--Sample :      qry_GetB2CInvoices '2003042245451','90','20171215','20171219'

IF OBJECT_ID (N'qry_GetB2CInvoices') IS NOT NULL DROP PROCEDURE qry_GetB2CInvoices
GO
CREATE PROCEDURE qry_GetB2CInvoices  (
		  @Barcode Char(20)
		, @StoreCode  Char(4)
		, @StartDate  smalldatetime
		, @EndDate  smalldatetime
)

AS

	BEGIN TRY

			SELECT TOP 1 * 
FROM (
SELECT AlisverisID		= tbAlisveris.nAlisverisID
	, FaturaTarihi		= tbAlisveris.dteFaturaTarihi
	, FaturaNumarasi	= tbAlisveris.lFaturaNo
	, MusteriKodu		= tbMusteri.lKodu
	, AdiSoyadi			= RTRIM(LTRIM(ISNULL(tbAlisveris.sAlisverisYapanAdi,SPACE(0)))) + ' ' + RTRIM(LTRIM(ISNULL(tbAlisveris.sAlisverisYapanSoyadi,SPACE(0))))
	, FaturaTutari		= tbAlisveris.lNetTutar
	, FaturaMiktari		= tbAlisVeris.lToplamMiktar
	--, SatirMiktari		= tbStokFisiDetayi.lCikisMiktar1
	--, CollectedQty		= ISNULL(CollectedProductsDetail.CollectedQty , 0)
	, Yazdirildi		= ISNULL(CollectedProductsDetail.IsPrinted,0)
	--, IslemID			= tbStokFisiDetayi.nIslemID
	FROM tbAlisveris WITH(NOLOCK)
	INNER JOIN tbStokFisiDetayi WITH(NOLOCK) ON tbStokFisiDetayi.nAlisverisID = tbAlisveris.nAlisverisID
	INNER JOIN tbStokBarkodu WITH(NOLOCK) ON tbStokBarkodu.nStokID = tbStokFisiDetayi.nStokID AND tbStokBarkodu.sBarkod = @Barcode
	INNER JOIN tbMusteri WITH(NOLOCK) ON tbAlisVeris.nMusteriID = tbMusteri.nMusteriID
	LEFT OUTER JOIN (SELECT CollectedProductsDetail.AlisverisID 
						  , CollectedProductsDetail.IslemID 
						  , CollectedQty = SUM(CollectedProductsDetail.CollectedQty) 
						  , CollectedProductsMaster.IsPrinted
						FROM CollectedProductsMaster  WITH(NOLOCK)
						INNER JOIN  CollectedProductsDetail WITH(NOLOCK) ON CollectedProductsMaster.AlisverisID = CollectedProductsDetail.AlisverisID 
						--WHERE CollectedProductsMaster.IsCompleted = 0
						GROUP BY CollectedProductsDetail.AlisverisID  , CollectedProductsDetail.IslemID , CollectedProductsMaster.IsPrinted) AS CollectedProductsDetail
			ON CollectedProductsDetail.AlisverisID = tbStokFisiDetayi.nAlisverisID
			AND CollectedProductsDetail.IslemID = tbStokFisiDetayi.nIslemID
	WHERE tbAlisveris.sMagaza = @StoreCode
		AND tbAlisveris.dteFaturaTarihi BETWEEN @StartDate AND @EndDate
		AND tbAlisveris.nGirisCikis = 3		
		AND tbStokFisiDetayi.lCikisMiktar1 > ISNULL(CollectedProductsDetail.CollectedQty , 0)
		
) AS DATA
ORDER BY AlisverisID,FaturaTarihi
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
