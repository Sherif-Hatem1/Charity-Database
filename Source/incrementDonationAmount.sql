CREATE TRIGGER incrementDonationAmount_Trigger
ON Finance after insert as
declare @Vol_id int;
declare @type varchar(50);
declare @monamount int
set @Vol_id=(select Volunteer_ID  from inserted)
set @monamount=(select Monetary_Amount  from inserted)
set @type=(select Transaction_Type  from inserted)
begin
UPDATE Volunteer
SET Donated_Amount = Donated_Amount+@monamount
Where Volunteer.Volunteer_id=@Vol_id AND @type='Donation'
end