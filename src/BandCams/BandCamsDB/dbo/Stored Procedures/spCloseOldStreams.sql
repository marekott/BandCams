-- =============================================
-- Author:		Ott, Marek
-- Create date: 2020-05-13
-- Description:	Procedura ustawia parametr isActive na false dla streamów, które trwają dłużej niż ilość minut przekazana w parametrze
-- =============================================

CREATE PROCEDURE [dbo].[spCloseOldStreams]
	@DateTimeNowUtc DATETIME2,
	@OlderThanInMinutes int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Stream]
	SET [IsActive] = 0
	WHERE [IsActive] = 1
	AND DATEDIFF(MINUTE, CreateDate, @DateTimeNowUtc) >= @OlderThanInMinutes;

END
GO
