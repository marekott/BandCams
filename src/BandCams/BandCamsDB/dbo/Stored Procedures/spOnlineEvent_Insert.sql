-- =============================================
-- Author:		Ott, Marek
-- Create date: 2020-03-31
-- Description:	Procedura tworzy nowy obiekt OnlineEvent
-- =============================================

CREATE PROCEDURE [dbo].[spOnlineEvent_Insert]
	@Id INT OUTPUT,
	@Name NVARCHAR(100),
	@Description NVARCHAR(MAX),
	@StartDate DATETIME2,
	@Organizer NVARCHAR(100),
	@ImageContent VARBINARY(MAX)

AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @InsertedRow AS TABLE (Id INT);

	INSERT INTO [dbo].[OnlineEvent] ([Name], [Description], [StartDate], [Organizer], [ImageContent])
	OUTPUT inserted.Id INTO @InsertedRow
	VALUES (@Name, @Description, @StartDate, @Organizer, @ImageContent);

	SET @Id = (SELECT Id FROM @InsertedRow);
END
GO
