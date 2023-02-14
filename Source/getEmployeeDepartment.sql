
CREATE PROCEDURE [dbo].[getEmployeeDepartment]
	-- Add the parameters for the stored procedure here
	 @empId int
AS
BEGIN
Select Department.Dep_Name 
From Department, Employee
where Department.Dep_Number=Employee.Department_No AND Employee.Employee_id=@empId
END
GO

