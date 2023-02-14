CREATE TRIGGER incPointsDueToJoinProj_Trigger
ON Volunteer_Participated_In after insert as
declare @Vol_id int;
declare @proj_id int;
set @proj_id=(select Project_Num from inserted)
set @Vol_id=(select Volunteer_ID  from inserted)
begin
UPDATE Volunteer
SET Volunteer.Points = Volunteer.Points +(Select Project.Points_If_joined from Project where Project_Num=1)
Where Volunteer.Volunteer_id=@Vol_id
end