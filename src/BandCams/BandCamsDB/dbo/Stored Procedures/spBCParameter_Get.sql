-- =============================================
-- Author:		Ott, Marek
-- Create date: 2020-03-30
-- Description:	Procedura pobiera konkretny obiekt z tabeli BCParameters na podstawie przesłanego ID
-- =============================================

CREATE PROCEDURE [dbo].[spBCParameter_Get]
	@Id INT

AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		*
	FROM 
		[dbo].[BCParameter]
	WHERE 
		[dbo].[BCParameter].[Id] = @Id
	FOR JSON PATH, WITHOUT_ARRAY_WRAPPER;
END
GO
