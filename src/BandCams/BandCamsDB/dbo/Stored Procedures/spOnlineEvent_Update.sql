-- =============================================
-- Author:		Ott, Marek
-- Create date: 2020-04-01
-- Description:	Procedura aktualizuje obiekt OnlineEvent
-- =============================================

CREATE PROCEDURE [dbo].[spOnlineEvent_Update]
	@Id INT,
	@Name NVARCHAR(100),
	@Description NVARCHAR(MAX),
	@StartDate DATETIME2,
	@Organizer NVARCHAR(100),
	@ImageContent VARBINARY(MAX)

AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[OnlineEvent]
	SET [Name] = @Name, [Description] = @Description, [StartDate] = @StartDate, [Organizer] = @Organizer, [ImageContent] = @ImageContent
	WHERE [Id] = @Id;

END
GO
