using System;
using System.Data;
using DVLD.DAL;

namespace DVLD.BL
{
    public class LocalLicenseApplication : Application
    {

        public int LocalID { get; set; }
        public int LicenseClassID { get; set; }
        public LicenseClass LicenseClass;

        public LocalLicenseApplication()
        {
            ID = -1;
            ApplicantID = -1;
            Type = null;
            ApplicantInfo = null;
            Date = DateTime.Now;
            LastStatus = Status.New;
            LastStatusDate = DateTime.Now;
            Fees = -1;
            CreatorID = -1;
            LocalID = -1;
            LicenseClassID = -1;
            Mode = Mode.AddNew;
        }
        public LocalLicenseApplication(int ID, int ApplicantID, DateTime Date, int TypeID, int LastStatus,
            DateTime LastStatusDate, decimal Fees, int CreatorID, int LocalID, int LicenseClassID)
            : base(ID, ApplicantID, Date, TypeID, LastStatus, LastStatusDate, Fees, CreatorID)
        {
            this.LocalID = LocalID;
            this.LicenseClassID = LicenseClassID;
            LicenseClass = LicenseClass.Find(LicenseClassID);
            Mode = Mode.Update;
        }
        public static DataTable GetAllApplications()
        {
            return LocalLicenseApplicationData.GetAllApplications();
        }
        private bool AddNewApplication()
        {
            LocalID = LocalLicenseApplicationData.AddNewApplication(ID, LicenseClassID);
            return (LocalID != -1);
        }
        private bool UpdateLicenseClass()
        {
            return LocalLicenseApplicationData.UpdateLicenseClassInApplication(LocalID, LicenseClassID);
        }
        public override bool Save()
        {
            //Save base Application
            if (!base.Save()) { return false; }

            //New Application
            if (Mode == Mode.AddNew)
            {
                if (!AddNewApplication()) { return false; }

                Mode = Mode.Update;
                return true;
            }

            //Alter License Class
            else
            {
                return UpdateLicenseClass();
            }
        }
        public static LocalLicenseApplication Find(int LocalAppID)
        {
            int BaseAppID = -1, LicenseClassID = -1, ApplicantPersonID = -1, CreatedByUserID = -1,
                ApplicationTypeID = -1, ApplicationStatus = -1;
            DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;
            decimal PaidFees = -1;

            //Get Local Driving License Application then Base Application 
            if (LocalLicenseApplicationData.GetApplicationInfo(LocalAppID, ref BaseAppID, ref LicenseClassID)
                && ApplicationData.GetApplicationInfo(BaseAppID, ref ApplicantPersonID, ref ApplicationDate,
                ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new LocalLicenseApplication(BaseAppID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                    ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID, LocalAppID, LicenseClassID);
            }
            else { return null; }

        }
        public int GetNumberOfPassedTests()
        {
            return LocalLicenseApplicationData.GetNumberOfPassedTestByID(LocalID);
        }
        public new static bool DeleteApplication(int LocalDrivingLicenseApplicationID)
        {
            int BaseApplicationID = Find(LocalDrivingLicenseApplicationID).ID;

            //Delete Local License Application First And Then Delete Base Application
            if (LocalLicenseApplicationData.Delete(LocalDrivingLicenseApplicationID))
            {
                return Application.DeleteApplication(BaseApplicationID);
            }

            return false;
        }
        public int GetActiveApplicationIDForLicenseClass(int PersonID, int LicenseClassID)
        {
            return LocalLicenseApplicationData.GetActiveApplicationIDForLicenseClass(PersonID, LicenseClassID);
        }
    }
}
