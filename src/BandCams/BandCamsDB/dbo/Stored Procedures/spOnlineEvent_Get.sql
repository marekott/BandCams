-- =============================================
-- Author:		Ott, Marek
-- Create date: 2020-03-30
-- Description:	Procedura pobiera konkretny obiekt z tabeli OnlineEvent na podstawie przesłanego ID
-- =============================================

CREATE PROCEDURE [dbo].[spOnlineEvent_Get]
	@Id INT

AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		*
	FROM 
		[dbo].[OnlineEvent]
	WHERE 
		[dbo].[OnlineEvent].[Id] = @Id
	FOR JSON PATH, WITHOUT_ARRAY_WRAPPER;
END
GO
