using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.DAL;

namespace DVLD.BL
{
    public class clsLocalLicenseApplicaiton
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { get; set; }
        public int BaseApplicationID { get; set; }
        public clsApplication ApplicationInfo;
        public int LicenseClassID {  get; set; }
        public clsLicenseClass LicenseClass;

        public clsLocalLicenseApplicaiton()
        {
            this.ID = -1;
            this.BaseApplicationID = -1;
            ApplicationInfo = new clsApplication();
            this.LicenseClassID = -1;
            Mode = enMode.AddNew;
        }
        public clsLocalLicenseApplicaiton(int ID, int ApplicationID, int LicenseClassID)
        {
            this.ID = ID;
            this.BaseApplicationID = ApplicationID;
            ApplicationInfo = clsApplication.Find(ApplicationID);
            this.LicenseClassID = LicenseClassID;
            this.LicenseClass = clsLicenseClass.Find(LicenseClassID); 
            Mode = enMode.Update;
        }
        public static DataTable GetAllApplications()
        {
            return clsLocalLicenseApplicaitonData.GetAllApplications();
        }
        private bool _AddNewApplication()
        {
            this.ID = clsLocalLicenseApplicaitonData.AddNewApplication(this.BaseApplicationID, this.LicenseClassID);
            return (this.ID != -1);
        }
        private bool _UpdateLicenseClass()
        {
            return clsLocalLicenseApplicaitonData.UpdateLicenseClassInApplication(this.ID, this.LicenseClassID);
        }
        public bool Save()
        {
            //Save base Application
            if (!this.ApplicationInfo.Save()) { return false; }

            this.BaseApplicationID = this.ApplicationInfo.ID;

            //New Application
            if (Mode == enMode.AddNew && _AddNewApplication())
            {
                Mode = enMode.Update;
                return true;
            }

            //Alter License Class
            else
            {
                return _UpdateLicenseClass();
            }
        }
        public static clsLocalLicenseApplicaiton Find(int ID)
        {
            int ApplicationID = -1, LicenseClassID = -1;

            if (clsLocalLicenseApplicaitonData.GetApplicationInfo(ID, ref ApplicationID, ref LicenseClassID))
            {
                return new clsLocalLicenseApplicaiton(ID, ApplicationID, LicenseClassID);
            }
            else { return null; }

        }
        public int GetNumberOfPassedTests()
        {
            return clsLocalLicenseApplicaitonData.GetNumberOfPassedTestByID(this.ID);
        }
        public static bool DeleteApplication(int LocalDrivingLicenseApplicationID)
        {
            int BaseApplicationID = Find(LocalDrivingLicenseApplicationID).BaseApplicationID;

            //Delete Local License Application First And Then Delete Base Application
            return clsLocalLicenseApplicaitonData.Delete(LocalDrivingLicenseApplicationID) 
                   && clsApplication.DeleteApplication(BaseApplicationID);
        }
        public int GetActiveApplicationIDForLicenseClass(int PersonID, int LicenseClassID)
        {
            return clsLocalLicenseApplicaitonData.GetActiveApplicationIDForLicenseClass(PersonID, LicenseClassID);
        }
    }
}
