-- =============================================
-- Author:		Ott, Marek
-- Create date: 2020-04-01
-- Description:	Procedura aktualizuje obiekt BCParameters
-- =============================================

CREATE PROCEDURE [dbo].[spBCParameter_Update]
	@Id INT,
	@Key VARCHAR(100),
	@Value VARCHAR(200)

AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[BCParameter] 
	SET [Key] = @Key, [Value] = @Value
	WHERE [Id] = @Id;

END
GO
