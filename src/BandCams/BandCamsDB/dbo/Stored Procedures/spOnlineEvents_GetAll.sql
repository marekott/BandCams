-- =============================================
-- Author:		Ott, Marek
-- Create date: 2020-03-30
-- Description:	Procedura pobiera wszytskie obiekty z tabeli OnlineEvent
-- =============================================

CREATE PROCEDURE [dbo].[spOnlineEvent_GetAll]
	@fromDate DateTime2,
	@toDate DateTime2

AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		*
	FROM 
		[dbo].[OnlineEvent]
	WHERE
		[dbo].[OnlineEvent].[StartDate] >= @fromDate AND
		[dbo].[OnlineEvent].[StartDate] <= @toDate
	FOR JSON PATH;
END
GO
