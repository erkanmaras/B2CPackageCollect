
--Sample :      qry_GetB2CInvoiceDetailsForReturn '000112','Ozgur'

IF OBJECT_ID (N'qry_GetB2CInvoiceDetailsForReturn') IS NOT NULL DROP PROCEDURE qry_GetB2CInvoiceDetailsForReturn
GO
CREATE PROCEDURE qry_GetB2CInvoiceDetailsForReturn  (

		   @AlisverisID Char(20)
		 , @Kullanici Char(60)

)

AS
	BEGIN TRY
--- Fatura Detayı
			SELECT		
			   	OrderNo				 = tbAlisveris.lFaturaNo      
				, SaleType			 = 0  
				, StoreCode			 = tbAlisveris.sMagaza       
				, CustCode			 = tbMusteri.lKodu          
				, Cashier			 = tbAlisVeris.sKasiyerRumuzu           
				, SalesMan			 = tbStokFisiDetayi.sSaticiRumuzu    
				, CashRegister		 = tbAlisVeris.nKasaNo    
				, PriceType			 = tbStokFisiDetayi.sFiyatTipi    
				, ItemCode			 = tbStok.sKodu     
				, ItemPrice			 = tbStokFisiDetayi.lBrutFiyat    
				, ItemAmount		 = tbStokFisiDetayi.lCikisMiktar1
				, IslemID			 = tbStokFisiDetayi.nIslemID    
				, KDVRate			 = nKdvOrani    
				, PaymentCode		 = SPACE(0)     
				, InvoiceDate		 = CONVERT(VARCHAR(10), GETDATE(), 112) 
				, DeliveryDate		 = CONVERT(VARCHAR(10), GETDATE(), 112)   
				, UserName			 = @Kullanici    
				, sPromosyonKodu	 = SPACE(0)   
				, sPromosyonAciklama = SPACE(0)
				, PromosyonIndirim	 = SPACE(0)
				, DigerIndirim		 = tbAlisveris.lMalIskontoTutari      
			FROM tbAlisveris WITH(NOLOCK), tbStokFisiDetayi WITH(NOLOCK) , tbMusteri WITH(NOLOCK) , tbStok WITH(NOLOCK)
				WHERE tbAlisveris.nAlisverisID = tbStokFisiDetayi.nAlisverisID
					   AND tbAlisVeris.nMusteriID = tbMusteri.nMusteriID
					   AND tbStokFisiDetayi.nStokID = tbStok.nStokID
					   AND tbAlisveris.nAlisverisID = @AlisverisID

--- Odeme Detayı
		SELECT
			 PaymentType   = tbOdeme.sOdemeSekli
			,PaymentAmount = tbOdeme.lOdemeTutar
		FROM tbOdeme WITH(NOLOCK)
			WHERE nAlisverisID = @AlisverisID

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
