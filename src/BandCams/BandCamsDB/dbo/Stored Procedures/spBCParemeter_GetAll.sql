-- =============================================
-- Author:		Ott, Marek
-- Create date: 2020-03-30
-- Description:	Procedura pobiera wszytskie obiekty z tabeli BCParameters
-- =============================================

CREATE PROCEDURE [dbo].[spBCParameter_GetAll]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		*
	FROM 
		[dbo].[BCParameter]
	FOR JSON PATH;
END
GO
