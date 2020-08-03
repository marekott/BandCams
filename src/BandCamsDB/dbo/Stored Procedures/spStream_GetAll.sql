-- =============================================
-- Author:		Ott, Marek
-- Create date: 2020-03-30
-- Description:	Procedura pobiera wszytskie obiekty z tabeli Stream
-- =============================================

CREATE PROCEDURE [dbo].[spStream_GetAll]
	@isActive bit

AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		*
	FROM 
		[dbo].[Stream]
	WHERE
		[dbo].[Stream].[IsActive] = @isActive
	FOR JSON PATH;
END
GO
