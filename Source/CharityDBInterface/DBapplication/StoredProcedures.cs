using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBapplication
{
    public class StoredProcedures
    {
        public static string DonateMoney = "addDonation";
        public static string SelectVolunteersProjectsRequests = "requestsVolunteertoProject";
        public static string AddVolunteertoProject = "addVolunteertoProject";
        public static string GetAffiliates = "GetAffiliates";
        public static string InsertReward = "insertReward";
        public static string GetAffiliateNumber = "GetAffiliateNumber";
        public static string GetRecipients = "GetRecipients";
        public static string SetFeedback = "SetFeedback";
        public static string DaysRemainingAfterEnd = "daysRemaining";
        public static string FindAvailableFunds = "FindAvailableFunds";
        public static string SelectActiveProjects = "SelectActiveProjects";
        public static string SetProjectInactive = "SetProjectInactive";
        public static string AddProjectFunding = "AddProjectFunding";
        public static string getEmployeeDepartment = "getEmployeeDepartment";

    }
}