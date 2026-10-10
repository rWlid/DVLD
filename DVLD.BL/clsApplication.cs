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
        public enum enStatus { Unknown = 0, New = 1, Cancelled  = 2, Completed = 3 };


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
        protected clsApplication(int ID, int ApplicantID, DateTime Date, int TypeID, int LastStatus, DateTime LastStatusDate, decimal Fees, int CreatorID)
        {
            this.ID = ID;
            this.ApplicantID = ApplicantID;
            this.ApplicantInfo = clsPerson.Find(ApplicantID);
            this.Type = clsApplicationType.GetApplicationType(TypeID);
            this.Date = Date;
            this.LastStatus = (enStatus)LastStatus;
            this.LastStatusDate = LastStatusDate;
            this.Fees = Fees;
            this.CreatorID = CreatorID;
            Mode = enMode.Update;
        }
        private bool _AddNewApplication()
        {
            this.ID = clsApplicationData.AddNewApplication(this.ApplicantID,this.Date,this.Type.ID,(int)this.LastStatus,this.LastStatusDate,this.Fees,this.CreatorID);
            return (this.ID != -1);
        }
        private bool _UpdateStatus()
        {
            return clsApplicationData.UpdateApplicationStatus(this.ID, (int)this.LastStatus);
        }
        public bool Cancel()
        {
            this.LastStatus = enStatus.Cancelled;
            return _UpdateStatus();
        }
        public virtual bool Save()
        {
            //New Application
            if (this.Mode == enMode.AddNew)
            {
                if (!_AddNewApplication()) { return false; }

                this.Mode = enMode.Update;
                return true;
            }

            //Alter License Class
            else
            {
                return _UpdateStatus();
            }
        }
        public static bool DeleteApplication(int ApplicationID)
        {
            return clsApplicationData.Delete(ApplicationID);
        }
    }
}
