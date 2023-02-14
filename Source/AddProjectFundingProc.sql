
CREATE PROCEDURE [dbo].[AddProjectFunding]
	-- Add the parameters for the stored procedure here
	 @projectnum int,
	 @amount int,
	 @date Date
AS
BEGIN
INSERT INTO Finance(Issue_Date,Monetary_Amount,Transaction_Type,Project_Code)
values(@date,@amount,'Project',@projectnum)
END
GO