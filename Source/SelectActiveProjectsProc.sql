CREATE PROCEDURE [dbo].[SelectActiveProjects]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
SELECT Project_Num,Project_Name,Project_Start_Date,Project_End_Date,Project_Capital From Project where Project_Status='active'
END
GO