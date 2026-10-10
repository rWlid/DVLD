using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.DAL;

namespace DVLD.BL
{
    public class clsLocalLicenseApplicaiton : clsApplication
    {

        public int LocalID { get; set; }
        public int LicenseClassID {  get; set; }
        public clsLicenseClass LicenseClass;

        public clsLocalLicenseApplicaiton()
        {
            this.ID = -1;
            this.ApplicantID = -1;
            this.Type = null;
            this.ApplicantInfo = null;
            this.Date = DateTime.Now;
            this.LastStatus = enStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.Fees = -1;
            this.CreatorID = -1;
            this.LocalID = -1;
            this.LicenseClassID = -1;
            this.Mode = enMode.AddNew;
        }
        public clsLocalLicenseApplicaiton(int ID, int ApplicantID, DateTime Date, int TypeID, int LastStatus, DateTime LastStatusDate, decimal Fees, int CreatorID, int LocalID, int LicenseClassID)
                                          : base(ID,ApplicantID, Date, TypeID, LastStatus, LastStatusDate, Fees, CreatorID)
        {
            this.LocalID = LocalID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClass = clsLicenseClass.Find(LicenseClassID); 
            this.Mode = enMode.Update;
        }
        public static DataTable GetAllApplications()
        {
            return clsLocalLicenseApplicaitonData.GetAllApplications();
        }
        private bool _AddNewApplication()
        {
            this.LocalID = clsLocalLicenseApplicaitonData.AddNewApplication(this.ID, this.LicenseClassID);
            return (this.LocalID != -1);
        }
        private bool _UpdateLicenseClass()
        {
            return clsLocalLicenseApplicaitonData.UpdateLicenseClassInApplication(this.LocalID, this.LicenseClassID);
        }
        public override bool Save()
        {
            //Save base Application
            if (!base.Save()) { return false; }

            //New Application
            if (this.Mode == enMode.AddNew)
            {
                if(!_AddNewApplication()) { return false; }

                this.Mode = enMode.Update;
                return true;
            }

            //Alter License Class
            else
            {
                return _UpdateLicenseClass();
            }
        }
        public static clsLocalLicenseApplicaiton Find(int LocalAppID)
        {
            int BaseAppID = -1, LicenseClassID = -1, ApplicantPersonID = -1, CreatedByUserID = -1, ApplicationTypeID = -1, ApplicationStatus = -1;
            DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;
            decimal PaidFees = -1;

            //Get Local Driving License Application then Base Application 
            if (clsLocalLicenseApplicaitonData.GetApplicationInfo(LocalAppID, ref BaseAppID, ref LicenseClassID)
                && clsApplicationData.GetApplicationInfo(BaseAppID, ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new clsLocalLicenseApplicaiton(BaseAppID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID, LocalAppID, LicenseClassID);
            }
            else { return null; }

        }
        public int GetNumberOfPassedTests()
        {
            return clsLocalLicenseApplicaitonData.GetNumberOfPassedTestByID(this.LocalID);
        }
        public new static bool DeleteApplication(int LocalDrivingLicenseApplicationID)
        {
            int BaseApplicationID = Find(LocalDrivingLicenseApplicationID).ID;

            //Delete Local License Application First And Then Delete Base Application
            if (clsLocalLicenseApplicaitonData.Delete(LocalDrivingLicenseApplicationID))
            {
                return clsApplication.DeleteApplication(BaseApplicationID);
            }

            return false;
        }
        public int GetActiveApplicationIDForLicenseClass(int PersonID, int LicenseClassID)
        {
            return clsLocalLicenseApplicaitonData.GetActiveApplicationIDForLicenseClass(PersonID, LicenseClassID);
        }
    }
}
