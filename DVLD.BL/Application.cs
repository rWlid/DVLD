using System;
using DVLD.DAL;

namespace DVLD.BL
{
    public class Application
    {
        public Mode Mode = Mode.AddNew;
        public enum Status { Unknown = 0, New = 1, Cancelled = 2, Completed = 3 }


        public int ID { get; set; }
        public int ApplicantID { get; set; }
        public Person ApplicantInfo;
        public ApplicationType Type { get; set; }
        public DateTime Date { get; set; }
        public Status LastStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal Fees { get; set; }
        public int CreatorID { get; set; }
        public string CreatorUsername
        {
            get
            {
                return User.FindByUserID(CreatorID).UserName;
            }
        }
        public Application()
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
            Mode = Mode.AddNew;
        }
        protected Application(int ID, int ApplicantID, DateTime Date, int TypeID, int LastStatus,
            DateTime LastStatusDate, decimal Fees, int CreatorID)
        {
            this.ID = ID;
            this.ApplicantID = ApplicantID;
            ApplicantInfo = Person.Find(ApplicantID);
            Type = ApplicationType.GetApplicationType(TypeID);
            this.Date = Date;
            this.LastStatus = (Status)LastStatus;
            this.LastStatusDate = LastStatusDate;
            this.Fees = Fees;
            this.CreatorID = CreatorID;
            Mode = Mode.Update;
        }
        private bool AddNewApplication()
        {
            ID = ApplicationData.AddNewApplication(ApplicantID, Date, Type.ID, (int)LastStatus,
                LastStatusDate, Fees, CreatorID);
            return (ID != -1);
        }
        private bool UpdateStatus()
        {
            return ApplicationData.UpdateApplicationStatus(ID, (int)LastStatus);
        }
        public bool Cancel()
        {
            LastStatus = Status.Cancelled;
            return UpdateStatus();
        }
        public virtual bool Save()
        {
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
                return UpdateStatus();
            }
        }
        public static bool DeleteApplication(int ApplicationID)
        {
            return ApplicationData.Delete(ApplicationID);
        }
    }
}
