/****** Object:  StoredProcedure [dbo].[sp_NebInsertB2CReturn]    Script Date: 11.12.2017 16:56:30 ******/
IF OBJECT_ID (N'sp_InsertB2CReturnInvoices') IS NOT NULL DROP PROCEDURE sp_InsertB2CReturnInvoices
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--select * from tbAlisVeris order by dteFaturaTarihi 
-- select * from tbAlisVeris  where nAlisverisId = '1000150'
-- select * from tbStokFisiDetayi where nAlisverisId = '1000150'
-- select * from tbAVPromosyonMaster
-- select * from tbAVPromosyonIndirim
-- select * from tbAlisveris where nGirisCikis =4
-- select * from tbStokFisiDetayi  where nGirisCikis =4 and sFisTipi = 'P'
-- select tbOdeme.* from TBoDEME,tbAlisveris where nGirisCikis =4 AND TBoDEME.nAlisverisID =  tbAlisveris.nAlisverisID 

-- sp_NebInsertB2CReturn 2044,0,'010',30000,'001','0',1,'PS','010101',100,1,18,'','','','','',0,0,0,0,0,'','11/12/2017','11/12/2017','sa','','',0,0
-- sp_NebInsertB2CReturn 2045,0,'010',30000,'001','0',1,'PS','010102',100,1,18,'N','01','','','',120,80,0,0,0,'','11/12/2017','11/12/2017','sa','','',0,0


create procedure [dbo].[sp_InsertB2CReturnInvoices]( 
        @OrderNo            as numeric,      --sizin vereceginiz siparis numarası
		@SaleType           AS bit ,         --0 perakende, 1 kredili
        @StoreCode          AS char(4) ,     --magaza kodu
        @CustCode           AS numeric ,     --musteri kodu
		@Cashier            AS char(4) ,     --kasiyer kodu
		@SalesMan           AS char(4) ,     --satici rumuzu
		@CashRegister       AS numeric (4) , --kasa kodu
		@PriceType          AS char (4) ,    --KDV Dahil satildigi fiyat tipi
		@ItemCode           AS char(20) ,    --urun kodu
		@ItemPrice          AS money,        --KDV dahil, satildigi fiyat
        @ItemAmount         AS numeric,      --miktar
		@KDVRate            AS numeric,      --kdv orani
		
		@PaymentType1        AS char(4),      --odeme tipi
		@PaymentType2        AS char(4),      --odeme tipi
		@PaymentType3        AS char(4),      --odeme tipi
		@PaymentType4        AS char(4),      --odeme tipi
		@PaymentType5        AS char(4),      --odeme tipi
		
		@PaymentAmount1      as money ,        --ödeme Tutarı 1
		@PaymentAmount2      as money ,        --ödeme Tutarı 2
		@PaymentAmount3      as money ,        --ödeme Tutarı 3
		@PaymentAmount4      as money ,        --ödeme Tutarı 3
		@PaymentAmount5      as money ,        --ödeme Tutarı 3
		
		
		@PaymentCode        AS char(4),      --perakende ise '', kredili ise winnerdan 1 aylık taksit olarak acilmis odemekodu
		@InvoiceDate        AS char(10) ,    --fatura tarihi
		@DeliveryDate       AS char(10) ,    --teslim tarihi
        @UserName           AS char(60) ,    --kaydeden kullanici,
		@sPromosyonKodu     as char(20) ,    --promosyon kodu
		@sPromosyonAciklama as char(60) ,    --promosyon Aciklama
		@PromosyonIndirim   as money,        --promosyon indirim tutarı
		@DigerIndirim       as money         --diger indirim tutarı    
        ) 
AS 

        
       -- Kasiyer kontrolu
        if (select count(ltrim(rtrim(skasiyerrumuzu))) from tbkasiyer where ltrim(rtrim(skasiyerrumuzu))=@Cashier)=0 raiserror('Kasiyer Bulunamadı',16,3)
             begin
				if @@ERROR <> 0 goto ERROR_HANDLER
			 end

        -- Satici kontrolu
		if (select count(ltrim(rtrim(ssaticirumuzu))) from tbsatici where ltrim(rtrim(ssaticirumuzu))=@SalesMan)=0 raiserror('Satici Rumuzu Bulunamadı',16,3)
			 begin
			     if @@ERROR <> 0 goto ERROR_HANDLER
			 end

        -- depo kodu kontrolu
		if (select count(sdepo) from tbdepo where sdepo=@StoreCode)=0 raiserror('Depo Kodu Bulunamadı',16,3)
		    begin
			   if @@ERROR <> 0 goto ERROR_HANDLER
			end

        -- kasa kodu kontrolu
		if (select count(nkasano) from tbparekendekasa where nkasano=@CashRegister)=0 raiserror('Kasa Kodu Bulunamadı',16,3)
            begin
			   if @@ERROR <> 0 goto ERROR_HANDLER
			end

		 -- musteri kodu kontrolu
		 if @CustCode<>0
			 begin
				if (select count(lkodu) from tbmusteri where lkodu=@CustCode)=0 raiserror('Musteri Bulunamadı',16,3)
					begin
						if @@ERROR <> 0 goto ERROR_HANDLER
					end
			 end

        -- Stok kontrolu
		 if (select count(ltrim(rtrim(skodu))) from tbstok where ltrim(rtrim(skodu))=@ItemCode)=0 raiserror('Urun Bulunamadı',16,3)
             begin
			    if @@ERROR <> 0 goto ERROR_HANDLER
			 end

       -- odeme kodu kontrolu  
	   if @SaleType=1
         begin
			 if (select count(sodemekodu) from tbodemePlani where ltrim(rtrim(sodemekodu))=@PaymentCode)=0 raiserror('Odeme Kodu Bulunamadı',16,3)
			     begin
					 if @@ERROR <> 0 goto ERROR_HANDLER
				 end
		  end

		 -- odeme sekli kontrolu
		 --if (select count(ltrim(rtrim(sodemesekli))) from tbodemesekli where ltrim(rtrim(sodemesekli))=@PaymentType1)=0 raiserror('Odeme Sekli Bulunamadı 1',16,3)
   --          begin
			--    if @@ERROR <> 0 goto ERROR_HANDLER
			-- end

		 if (select count(ltrim(rtrim(sodemesekli))) from tbodemesekli where ltrim(rtrim(sodemesekli))=@PaymentType1)=0 
             begin
			    SET @PaymentType1 = ''
			 end



		 if @PaymentType2 <> '' AND (select count(ltrim(rtrim(sodemesekli))) from tbodemesekli where ltrim(rtrim(sodemesekli))=@PaymentType2)=0 raiserror('Odeme Sekli Bulunamadı 2',16,3)
             begin
			    if @@ERROR <> 0 goto ERROR_HANDLER
			 end

		 if  @PaymentType3 <> '' AND (select count(ltrim(rtrim(sodemesekli))) from tbodemesekli where ltrim(rtrim(sodemesekli))=@PaymentType3)=0 raiserror('Odeme Sekli Bulunamadı 3',16,3)
             begin
			    if @@ERROR <> 0 goto ERROR_HANDLER
			 end


		 if  @PaymentType4 <> '' AND (select count(ltrim(rtrim(sodemesekli))) from tbodemesekli where ltrim(rtrim(sodemesekli))=@PaymentType4)=0 raiserror('Odeme Sekli Bulunamadı 4',16,3)
             begin
			    if @@ERROR <> 0 goto ERROR_HANDLER
			 end


		 if  @PaymentType5 <> '' AND (select count(ltrim(rtrim(sodemesekli))) from tbodemesekli where ltrim(rtrim(sodemesekli))=@PaymentType5)=0 raiserror('Odeme Sekli Bulunamadı 5',16,3)
             begin
			    if @@ERROR <> 0 goto ERROR_HANDLER
			 end

		-- fiyattipi kontrolu
		 if (select count(ltrim(rtrim(sfiyattipi))) from tbfiyattipi where ltrim(rtrim(sfiyattipi))=@PriceType)=0 raiserror('Fiyat Tipi Bulunamadı',16,3)
             begin
				 if @@ERROR <> 0 goto ERROR_HANDLER
			 end






declare @CustID         as int
declare @ItemID         as numeric
declare @SaleID         as char(20)
declare @ReturnSaleID   as char(20)
declare @PaymentID      as char(20)
declare @PaymentNo      as numeric
declare @InstalmentID   as char(20)
declare @FirstName      AS char(60)
declare @LastName       AS char(60)
declare @ReceiptType    as char(2)
declare @AdvancePayment as numeric
declare @nIslemID       as char(20)
DECLARE @nKayitSayisi   as  numeric(10)
DECLARE @nAlisverisId   as  char(30)
DECLARE @nKdvOran       as  numeric(1)
DECLARE @lIskontoTut    as  money

-- Promosyon Kodu varmı kontrolu
     set @nKayitSayisi = 0
     select @nKayitSayisi = (select count(*) from tbAVPromosyonMaster where sPromosyonKodu = @sPromosyonKodu ) 
     if @nKayitSayisi = 0
        begin	     
         insert into tbAVPromosyonMaster  
	     values( @sPromosyonKodu, @sPromosyonAciklama , 1, 1 ,  
                               '01/01/1900' , '31/12/2048' ,  
                               1 , 1 , 1 , 1 , 0 ,  
                               0 , 0 , 1 , 0 , 1 ,  
                               0 , 0 , 0 , 0 , 0 ,  
                               0 , 0 , 0 , 0 , 999999999 , 0 , 999999999 ,  
                               '00:00:00' , '23:59:59' ,  
                               '00:00:00' , '23:59:59' , '00:00:00' , '23:59:59' ,  
                               '00:00:00' , '23:59:59' , '00:00:00' , '23:59:59' ,  
                               '00:00:00' , '23:59:59' , '00:00:00' , '23:59:59' ,  
                               1 , 1 , 0 , 0 , 999999999 ,  
                               1 , 1 , 0 , 0 ,  
                               '' , 0 , 0 , 0 ,  
                               '' , '' , '' , '' , '' , '' , '' ,  
                               0 , 0 , 0 , 0 , 0 , 0 , 0 , '' , '' , ''  )	     
		end		
---


set @ItemID=( select nStokID from tbstok  where skodu=@ItemCode)
set @ReturnSaleID='0'
set @CustID=   ( select nmusteriID from tbmusteri where lkodu=@CustCode)
set @FirstName=( select sadi from tbmusteri where lkodu=@CustCode)
set @LastName=( select ssoyadi from tbmusteri where lkodu=@CustCode)
set @FirstName=(select sadi from tbmusteri where lkodu=@CustCode)
set @LastName=(select ssoyadi from tbmusteri where lkodu=@CustCode)
set @SaleID=ltrim(rtrim(@StoreCode))+ltrim(rtrim(@SaleID))
set @PaymentID=ltrim(rtrim(@StoreCode))+ltrim(rtrim(@PaymentID))
set @KDVRate = ( select tbKdv.nKdvOrani from tbStok,tbKdv where tbStok.sKdvTipi = tbKdv.sKdvTipi and sKodu = @ItemCode )
set @lIskontoTut =@PromosyonIndirim + @DigerIndirim 

		if @SaleType=0 
			begin 
			set @ReceiptType='P'
            set @AdvancePayment=(@ItemAmount*@ItemPrice - @lIskontoTut)
			end
		else
			begin
			set @ReceiptType='K'
			set @AdvancePayment=0
			end 
			
     set @nKayitSayisi = 0

     select @nKayitSayisi = (  
	           select count(*) from tbAlisveris
			   where dteFaturatarihi = @InvoiceDate
			   and sFisTipi = 'P'
			   and nGirisCikis = 4
			   and lFaturaNo =  @OrderNo
			   and sMagaza = @StoreCode 
			)  

        if @nKayitSayisi = 0
        begin
				
					BEGIN TRANSACTION
								SET TRANSACTION ISOLATION LEVEL READ COMMITTED
								update 	tbStokSiraNo set nSonId = nSonId + 1 where nSiraIndex =1
								update tbavsirano set nSonID=nsonID+1 	where sdepo=@StoreCode	and nSiraIndex=1
								
								update tbstokfisnolar set lOdemeNo1=lOdemeNo1+1 where sdepo=@StoreCode
					            
								set @nIslemId =(select nSonId    from tbStokSiraNo   where nSiraIndex =1)                    
								set @SaleID   =(select nSonID    from tbAVSiraNo     where sdepo=@StoreCode and nSiraIndex=1)
								
								
								set @PaymentNo=(select lodemeno1 from tbstokfisnolar where sdepo=@StoreCode)
								
								

								SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
					    

						INSERT INTO tbAlisVeris
									 (nalisverisID,sfistipi,dtefaturatarihi,ngiriscikis,lfaturano,nmusteriID,
									  smagaza,skasiyerrumuzu,salisverisyapanadi,salisverisyapansoyadi,
									  ltoplammiktar,lmalbedeli,lmalIskontotutari,ndipIskontoyuzdesi,
									  ldipIskontotutari,
									  nkdvorani1,lkdvmatrahi1,lkdv1,
									  nkdvorani2,lkdvmatrahi2,lkdv2,
									  nkdvorani3,lkdvmatrahi3,lkdv3,
									  nkdvorani4,lkdvmatrahi4,lkdv4,
									  nkdvorani5,lkdvmatrahi5,lkdv5,
									  lpesinat,nvadefarkiyuzdesi,nvadekdvorani,
									  lvadekdvmatrahi,lvadekdv,lvadefarki,
									  sodemekodu,lnettutar,sharekettipi,bmuhasebeyeIslendimi,
									  nkasano,skullaniciadi,dteKayittarihi,syaziIle)
										  
						VALUES   (@SaleID,@ReceiptType,@InvoiceDate,4,@OrderNo,@CustID,@StoreCode,
											@Cashier,@FirstName,@LastName
											,@ItemAmount * -1,
											(@ItemAmount*@ItemPrice) * -1,
											@lIskontoTut * -1,
											0,
											0,
											@KDVRate,
											(@ItemAmount*@ItemPrice - @lIskontoTut)/(1+(@KDVRate/100)) * -1,
											((@ItemAmount*@ItemPrice - @lIskontoTut)-(@ItemAmount*@ItemPrice - @lIskontoTut)/(1+(@KDVRate/100))) * -1,0,0
											,0,0,0,0,0,0,0,0,0,0,@AdvancePayment,0,0
											,0,0,0,@PaymentCode,(@ItemAmount*@ItemPrice - @lIskontoTut) * -1,'',0,@CashRegister,@UserName,getdate(),'')

					-- Stok Hareket Isle

						 INSERT INTO tbStokFisiDetayi
										(nIslemId,nStokID,dteIslemTarihi,nFirmaId,nMusteriId,sFisTipi,
										 dteFisTarihi,lFisNo,nGirisCikis,sDepo,
										 lReyonFisNo,sStokIslem,sKasiyerRumuzu, sSaticiRumuzu, sOdemeKodu,
										 dteIrsaliyeTarihi,lIrsaliyeNo,lGirisMiktar1,lGirisMiktar2, lGirisFiyat,lGirisTutar,
										 lCikisMiktar1,lCikisMiktar2,lCikisFiyat,lCikisTutar,
										 sFiyatTipi,lBrutFiyat,lBrutTutar,
										 lMaliyetFiyat,lMaliyetTutar,nIskontoYuzdesi,lIskontoTutari,
										 sDovizCinsi,lDovizFiyat,
										 nSiparisID,nReceteNo,nTransferId,sTransferDepo,
										 nKdvOrani,sAciklama,sHareketTipi,
										 bMuhasebeyeIslendimi, sKullaniciAdi,dteKayitTarihi,
										 sDovizCinsi1, lDovizMiktari1, lDovizKuru1,
										 sDovizCinsi2, lDovizMiktari2, lDovizKuru2,
										 nOTVOrani,nTransferFirmaId,nAlisverisId,nStokFisiID,nIrsaliyeFisiID,
										 sMasrafYontemi,sHangiUygulama,nEkSaha1,nEkSaha2,bEkSoru1,bEkSoru2,
										 sSonKullaniciAdi, dteSonUpdateTarihi )
									
						values
						 ( @nIslemId,@ItemID,@InvoiceDate,0,@CustID,'P',
								   @InvoiceDate,@OrderNo,'4',@StoreCode,
								   0,'P',@Cashier,@SalesMan,@PaymentCode,
								   @InvoiceDate,0,0,0,0,0,
								   @ItemAmount *-1,0,
								   round(@ItemPrice/(1+(@KDVRate/100)),4)*-1,
								   (((@ItemAmount*@ItemPrice - @lIskontoTut)/(1+(@KDVRate/100)))*-1),
								   @PriceType,
								   @ItemPrice *-1,
								   (@ItemPrice * @ItemAmount)*-1 ,
								   0,0,0,@lIskontoTut*-1,
								   '',0,
								   null,0,null,null,
								   @KDVRate,'','',
								   0,@UserName,getdate(),
								   '',0,0,
								   '',0,0,
								   0,null,@SaleID,null,null,
								   '','',0,0,0,0,
								   @UserName,getdate() )

						 if @SaleType=0
							 begin
									-- Odeme Isle
									
								if @PaymentType1 <> '' and @PaymentAmount1 <> 0
								 begin 	
		
									update tbavsirano set nSonID=nsonID+1 	where sdepo=@StoreCode	and nSiraIndex=2
									set @PaymentID=(select nSonID    from tbAVSiraNo     where sdepo=@StoreCode and nSiraIndex=2)
									-- (@ItemAmount*@ItemPrice - @lIskontoTut) *-1		
									INSERT INTO tbOdeme
												(nOdemeID, nAlisverisID, sOdemeSekli, nOdemeKodu, sKasiyerRumuzu, dteOdemeTarihi, dteValorTarihi, lOdemeTutar, sDovizCinsi, lDovizTutar, 
												 lMakbuzNo, lOdemeNo, nTaksitID, nIadeAlisverisID, bMuhasebeyeIslendimi, nKasaNo, sKartNo, sKullaniciAdi, dteKayitTarihi, sMagaza)
									VALUES   (@PaymentID,@SaleID,@PaymentType1,1,@Cashier,@InvoiceDate,@InvoiceDate,@PaymentAmount1 ,'',0
													 ,@PaymentNo,@PaymentNo,0,0,0,@CashRegister,'',@UserName,getdate(),@StoreCode)
								end 													 

								if @PaymentType2 <> '' and @PaymentAmount2 <> 0
								 begin 	
		
									update tbavsirano set nSonID=nsonID+1 	where sdepo=@StoreCode	and nSiraIndex=2
									set @PaymentID=(select nSonID    from tbAVSiraNo     where sdepo=@StoreCode and nSiraIndex=2)
									-- (@ItemAmount*@ItemPrice - @lIskontoTut) *-1		
									INSERT INTO tbOdeme
												(nOdemeID, nAlisverisID, sOdemeSekli, nOdemeKodu, sKasiyerRumuzu, dteOdemeTarihi, dteValorTarihi, lOdemeTutar, sDovizCinsi, lDovizTutar, 
												 lMakbuzNo, lOdemeNo, nTaksitID, nIadeAlisverisID, bMuhasebeyeIslendimi, nKasaNo, sKartNo, sKullaniciAdi, dteKayitTarihi, sMagaza)
									VALUES   (@PaymentID,@SaleID,@PaymentType2,1,@Cashier,@InvoiceDate,@InvoiceDate,@PaymentAmount2 ,'',0
													 ,@PaymentNo,@PaymentNo,0,0,0,@CashRegister,'',@UserName,getdate(),@StoreCode)
								end 

								if @PaymentType3 <> '' and @PaymentAmount3 <> 0
								 begin 	
		
									update tbavsirano set nSonID=nsonID+1 	where sdepo=@StoreCode	and nSiraIndex=2
									set @PaymentID=(select nSonID    from tbAVSiraNo     where sdepo=@StoreCode and nSiraIndex=2)
									-- (@ItemAmount*@ItemPrice - @lIskontoTut) *-1		
									INSERT INTO tbOdeme
												(nOdemeID, nAlisverisID, sOdemeSekli, nOdemeKodu, sKasiyerRumuzu, dteOdemeTarihi, dteValorTarihi, lOdemeTutar, sDovizCinsi, lDovizTutar, 
												 lMakbuzNo, lOdemeNo, nTaksitID, nIadeAlisverisID, bMuhasebeyeIslendimi, nKasaNo, sKartNo, sKullaniciAdi, dteKayitTarihi, sMagaza)
									VALUES   (@PaymentID,@SaleID,@PaymentType3,1,@Cashier,@InvoiceDate,@InvoiceDate,@PaymentAmount3 ,'',0
													 ,@PaymentNo,@PaymentNo,0,0,0,@CashRegister,'',@UserName,getdate(),@StoreCode)
								end 								

								if @PaymentType4 <> '' and @PaymentAmount4 <> 0
								 begin 	
		
									update tbavsirano set nSonID=nsonID+1 	where sdepo=@StoreCode	and nSiraIndex=2
									set @PaymentID=(select nSonID    from tbAVSiraNo     where sdepo=@StoreCode and nSiraIndex=2)
									-- (@ItemAmount*@ItemPrice - @lIskontoTut) *-1		
									INSERT INTO tbOdeme
												(nOdemeID, nAlisverisID, sOdemeSekli, nOdemeKodu, sKasiyerRumuzu, dteOdemeTarihi, dteValorTarihi, lOdemeTutar, sDovizCinsi, lDovizTutar, 
												 lMakbuzNo, lOdemeNo, nTaksitID, nIadeAlisverisID, bMuhasebeyeIslendimi, nKasaNo, sKartNo, sKullaniciAdi, dteKayitTarihi, sMagaza)
									VALUES   (@PaymentID,@SaleID,@PaymentType4,1,@Cashier,@InvoiceDate,@InvoiceDate,@PaymentAmount4 ,'',0
													 ,@PaymentNo,@PaymentNo,0,0,0,@CashRegister,'',@UserName,getdate(),@StoreCode)
								end 								
																						  

								if @PaymentType5 <> '' and @PaymentAmount5 <> 0
								 begin 	
		
									update tbavsirano set nSonID=nsonID+1 	where sdepo=@StoreCode	and nSiraIndex=2
									set @PaymentID=(select nSonID    from tbAVSiraNo     where sdepo=@StoreCode and nSiraIndex=2)
									-- (@ItemAmount*@ItemPrice - @lIskontoTut) *-1		
									INSERT INTO tbOdeme
												(nOdemeID, nAlisverisID, sOdemeSekli, nOdemeKodu, sKasiyerRumuzu, dteOdemeTarihi, dteValorTarihi, lOdemeTutar, sDovizCinsi, lDovizTutar, 
												 lMakbuzNo, lOdemeNo, nTaksitID, nIadeAlisverisID, bMuhasebeyeIslendimi, nKasaNo, sKartNo, sKullaniciAdi, dteKayitTarihi, sMagaza)
									VALUES   (@PaymentID,@SaleID,@PaymentType5,1,@Cashier,@InvoiceDate,@InvoiceDate,@PaymentAmount5 ,'',0
													 ,@PaymentNo,@PaymentNo,0,0,0,@CashRegister,'',@UserName,getdate(),@StoreCode)
								end 								

					              
							  end

						if @PromosyonIndirim <> 0 
							begin							
								 INSERT INTO tbAVPromosyonIndirim 
												(nAlisverisID, sPromosyonKodu, nStokID , lIndirimTutari , nStokIslemID , nAlisverisSiparisID , nOdemeID )
								 VALUES   (@SaleID,@sPromosyonKodu,@ItemID,@PromosyonIndirim * -1,@nIslemId,NULL,'')
							end 


						 
						 

					COMMIT TRANSACTION
	       end 



        if @nKayitSayisi <> 0
        begin
        
            select @nAlisverisId = (  
				select max(nAlisverisId) from tbAlisveris
				where dteFaturatarihi = @InvoiceDate
				and sFisTipi = 'P'
				and nGirisCikis = 4
				and lFaturaNo =  @OrderNo
				and sMagaza = @StoreCode )  
				


				
				
            select @nKdvOran = (  
				select 
				Tip = case when @KDVRate = nKdvOrani1 or nKdvOrani1 = 0 then 1 
		                   when @KDVRate = nKdvOrani2 or nKdvOrani2 = 0 then 2 	
		                   when @KDVRate = nKdvOrani3 or nKdvOrani3 = 0 then 3 
   		                   when @KDVRate = nKdvOrani4 or nKdvOrani4 = 0 then 4 
		                   when @KDVRate = nKdvOrani5 or nKdvOrani5 = 0 then 5 else	6 end
				from tbAlisveris
				where dteFaturatarihi = @InvoiceDate
				and sFisTipi = 'P'
				and nGirisCikis = 4
				and lFaturaNo =  @OrderNo
				and sMagaza = @StoreCode )          
				
					BEGIN TRANSACTION
								SET TRANSACTION ISOLATION LEVEL READ COMMITTED
								update tbStokSiraNo set nSonId = nSonId + 1 where nSiraIndex =1
					            
								set @nIslemId =(select nSonId  from tbStokSiraNo where nSiraIndex =1)                    

								SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
					    
											   
                       if @nKdvOran = 1
                       begin
						update tbAlisVeris set ltoplammiktar = ltoplammiktar + ( @ItemAmount *-1 ),
											   lmalbedeli    = lmalbedeli +((@ItemAmount*@ItemPrice - @lIskontoTut  ) *-1),
											   lkdvmatrahi1  = lkdvmatrahi1 +(((@ItemAmount*@ItemPrice - @lIskontoTut )/(1+(@KDVRate/100))) *-1),
											   lkdv1         = lkdv1+(((@ItemAmount*@ItemPrice - @lIskontoTut )-(@ItemAmount*@ItemPrice - @lIskontoTut )/(1+(@KDVRate/100))) * -1),
											   nKdvOrani1    = @KDVRate,
											   lnettutar     = lnettutar + ((@ItemAmount*@ItemPrice - @lIskontoTut ) *-1)
											   where nAlisverisId = @nAlisverisId
                       
                       end


						
                       if @nKdvOran = 2
                       begin
						update tbAlisVeris set ltoplammiktar = ltoplammiktar + (@ItemAmount *-1),
											   lmalbedeli    = lmalbedeli +((@ItemAmount*@ItemPrice - @lIskontoTut )*-1),
											   lkdvmatrahi2  = lkdvmatrahi2 +(((@ItemAmount*@ItemPrice - @lIskontoTut )/(1+(@KDVRate/100)))*-1),
											   lkdv2         = lkdv2+(((@ItemAmount*@ItemPrice - @lIskontoTut )-(@ItemAmount*@ItemPrice - @lIskontoTut )/(1+(@KDVRate/100)))*-1),
											   nKdvOrani2    = @KDVRate,											   
											   lnettutar     = lnettutar + ((@ItemAmount*@ItemPrice - @lIskontoTut ) *-1)
											   where nAlisverisId = @nAlisverisId
                       
                       end

                       if @nKdvOran = 3
                       begin
						update tbAlisVeris set ltoplammiktar = ltoplammiktar + (@ItemAmount *-1),
											   lmalbedeli    = lmalbedeli +((@ItemAmount*@ItemPrice - @lIskontoTut ) *-1),
											   lkdvmatrahi3  = lkdvmatrahi3 +(((@ItemAmount*@ItemPrice - @lIskontoTut )/(1+(@KDVRate/100))) *-1),
											   lkdv3         = lkdv3+(((@ItemAmount*@ItemPrice - @lIskontoTut )-(@ItemAmount*@ItemPrice - @lIskontoTut )/(1+(@KDVRate/100))) *-1),
											   nKdvOrani3    = @KDVRate,
											   lnettutar     = lnettutar + ((@ItemAmount*@ItemPrice - @lIskontoTut ) *-1)
											   where nAlisverisId = @nAlisverisId
                       
                       end

                       if @nKdvOran = 4
                       begin
						update tbAlisVeris set ltoplammiktar = ltoplammiktar + (@ItemAmount  *-1),
											   lmalbedeli    = lmalbedeli +((@ItemAmount*@ItemPrice - @lIskontoTut )  *-1),
											   lkdvmatrahi4  = lkdvmatrahi4 +(((@ItemAmount*@ItemPrice - @lIskontoTut )/(1+(@KDVRate/100)))  *-1),
											   lkdv4         = lkdv4+(((@ItemAmount*@ItemPrice - @lIskontoTut )-(@ItemAmount*@ItemPrice - @lIskontoTut )/(1+(@KDVRate/100))) *-1),
											   nKdvOrani4    = @KDVRate,
											   lnettutar     = lnettutar + ((@ItemAmount*@ItemPrice - @lIskontoTut ) *-1)
											   where nAlisverisId = @nAlisverisId
                       end

                       if @nKdvOran = 5
                       begin
							update tbAlisVeris set ltoplammiktar = ltoplammiktar + (@ItemAmount  *-1),
											   lmalbedeli        = lmalbedeli +((@ItemAmount*@ItemPrice - @lIskontoTut )  *-1),
											   lkdvmatrahi5      = lkdvmatrahi5 +(((@ItemAmount*@ItemPrice - @lIskontoTut )/(1+(@KDVRate/100)))  *-1),
											   lkdv5             = lkdv5+(((@ItemAmount*@ItemPrice - @lIskontoTut )-(@ItemAmount*@ItemPrice - @lIskontoTut )/(1+(@KDVRate/100))) *-1),
											   nKdvOrani5        = @KDVRate,
											   lnettutar         = lnettutar + ((@ItemAmount*@ItemPrice - @lIskontoTut ) *-1)
											   where nAlisverisId = @nAlisverisId
                       
                       end

						 INSERT INTO tbStokFisiDetayi
										(nIslemId,nStokID,dteIslemTarihi,nFirmaId,nMusteriId,sFisTipi,
										 dteFisTarihi,lFisNo,nGirisCikis,sDepo,
										 lReyonFisNo,sStokIslem,sKasiyerRumuzu, sSaticiRumuzu, sOdemeKodu,
										 dteIrsaliyeTarihi,lIrsaliyeNo,lGirisMiktar1,lGirisMiktar2, lGirisFiyat,lGirisTutar,
										 lCikisMiktar1,lCikisMiktar2,lCikisFiyat,lCikisTutar,
										 sFiyatTipi,lBrutFiyat,lBrutTutar,
										 lMaliyetFiyat,lMaliyetTutar,nIskontoYuzdesi,lIskontoTutari,
										 sDovizCinsi,lDovizFiyat,
										 nSiparisID,nReceteNo,nTransferId,sTransferDepo,
										 nKdvOrani,sAciklama,sHareketTipi,
										 bMuhasebeyeIslendimi, sKullaniciAdi,dteKayitTarihi,
										 sDovizCinsi1, lDovizMiktari1, lDovizKuru1,
										 sDovizCinsi2, lDovizMiktari2, lDovizKuru2,
										 nOTVOrani,nTransferFirmaId,nAlisverisId,nStokFisiID,nIrsaliyeFisiID,
										 sMasrafYontemi,sHangiUygulama,nEkSaha1,nEkSaha2,bEkSoru1,bEkSoru2,
										 sSonKullaniciAdi, dteSonUpdateTarihi )
									
						values
						 ( @nIslemId,@ItemID,@InvoiceDate,0,@CustID,'P',
								   @InvoiceDate,@OrderNo,'4',@StoreCode,
								   0,'P',@Cashier,@SalesMan,@PaymentCode,
								   @InvoiceDate,0,0,0,0,0,
								   @ItemAmount*-1,0,
								   round(@ItemPrice/(1+(@KDVRate/100)),4) *-1,
								   (((@ItemAmount*@ItemPrice - @lIskontoTut)/(1+(@KDVRate/100)))*-1),
								   @PriceType,
								   @ItemPrice*-1,
								   (@ItemPrice * @ItemAmount)*-1 ,
								   0,0,0,@lIskontoTut,
								   '',0,
								   null,0,null,null,
								   @KDVRate,'','',
								   0,@UserName,getdate(),
								   '',0,0,
								   '',0,0,
								   0,null,@nAlisverisId,null,null,
								   '','',0,0,0,0,
								   @UserName,getdate() )

						 if @SaleType=0
							 --begin
								-- update tbOdeme set lOdemeTutar = lOdemeTutar +((@ItemAmount*@ItemPrice) *-1)
								-- 			   where nAlisverisId = @nAlisverisId
								--	-- Odeme Isle
						  
					              
							 -- end

								if (@PaymentType1 <> '' and @PaymentAmount1 <> 0 ) or 
									(@PaymentType2 <> '' and @PaymentAmount2 <> 0 ) or 
									(@PaymentType3 <> '' and @PaymentAmount3 <> 0 ) or
									(@PaymentType4 <> '' and @PaymentAmount4 <> 0 ) or
									(@PaymentType5 <> '' and @PaymentAmount5 <> 0 ) 
								begin									
										update tbstokfisnolar set lOdemeNo1=lOdemeNo1+1 where sdepo=@StoreCode
										set @PaymentNo=(select lodemeno1 from tbstokfisnolar where sdepo=@StoreCode)
					
								
								end		


								if @PaymentType1 <> '' and @PaymentAmount1 <> 0
								 begin 	
		
									update tbavsirano set nSonID=nsonID+1 	where sdepo=@StoreCode	and nSiraIndex=2
									set @PaymentID=(select nSonID    from tbAVSiraNo     where sdepo=@StoreCode and nSiraIndex=2)
									-- (@ItemAmount*@ItemPrice - @lIskontoTut) *-1		
									INSERT INTO tbOdeme
												(nOdemeID, nAlisverisID, sOdemeSekli, nOdemeKodu, sKasiyerRumuzu, dteOdemeTarihi, dteValorTarihi, lOdemeTutar, sDovizCinsi, lDovizTutar, 
												 lMakbuzNo, lOdemeNo, nTaksitID, nIadeAlisverisID, bMuhasebeyeIslendimi, nKasaNo, sKartNo, sKullaniciAdi, dteKayitTarihi, sMagaza)
									VALUES   (@PaymentID,@nAlisverisId,@PaymentType1,1,@Cashier,@InvoiceDate,@InvoiceDate,@PaymentAmount1 ,'',0
													 ,@PaymentNo,@PaymentNo,0,0,0,@CashRegister,'',@UserName,getdate(),@StoreCode)
								end 													 

								if @PaymentType2 <> '' and @PaymentAmount2 <> 0
								 begin 	
		
									update tbavsirano set nSonID=nsonID+1 	where sdepo=@StoreCode	and nSiraIndex=2
									set @PaymentID=(select nSonID    from tbAVSiraNo     where sdepo=@StoreCode and nSiraIndex=2)
									-- (@ItemAmount*@ItemPrice - @lIskontoTut) *-1		
									INSERT INTO tbOdeme
												(nOdemeID, nAlisverisID, sOdemeSekli, nOdemeKodu, sKasiyerRumuzu, dteOdemeTarihi, dteValorTarihi, lOdemeTutar, sDovizCinsi, lDovizTutar, 
												 lMakbuzNo, lOdemeNo, nTaksitID, nIadeAlisverisID, bMuhasebeyeIslendimi, nKasaNo, sKartNo, sKullaniciAdi, dteKayitTarihi, sMagaza)
									VALUES   (@PaymentID,@nAlisverisId,@PaymentType2,1,@Cashier,@InvoiceDate,@InvoiceDate,@PaymentAmount2 ,'',0
													 ,@PaymentNo,@PaymentNo,0,0,0,@CashRegister,'',@UserName,getdate(),@StoreCode)
								end 

								if @PaymentType3 <> '' and @PaymentAmount3 <> 0
								 begin 	
		
									update tbavsirano set nSonID=nsonID+1 	where sdepo=@StoreCode	and nSiraIndex=2
									set @PaymentID=(select nSonID    from tbAVSiraNo     where sdepo=@StoreCode and nSiraIndex=2)
									-- (@ItemAmount*@ItemPrice - @lIskontoTut) *-1		
									INSERT INTO tbOdeme
												(nOdemeID, nAlisverisID, sOdemeSekli, nOdemeKodu, sKasiyerRumuzu, dteOdemeTarihi, dteValorTarihi, lOdemeTutar, sDovizCinsi, lDovizTutar, 
												 lMakbuzNo, lOdemeNo, nTaksitID, nIadeAlisverisID, bMuhasebeyeIslendimi, nKasaNo, sKartNo, sKullaniciAdi, dteKayitTarihi, sMagaza)
									VALUES   (@PaymentID,@nAlisverisId,@PaymentType3,1,@Cashier,@InvoiceDate,@InvoiceDate,@PaymentAmount3 ,'',0
													 ,@PaymentNo,@PaymentNo,0,0,0,@CashRegister,'',@UserName,getdate(),@StoreCode)
								end 								

								if @PaymentType4 <> '' and @PaymentAmount4 <> 0
								 begin 	
		
									update tbavsirano set nSonID=nsonID+1 	where sdepo=@StoreCode	and nSiraIndex=2
									set @PaymentID=(select nSonID    from tbAVSiraNo     where sdepo=@StoreCode and nSiraIndex=2)
									-- (@ItemAmount*@ItemPrice - @lIskontoTut) *-1		
									INSERT INTO tbOdeme
												(nOdemeID, nAlisverisID, sOdemeSekli, nOdemeKodu, sKasiyerRumuzu, dteOdemeTarihi, dteValorTarihi, lOdemeTutar, sDovizCinsi, lDovizTutar, 
												 lMakbuzNo, lOdemeNo, nTaksitID, nIadeAlisverisID, bMuhasebeyeIslendimi, nKasaNo, sKartNo, sKullaniciAdi, dteKayitTarihi, sMagaza)
									VALUES   (@PaymentID,@nAlisverisId,@PaymentType4,1,@Cashier,@InvoiceDate,@InvoiceDate,@PaymentAmount4 ,'',0
													 ,@PaymentNo,@PaymentNo,0,0,0,@CashRegister,'',@UserName,getdate(),@StoreCode)
								end 								
																						  

								if @PaymentType5 <> '' and @PaymentAmount5 <> 0
								 begin 	
		
									update tbavsirano set nSonID=nsonID+1 	where sdepo=@StoreCode	and nSiraIndex=2
									set @PaymentID=(select nSonID    from tbAVSiraNo     where sdepo=@StoreCode and nSiraIndex=2)
									-- (@ItemAmount*@ItemPrice - @lIskontoTut) *-1		
									INSERT INTO tbOdeme
												(nOdemeID, nAlisverisID, sOdemeSekli, nOdemeKodu, sKasiyerRumuzu, dteOdemeTarihi, dteValorTarihi, lOdemeTutar, sDovizCinsi, lDovizTutar, 
												 lMakbuzNo, lOdemeNo, nTaksitID, nIadeAlisverisID, bMuhasebeyeIslendimi, nKasaNo, sKartNo, sKullaniciAdi, dteKayitTarihi, sMagaza)
									VALUES   (@PaymentID,@nAlisverisId,@PaymentType5,1,@Cashier,@InvoiceDate,@InvoiceDate,@PaymentAmount5 ,'',0
													 ,@PaymentNo,@PaymentNo,0,0,0,@CashRegister,'',@UserName,getdate(),@StoreCode)
								end 								



						if @PromosyonIndirim <> 0 
							begin							
								 INSERT INTO tbAVPromosyonIndirim 
												(nAlisverisID, sPromosyonKodu, nStokID , lIndirimTutari , nStokIslemID , nAlisverisSiparisID , nOdemeID )
								 VALUES   (@nAlisverisId,@sPromosyonKodu,@ItemID,@PromosyonIndirim * -1,@nIslemId,NULL,'')
							end 


						 
						 

					COMMIT TRANSACTION
	       end 


print 'Islem Tamamlandı'
ERROR_HANDLER:


GO


