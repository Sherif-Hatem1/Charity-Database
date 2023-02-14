
CREATE PROCEDURE [dbo].[FindAvailableFunds]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
SELECT ((SELECT SUM(Monetary_Amount) From Finance where Transaction_Type='Donation') - (SELECT SUM(Monetary_Amount) From Finance where Transaction_Type='Project'))
END
GO
