
IF OBJECT_ID (N'qry_InsertB2CCollectedDetail') IS NOT NULL DROP PROCEDURE qry_InsertB2CCollectedDetail
GO
CREATE PROCEDURE qry_InsertB2CCollectedDetail  (
		  @CollectedProductsDetailID uniqueidentifier,
		  @IslemID numeric(10),
		  @CollectedQty numeric(14,4),
		  @AlisverisID char(20)
) AS

UPDATE CollectedProductsDetail SET CollectedQty = @CollectedQty , LastUpdatedDate = GetDate() Where IslemID =  @IslemID AND AlisverisID =  @AlisverisID
IF @@ROWCOUNT = 0
BEGIN
    INSERT INTO CollectedProductsDetail(CollectedProductsDetailID,IslemID,CollectedQty,AlisverisID,LastUpdatedDate) Values( @CollectedProductsDetailID,  @IslemID ,@CollectedQty, @AlisverisID,GetDate())
END

GO
