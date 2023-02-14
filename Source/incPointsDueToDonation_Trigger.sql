CREATE TRIGGER incPointsDueToDon_Trigger
ON Finance after insert as
declare @Vol_id int;
declare @monamount int;
declare @type varchar(50)
set @monamount=(select Monetary_Amount from inserted)
set @Vol_id=(select Volunteer_ID  from inserted)
set @type=(select Transaction_Type  from inserted)
begin
UPDATE Volunteer
SET Volunteer.Points = Volunteer.Points + (0.1 * @monamount)
Where Volunteer.Volunteer_id=@Vol_id AND @type='Donation'
end