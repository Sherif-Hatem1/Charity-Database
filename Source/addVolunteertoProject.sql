
CREATE PROCEDURE [dbo].[addVolunteertoProject]
	-- Add the parameters for the stored procedure here
	 @projectnum int,
	 @Volunteerid int
AS
BEGIN
INSERT INTO Volunteer_Participated_In(Project_Num,Volunteer_ID)
Values (@projectnum,@Volunteerid)
END
GO
