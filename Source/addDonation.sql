
CREATE PROCEDURE [dbo].[addDonation]
	-- Add the parameters for the stored procedure here
	@Date  date, 
	@montamount decimal(10, 2),
	@transactiontype varchar(50) , 
	@volID int
AS
BEGIN
INSERT INTO Finance(Issue_Date,Monetary_Amount,Transaction_Type,Volunteer_ID)
Values (@Date,@montamount,@transactiontype,@volID)
END

GO
