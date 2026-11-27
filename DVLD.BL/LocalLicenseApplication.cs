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
            LocalID = -1;
            LicenseClassID = -1;
        }
        private LocalLicenseApplication(int ID, int ApplicantID, DateTime Date, int TypeID, int LastStatus,
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
            bool isNew = (Mode == Mode.AddNew);

            //Save base Application
            if (!base.Save()) { return false; }

            //New Application: base.Save() already set Mode = Update
            if (isNew)
            {
                return AddNewApplication();
            }

            //Alter License Class
            return UpdateLicenseClass();
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
