IF OBJECT_ID (N'qry_GetB2CWarehouse') IS NOT NULL DROP PROCEDURE qry_GetB2CWarehouse
GO

CREATE PROCEDURE [dbo].[qry_GetB2CWarehouse]  

AS

 SELECT sDepo,sAciklama FROM tbDepo WITH(NOLOCK)

GO