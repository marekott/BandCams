-- =============================================
-- Author:		Ott, Marek
-- Create date: 2020-03-30
-- Description:	Procedura pobiera konkretny obiekt z tabeli Stream na podstawie przesłanego ID
-- =============================================

CREATE PROCEDURE [dbo].[spStream_Get]
	@Id INT

AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		*
	FROM 
		[dbo].[Stream]
	WHERE 
		[dbo].[Stream].[Id] = @Id
	FOR JSON PATH, WITHOUT_ARRAY_WRAPPER;
END
GO
