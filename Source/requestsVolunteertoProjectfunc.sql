
CREATE PROCEDURE [dbo].[requestsVolunteertoProject]

AS
BEGIN
Select Request.Request_No,Request.Volunteer_Code,Request.Project_key,Request.Date_Issued,First_Name, Project.Project_Name from Request,Volunteer,Project where Request.Project_key=Project.Project_Num AND Request.Volunteer_Code=Volunteer.Volunteer_id AND Request.Request_Status='Pending' AND Request_Type='Project_Join_Request' 
END
GO
