
IF OBJECT_ID (N'qry_InsertB2CCollectedHeader') IS NOT NULL DROP PROCEDURE qry_InsertB2CCollectedHeader
GO
CREATE PROCEDURE qry_InsertB2CCollectedHeader  (
		  @CollectedProductsMasterID uniqueidentifier,
		  @AlisverisID Char(20),
		  @IsCompleted bit
)

AS

UPDATE CollectedProductsMaster SET IsCompleted = @IsCompleted, LastUpdatedDate = GetDate() Where AlisverisID =  @AlisverisID
IF @@ROWCOUNT = 0
BEGIN
    INSERT INTO CollectedProductsMaster(CollectedProductsMasterID,AlisverisID,IsCompleted,LastUpdatedDate) Values( @CollectedProductsMasterID,  @AlisverisID ,@IsCompleted, GetDate())
END
GO
