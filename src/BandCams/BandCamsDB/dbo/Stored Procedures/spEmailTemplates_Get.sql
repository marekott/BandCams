-- =============================================
-- Author:		Ott, Marek
-- Create date: 2020-05-28
-- Description:	Procedura pobiera wskazany w parametrze wzór maila.
-- =============================================

CREATE PROCEDURE [dbo].[spEmailTemplates_Get]
	@TemplateName VARCHAR(20)

AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		[Value]
	FROM 
		[dbo].[EmailTemplates]
	WHERE
		[dbo].[EmailTemplates].[TemplateName] = @TemplateName;
END
GO