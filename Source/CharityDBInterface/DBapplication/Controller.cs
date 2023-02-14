using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Xml.Linq;

namespace DBapplication
{
    public class Controller
    {
        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();
        }
         
        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }

        public DataTable SelectAllEmp()
        {
            string query = "SELECT * FROM Employee;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable GetUsernameAndPassofVolunteer(string username)
        {
            string query = "Select Volunteer.Username, Volunteer.Vol_Password, Volunteer.Volunteer_id " +
                "From Volunteer" +
                " where Volunteer.Username= '" + username + "';";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetHeadPass (string username)
        {
            string query = "Select E.Username, E.Emp_PassWord, E.Employee_id " +
                 "From Employee E " +
                 "where E.Username = '" + username + "' AND E.Department_No = 1;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable GetEmployeePass(string username)
        {
            string query = "Select E.Username, E.Emp_PassWord, E.Employee_id  " +
                 "From Employee E " +
                 "where E.Username = '" + username + "' AND E.Department_No != 1;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable CheckHeadPassPresent(int id)
        {
            string query = "Select E.Emp_PassWord " +
                "From Employee E " +
                "where E.Employee_id=" + id + " AND E.Department_No = 1";
            return dbMan.ExecuteReader(query);
        }
        public DataTable CheckEmployeePassPresent(int id)
        {
            string query = "Select E.Emp_PassWord " +
                "From Employee E " +
                "where E.Employee_id=" + id + " AND E.Department_No != 1";
            return dbMan.ExecuteReader(query);
        }
        public DataTable CheckVolunteerPassPresent(int id)
        {
            string query = "Select Volunteer.Vol_Password " +
                "From Volunteer " +
                "where Volunteer.Volunteer_id =" + id +";";
            return dbMan.ExecuteReader(query);
        }

        public int UpdateEmployeePass(int id,string password)
        {
            string query = "Update Employee " +
                "set Emp_PassWord='" + password + "' " +
                "where Employee_id=" + id + ";";
            return dbMan.ExecuteNonQuery(query);
        }
        public int UpdateVolunteerPass(int id, string password)
        {
            string query = "Update Volunteer " +
                "set Vol_Password='" + password + "' " +
                "where Volunteer_id=" + id + ";";
            return dbMan.ExecuteNonQuery(query);
        }




        public int InsertVolunteer(string Fname, string Lname, string BDate, string gender, string address, string Pnum,string username,string password)
        {
            string query = "insert into Volunteer(First_Name,Last_Name,Birth_Date,Gender,Volunteer_Address,Phone_Number,Username,Vol_Password)" +
                            "Values ('" + Fname + "','" + Lname + "','" + BDate + "','" + gender + "','" + address + "','" + Pnum + "','"+ username+"','"+password+"'); ";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable GetVolunteerName(int ID)
        {
            string query = "SELECT First_Name FROM Volunteer where Volunteer_id= " + ID + "";
            return dbMan.ExecuteReader(query);
        }
        public DataTable GetAllEmployeeNames()
        {
            string query = "SELECT First_Name,Last_Name,Employee_id FROM Employee ";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectsitesinfoNotNum()
        {
            string query = "SELECT Site_No,No_Of_Items,Supply_Type,Site_Address FROM Inventory_Site;";
            return dbMan.ExecuteReader(query);
        }
        public int UpdateSiteEmployee(int SiteNo, int EmpID)
        {

            string query = "UPDATE Inventory_Site SET Employee_Num =" + EmpID + " where Site_No=" + SiteNo + "";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable SelectActiveProjects()
        {
            string query = "Select Project_Num,Project_Name,Project_City,Project_Start_Date,Project_End_Date From Project where Project_Status='active'";
            return dbMan.ExecuteReader(query);
        }
        public int UpdateProjectEmployee(int Pnum, int EmpID)
        {

            string query = "UPDATE Project SET Employee_Id =" + EmpID + " where Project_Num =" + Pnum + "";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertEmployee(string Fname, string Lname,int depnum, string BDate, string gender, string address, string Pnum, string username, string password)
        {
            string query = "INSERT INTO Employee " +
                            "Values ('" + Fname + "','" + Lname + "','" + Pnum + "','" + BDate + "','" + gender + "','" + address + "'," + depnum + ",'" + password + "','" + username + "'); ";
            return dbMan.ExecuteNonQuery(query);
        }
        public int FireEmployee(int id)
        {
           string query= " DELETE FROM EMPLOYEE "   +  " WHERE  Employee_id = " + id;
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable SelectRequests(int id)
        {
            string query = "SELECT Request_Type,Date_Issued,Request_Status FROM Request " +
                "where Volunteer_Code=" + id + ";";
            return dbMan.ExecuteReader(query);
        }
        public DataTable UpdateVolunteerPoints(int id)
        {
            string query = "UPDATE Volunteer FROM Points " +
                "where Volunteer_Code=" + id + ";";
            return dbMan.ExecuteReader(query);
        }

        public int InsertRecipient(string Fname, string Lname, string BDate, string gender, string address, string Pnum, int PID)
        {
            string query = "insert into Recipient(First_Name,Last_Name,Birth_Date,Gender,Recipient_Address,Phone_Number,Project_No)" +
                            "Values ('" + Fname + "','" + Lname + "','" + BDate + "','" + gender + "','" + address + "','" + Pnum + "'," + PID + "); ";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable SelectDepNum()
        {
            string query= "SELECT Dnumber FROM Department;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable selectactiveprojects()
        {
            string query = "SELECT Project_Name,Project_End_Date FROM Project where Project_Status='active';";
            return dbMan.ExecuteReader(query);
        }
        public DataTable maxprojectcost()
        {
            string query = "SELECT MAX(Project_Capital) FROM Project;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable maxprojectcostid(int money)
        {
            string query = "select Project_Name From Project where Project_Capital=" + money +";";
            return dbMan.ExecuteReader(query);
        }
        public DataTable minprojectcostid(int money)
        {
            string query = "select Project_Num From Project where Project_Capital=" + money + ";";
            return dbMan.ExecuteReader(query);
        }
        public DataTable minprojectcost()
        {
            string query = "SELECT MIN(Project_Capital) FROM Project;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable avgprojectcost()
        {
            string query = "SELECT AVG(Project_Capital) FROM Project;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable Viewemployeesfire(int id)
        {
            string query = "SELECT First_Name,Last_Name,Employee_id,Phone_Number FROM Employee WHERE Employee_id != "+id+";";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getemployeesid()
        {
            string query = "SELECT First_Name,Last_Name,Employee_id From Employee;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectDep()
        {
            string query = "Select Department.Dep_Number,Department.Dep_Name From Department";
            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectProject(string location)
        {
            string query = "SELECT Pname,Dname FROM Department D, Project P, Dept_Locations L"
             +" where P.Dnum=D.Dnumber and L.Dnumber=D.Dnumber and L.Dlocation='"+location+"';"; 
            
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectProjects()
        {
            string query = "Select Project_Num, Project_Name From Project";
            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectNearByProjects(int Volunteer_ID)
        {
            string query = "Select P.Project_Num,P.Project_Name From Project P,Volunteer V " +
                "where P.Project_City=V.Volunteer_Address AND V.Volunteer_id=" + Volunteer_ID + ";";

            return dbMan.ExecuteReader(query);
        }
        public int SendBeAnEmployeeRequest(int DepNum, int Volunteer_ID)
        {
            DateTime today = DateTime.Today;
            string date = today.ToString("yyyy-MM-dd");
            string query = "Insert INTO Request(Request_Type,Date_Issued,Volunteer_Code,Department_No) " +
                "Values('Employee_Request','" + date + "'," + Volunteer_ID + "," + DepNum + "); ";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable CheckPrevEmpRequest(int DepNumber, int Volunteer_ID)
        {
            string query = "SELECT * FROM Request R " +
"                          WHERE R.Volunteer_Code=" + Volunteer_ID + " AND R.Department_No=" + DepNumber + " AND Request_Status='Pending';";
            return dbMan.ExecuteReader(query);
        }
        public DataTable CheckPrevRequest(int ProjectNum, int Volunteer_ID)
        {
            string query = "SELECT * FROM Request R " +
"                          WHERE R.Volunteer_Code=" + Volunteer_ID + " AND R.Project_key=" + ProjectNum + " AND Request_Status='Pending';";
            return dbMan.ExecuteReader(query);
        }
        public int Insertsuppliersite(int numitems, int sitenum, int suppliernum)
        {
            string query = "insert into Supplies_Site " +
                            "Values (" + numitems + "," + sitenum + "," + suppliernum + "); ";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable Selectsupplierinfo()
        {
            string query = "SELECT Supplier_id,Phone_Number,Supplier_Name,Supplied_Product,Quantity_Availble FROM Supplier;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable Selectonesupplier(int supplierid)
        {
            string query = "SELECT Supplied_Product,Quantity_Availble FROM Supplier where Supplier_id=" + supplierid + "; ";
            return dbMan.ExecuteReader(query);
        }
        public DataTable Selectsitetype(int siteid)
        {
            string query = "SELECT Supplied_Product,Quantity_Availble,Supplier_id,Supplier_Name FROM Supplier,Inventory_Site where Site_No=" + siteid + " and Supplied_Product=Supply_Type " + "; ";
            return dbMan.ExecuteReader(query);
        }
        public DataTable Selecttrue(int supplierid, int siteno)
        {
            string query = "SELECT Supplied_Product,Quantity_Availble,Supplier_id,Supplier_Name FROM Supplier,Inventory_Site where Site_No=" + siteno + " and Supplied_Product=Supply_Type and Supplier_id= " + supplierid + "; ";
            return dbMan.ExecuteReader(query);
        }


        public int SendJoinProjectRequest(int ProjectNum, int Volunteer_ID)
        {
            DateTime today = DateTime.Today;
            string date = today.ToString("yyyy-MM-dd");
            string query = "Insert INTO Request(Request_Type,Date_Issued,Volunteer_Code,Project_key) " +
                "Values('Project_Join_Request','" + date + "'," + Volunteer_ID + "," + ProjectNum + "); ";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable RetrievePoints(int Vol_ID)
        {
            string query = "Select Points From Volunteer where Volunteer_id=" + Vol_ID + ";";
            return dbMan.ExecuteReader(query);
        }

        public DataTable RetrieveRewards()
        {
            string query = "Select R.Reward_No, R.Reward_Points, R.Reward_Type, R.Affiliate From Rewards R where R.Volunteer_No  IS NULL;";
            return dbMan.ExecuteReader(query);
        }
        public int RedeemReward(int rewardNum, int Volunteer_id)
        {
            DateTime today = DateTime.Today;
            string date = today.ToString("yyyy-MM-dd");
            string query = "Update Rewards " +
           "set Rewards.Volunteer_No=" + Volunteer_id + ", Rewards.Date_Taken='" + date + "' where Rewards.Reward_No=" + rewardNum + ";";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable GetEmployeeRequests()
        {
            string query = "Select R.Request_No,R.Request_Type,R.Date_Issued,R.Volunteer_Code,R.Department_No From Request R where R.Request_Status='Pending' and R.Request_Type='Employee_Request';";
            return dbMan.ExecuteReader(query);
        }

        public int InsertEmployeeFromRequest(int DepNum, int Volunteer_ID, string username)
        {
            string query = "insert INTO Employee (First_Name,Last_Name,Phone_Number,Birth_Date,Gender,Employee_Address,Department_No,Emp_Password,Username)" +
                "select v.First_Name,v.Last_Name,v.Phone_Number,v.Birth_Date,v.Gender, v.Volunteer_Address," + DepNum + ",v.Vol_Password,'" + username + "'" +
                "From Volunteer v " + "where v.Volunteer_id = " + Volunteer_ID + "";
            return dbMan.ExecuteNonQuery(query);
        }

        public int SetRequestAccepted(int ReqNo)
        {

            string query = "UPDATE Request SET Request_Status ='Accepted' where Request_No= " + ReqNo + "";
            return dbMan.ExecuteNonQuery(query);
        }


        public int SetRequestRejected(int ReqNo)
        {

            string query = "UPDATE Request SET Request_Status ='Rejected' where Request_No= " + ReqNo + " ";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable CheckUsernameExists(string username)
        {

            string query = "select Username from Employee where Username='" + username + "'";
            return dbMan.ExecuteReader(query);
        }

        public int AddDonation(int id,int monetaryamount)
        {
            DateTime today = DateTime.Today;
            string date = today.ToString("yyyy-MM-dd");
            string StoredProcedureName = StoredProcedures.DonateMoney;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Date", date);
            Parameters.Add("@montamount", monetaryamount);
            Parameters.Add("@transactiontype", "Donation");
            Parameters.Add("@volID", id);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public DataTable SelectVolunteerTojoinProjects()
        {
            string StoredProcedureName = StoredProcedures.SelectVolunteersProjectsRequests;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }

        public int AddVolunteertoProject(int volid, int projid)
        {
           
            string StoredProcedureName = StoredProcedures.AddVolunteertoProject;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@projectnum", projid);
            Parameters.Add("@Volunteerid", volid);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public DataTable GetAffiliates()
        {
            string StoredProcedureName = StoredProcedures.GetAffiliates;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }
        public int InsertReward(string Reward_Type, string Affiliate, int Reward_Points, string Phone_Number)
        {
            string StoredProcedureName = StoredProcedures.InsertReward;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Reward_Type", Reward_Type);
            Parameters.Add("@Affiliate", Affiliate);
            Parameters.Add("@Reward_Points", Reward_Points);
            Parameters.Add("@Phone_Number", Phone_Number);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }
        public DataTable GetAffiliateNumber(string Affiliate)
        {
            string StoredProcedureName = StoredProcedures.GetAffiliateNumber;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();

            Parameters.Add("@Affiliate", Affiliate);

            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable getDaysRemainingAfterEnd()
        {
            DateTime today = DateTime.Today;
            string dateToday = today.ToString("yyyy-MM-dd"); //gets current date
            
            string StoredProcedureName = StoredProcedures.DaysRemainingAfterEnd;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@currDate", dateToday);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        public DataTable GetRecipients()
        {
            string StoredProcedureName = StoredProcedures.GetRecipients;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }

        public int SetFeedback(int Feedback_Rating, int Recipient_id)
        {
            string StoredProcedureName = StoredProcedures.SetFeedback;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();

            Parameters.Add("@Feedback_Rating", Feedback_Rating);
            Parameters.Add("@Recipient_id", Recipient_id);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public DataTable Selectinactivedonors(string x)
        {
            string query = "SELECT First_Name,Last_Name,Phone_Number,Last_Donation_Date FROM Volunteer  where Last_Donation_Date < '"
             + x + "' ORDER BY Last_Donation_Date ;";

            return dbMan.ExecuteReader(query);
        }
        public int Insertprojectsite(int numitems, int sitenum, int projectnum)
        {
            string query = "insert into Supplies_Project " +
                            "Values (" + numitems + "," + sitenum + "," + projectnum + "); ";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable Selectonesite(int siteid)
        {
            string query = "SELECT Supply_Type,No_Of_Items FROM Inventory_Site where Site_No=" + siteid + "; ";
            return dbMan.ExecuteReader(query);
        }
        public DataTable Selecttrue2(int projectnum, int siteno)
        {
            string query = "SELECT Project.supply_type,supply_quantity,Project_Num,Project_Name FROM Project,Inventory_Site where Site_No=" + siteno + " and Project.supply_type=Inventory_Site.Supply_Type and Project_Num= " + projectnum + "; ";
            return dbMan.ExecuteReader(query);
        }
        public DataTable Selectsitesinfo()
        {
            string query = "SELECT Site_No,No_Of_Items,Supply_Type,Site_Address,Employee_Num FROM Inventory_Site;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable Selectprojectinfo()
        {
            string query = "SELECT Project_Num,Project_Name,Project_City,supply_type,supply_quantity FROM Project;";
            return dbMan.ExecuteReader(query);
        }
        public int InsertProject(string projectname, string projectcity, string startDate, string enddate, string projectstatus, int employeeid, string supply_type,int points)
        {
            string query = "insert into Project(Project_Name,Project_City,Project_Start_Date,Project_End_Date,Project_Status,Employee_id,supply_type,Points_If_joined)" +
            "Values ('" + projectname + "','" + projectcity + "','" + startDate + "','" + enddate + "','" + projectstatus + "' ," + employeeid + ",'" + supply_type + "',"+points+"" + " ); ";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateVolunteerFirstName(string name,int id)
        {

            string query = "UPDATE Volunteer SET First_Name ='" + name + "' where Volunteer_id='"+id+"'";
            return dbMan.ExecuteNonQuery(query);
        }
        public int UpdateVolunteerLastName(string name, int id)
        {

            string query = "UPDATE Volunteer SET Last_Name ='" + name + "' where Volunteer_id='" + id + "'";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateVolunteerAddress(string address, int id)
        {

            string query = "UPDATE Volunteer SET Volunteer_Address ='" + address + "' where Volunteer_id='" + id + "'";
            return dbMan.ExecuteNonQuery(query);
        }
        public int UpdateVolunteerPhoneNumber(string Phone, int id)
        {

            string query = "UPDATE Volunteer SET Phone_Number ='" + Phone + "' where Volunteer_id='" + id + "'";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateVolunteerUsername(string username, int id)
        {

            string query = "UPDATE Volunteer SET Username ='" + username + "' where Volunteer_id='" + id + "'";
            return dbMan.ExecuteNonQuery(query);
        }


        public int UpdateEmployeeUsername(string username, int id)
        {

            string query = "UPDATE Employee SET Username ='" + username + "' where Employee_id='" + id + "'";
            return dbMan.ExecuteNonQuery(query);
        }


        public int UpdateEmployeePhoneNumber(string Phone, int id)
        {

            string query = "UPDATE Employee SET Phone_Number ='" + Phone + "' where Employee_id='" + id + "'";
            return dbMan.ExecuteNonQuery(query);
        }


        public int UpdateEmployeeAddress(string address, int id)
        {

            string query = "UPDATE Employee SET Employee_Address ='" + address + "' where Employee_id='" + id + "'";
            return dbMan.ExecuteNonQuery(query);
        }


        public int UpdateEmployeeFirstName(string name, int id)
        {

            string query = "UPDATE Employee SET First_Name ='" + name + "' where Employee_id='" + id + "'";
            return dbMan.ExecuteNonQuery(query);
        }
        public int UpdateEmployeeLastName(string name, int id)
        {

            string query = "UPDATE Employee SET Last_Name ='" + name + "' where Employee_id='" + id + "'";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateEmployeeDegree(string degree, int id)
        {

            string query = "UPDATE Employee SET College_Degree ='" + degree + "' where Employee_id='" + id + "'";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable findavailablefunds()
        {
            string StoredProcedureName = StoredProcedures.FindAvailableFunds;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }
        public DataTable SelectActiveProjectsManage()
        {
            string StoredProcedureName = StoredProcedures.SelectActiveProjects;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }

        public DataTable getEmpDepartment(int empID)
        {
            string StoredProcedureName = StoredProcedures.getEmployeeDepartment;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@empId", empID);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public int SetProjectInactive(int ID)
        {
            string StoredProcedureName = StoredProcedures.SetProjectInactive;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();

            Parameters.Add("@projectnum", ID);

            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }
        public DataTable SelectDonationSum()
        {
            string query = "select sum(Monetary_Amount) from Finance where Transaction_Type='Donation'";
            return dbMan.ExecuteReader(query);
        }

        public int AddProjectfunding(int ID, DateTime date, int amount)
        {
            string StoredProcedureName = StoredProcedures.AddProjectFunding;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();

            Parameters.Add("@projectnum", ID);
            Parameters.Add("@amount", amount);
            Parameters.Add("@date", date);

            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

    }
}
