
CREATE PROCEDURE [dbo].[SetProjectInactive]
	-- Add the parameters for the stored procedure here
	 @projectnum int
	 
AS
BEGIN
Update Project
Set Project_Status='inactive' where Project_Num=@projectnum
END
GO
