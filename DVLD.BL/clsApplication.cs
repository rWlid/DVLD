using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DVLD.DAL;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.BL
{
    public class clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enStatus { New = 1, Cancelled  = 2, Complated = 3 };


        public int ID { get; set; }
        public int ApplicantID {  get; set; }
        public clsPerson ApplicantInfo;
        public clsApplicationType Type {  get; set; }
        public DateTime Date { get; set; }
        public enStatus LastStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal Fees { get; set; }
        public int CreatorID { get; set; }
        public string CreatorUsername
        {
            get
            {
                return clsUser.FindByUserID(this.CreatorID).UserName;
            }
        }
        public clsApplication()
        {
            ID = -1;
            ApplicantID = -1;
            Type = null;
            ApplicantInfo = null;
            Date = DateTime.Now;
            LastStatus = enStatus.New;
            LastStatusDate = DateTime.Now;
            Fees = -1;
            CreatorID = -1;
            Mode = enMode.AddNew;
        }
        private clsApplication(int ID, int ApplicantID, DateTime Date, int TypeID, int LastStatus, DateTime LastStatusDate, decimal Fees, int CreatorID)
        {
            Mode = enMode.Update;
            this.ID = ID;
            this.ApplicantID = ApplicantID;
            this.ApplicantInfo = clsPerson.Find(ApplicantID);
            this.Type = clsApplicationType.GetApplicationType(TypeID);
            this.Date = Date;
            this.LastStatus = (enStatus)LastStatus;
            this.LastStatusDate = LastStatusDate;
            this.Fees = Fees;
            this.CreatorID = CreatorID;
        }
        private bool _AddNewApplication()
        {
            this.ID = clsApplicationData.AddNewApplication(this.ApplicantID,this.Date,this.Type.ID,(int)this.LastStatus,this.LastStatusDate,this.Fees,this.CreatorID);
            return (this.ID != -1);
        }
        private bool _UpdateStatus()
        {
            return clsApplicationData.UpdateApplicationStatus(this.ID, (int)this.LastStatus, this.LastStatusDate);
        }
        public bool Save()
        {
            //New Application
            if(Mode == enMode.AddNew && _AddNewApplication())
            {
                Mode = enMode.Update;
                return true;
            }
            
            //Alter Application Status
            else
            {
                return _UpdateStatus();
            }
        }
        public static clsApplication Find(int ID)
        {
            int ApplicantPersonID = -1;  DateTime ApplicationDate = DateTime.Now;  int ApplicationTypeID = -1;  int ApplicationStatus = -1;
             DateTime LastStatusDate = DateTime.Now;  decimal PaidFees = -1;  int CreatedByUserID = -1;

            if (clsApplicationData.GetApplicationInfo(ID, ref ApplicantPersonID, ref  ApplicationDate, ref  ApplicationTypeID, ref  ApplicationStatus,
            ref  LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new clsApplication(ID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            }
            else { return null; }
        }
        public static bool DeleteApplication(int ApplicationID)
        {
            return clsApplicationData.Delete(ApplicationID);
        }
    }
}
