-- =============================================
-- Author:		Ott, Marek
-- Create date: 2020-03-31
-- Description:	Procedura tworzy nowy obiekt Stream
-- =============================================

CREATE PROCEDURE [dbo].[spStream_Insert]
	@Id INT OUTPUT,
	@Link NVARCHAR(MAX),
	@IsActive BIT

AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @InsertedRow AS TABLE (Id INT);

	INSERT INTO [dbo].[Stream] ([Link], [IsActive])
	OUTPUT inserted.Id INTO @InsertedRow
	VALUES (@Link, @IsActive);

	SET @Id = (SELECT Id FROM @InsertedRow);
END
GO
