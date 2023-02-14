CREATE TRIGGER updateDonationDate_Trigger
ON Finance after insert as
declare @Vol_id int;
declare @date date;
declare @type varchar(50);
set @Vol_id=(select Volunteer_ID  from inserted)
set @date=(select Issue_Date  from inserted)
set @type=(select Transaction_Type  from inserted)
begin
UPDATE Volunteer
SET Last_Donation_Date = @date
Where Volunteer.Volunteer_id=@Vol_id AND @type='Donation'
end