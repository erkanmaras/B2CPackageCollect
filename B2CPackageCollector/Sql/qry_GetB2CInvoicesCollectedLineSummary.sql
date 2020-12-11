
--Sample :      qry_GetB2CInvoicesCollectedSummary  '01','25/10/2016','25/10/2016'

IF OBJECT_ID (N'qry_GetB2CInvoicesCollectedLineSummary') IS NOT NULL DROP PROCEDURE qry_GetB2CInvoicesCollectedLineSummary
GO
CREATE PROCEDURE qry_GetB2CInvoicesCollectedLineSummary  (
		 @StoreCode  Char(4)
		, @StartDate  smalldatetime
		, @EndDate  smalldatetime
)

AS

BEGIN TRY

 
DECLARE @completed int,@waiting int, @missing int

 SET @completed = (SELECT SUM(FLOOR(tbStokFisiDetayi.lCikisMiktar1))
						FROM tbAlisveris  WITH(NOLOCK)
							 INNER JOIN tbStokFisiDetayi  WITH(NOLOCK)
								ON tbAlisveris.nAlisverisID = tbStokFisiDetayi.nAlisverisID
							 INNER JOIN CollectedProductsMaster
								ON tbAlisveris.nAlisverisID = CollectedProductsMaster.AlisverisID
						WHERE tbAlisveris.sMagaza = @StoreCode 
							  AND tbAlisveris.dteFaturaTarihi BETWEEN @StartDate AND @EndDate
							  AND tbAlisveris.nGirisCikis=3
							  AND CollectedProductsMaster.IsCompleted=1 AND CollectedProductsMaster.CompleteType=0)

SET @waiting =(SELECT SUM(FLOOR(tbStokFisiDetayi.lCikisMiktar1))
						FROM tbAlisveris  WITH(NOLOCK)
							 INNER JOIN tbStokFisiDetayi  WITH(NOLOCK)
								ON tbAlisveris.nAlisverisID = tbStokFisiDetayi.nAlisverisID
					    WHERE tbAlisveris.nAlisverisID NOT IN(SELECT AlisverisID FROM CollectedProductsMaster WHERE AlisverisID=tbAlisveris.nAlisverisID) AND tbAlisveris.sMagaza = @StoreCode 
							  AND tbAlisveris.nGirisCikis=3
							  AND tbAlisveris.dteFaturaTarihi BETWEEN @StartDate AND @EndDate)

SET @missing=(SELECT SUM(FLOOR(tbStokFisiDetayi.lCikisMiktar1))
						FROM tbAlisveris  WITH(NOLOCK)
							 INNER JOIN tbStokFisiDetayi  WITH(NOLOCK)
								ON tbAlisveris.nAlisverisID = tbStokFisiDetayi.nAlisverisID
								 INNER JOIN CollectedProductsMaster
								ON tbAlisveris.nAlisverisID = CollectedProductsMaster.AlisverisID
						WHERE  CollectedProductsMaster.IsCompleted=0 
						AND  tbAlisveris.sMagaza = @StoreCode
						AND tbAlisveris.nGirisCikis=3
						AND tbAlisveris.dteFaturaTarihi BETWEEN @StartDate AND @EndDate)

SELECT Completed= @completed ,Waiting=@waiting , Missing=@missing
			 
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

 