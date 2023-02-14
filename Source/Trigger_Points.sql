CREATE TRIGGER Points_Due_to_Rewards_up
ON Rewards after update as
declare @Vol_id int;
declare @Rew_Points int;
set @Rew_Points=(select Reward_Points from inserted)
set @Vol_id=(select Volunteer_No from inserted)
begin
UPDATE Volunteer
SET Volunteer.Points = Volunteer.Points - @Rew_Points
Where Volunteer.Volunteer_id=@Vol_id
end