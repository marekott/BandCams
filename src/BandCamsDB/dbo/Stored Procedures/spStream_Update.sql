-- =============================================
-- Author:		Ott, Marek
-- Create date: 2020-04-01
-- Description:	Procedura aktualizuje obiekt Stream
-- =============================================

CREATE PROCEDURE [dbo].[spStream_Update]
	@Id INT,
	@Link NVARCHAR(MAX),
	@IsActive BIT

AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Stream]
	SET [Link] = @Link, [IsActive] = @IsActive
	WHERE [Id] = @Id;

END
GO
