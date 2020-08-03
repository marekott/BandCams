-- =============================================
-- Author:		Ott, Marek
-- Create date: 2020-03-31
-- Description:	Procedura tworzy nowy obiekt BCParameters
-- =============================================

CREATE PROCEDURE [dbo].[spBCParameter_Insert]
	@Id INT OUTPUT,
	@Key VARCHAR(100),
	@Value VARCHAR(200)

AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @InsertedRow AS TABLE (Id INT);

	INSERT INTO [dbo].[BCParameter] ([Key], [Value])
	OUTPUT inserted.Id INTO @InsertedRow
	VALUES (@Key, @Value);

	SET @Id = (SELECT Id FROM @InsertedRow);
END
GO
