
CREATE PROCEDURE [dbo].[daysRemaining]
	-- Add the parameters for the stored procedure here
	 @currDate date
AS
BEGIN
Select Project.Project_Name,DATEDIFF(day,Project.Project_End_Date, @currDate) AS date_difference
from Project
where Project_End_Date < @currDate AND Project.Project_Status='Active'
END
GO

