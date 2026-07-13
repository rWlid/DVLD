using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.DAL;

namespace DVLD.BL
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public int PersonID { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }

        public clsUser()
        {
            this.ID = -1;
            this.PersonID = -1;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.IsActive = false;
            Mode = enMode.AddNew;
        }
        public clsUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.ID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            Mode = enMode.Update;
        }
        private bool _Validate()
        {
            if (this.PersonID == -1) return false;
            if (string.IsNullOrWhiteSpace(this.UserName)) return false;
            if (string.IsNullOrWhiteSpace(this.Password)) return false;

            return true;
        }
        private bool _AddNewUser()
        {
            this.ID = clsUserData.AddNewUser(this.PersonID,this.UserName,this.Password,this.IsActive) ;

            return (this.ID != -1);
        }
        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.ID,this.PersonID,this.UserName,this.Password,this.IsActive);
        }
        private bool _UpdatePassword()
        {
            return clsUserData.UpdatePassword(this.ID, this.Password);
        }
        public static DataTable GettAllUsers()
        {
            return clsUserData.GetAllUsers();
        }
        public static clsUser Find(int ID)
        {

            string UserName = "", Password = "";
            bool IsActive = false;
            int PersonID = -1;

            if (clsUserData.GetUserInfoByID(ID, ref PersonID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUser(ID,PersonID,UserName,Password,IsActive);
            }
            else { return null; }

        }
        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }
        public bool Save()
        {
            if (!_Validate()) { return false; }

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else { return false; }

                case enMode.Update:
                    return _UpdateUser();

            }
            return false;
        }
        public static bool ChangeUserPassword(int UserID, string oldPassword, string newPassword)
        {
            if (!clsUserData.AreCredintialValid(UserID, oldPassword))
            {
                return false;
            }
            return clsUserData.UpdatePassword(UserID,newPassword);
        } 
        public static bool IsUserNameExist(string UserName)
        {
            return clsUserData.IsUserNameExist(UserName);
        }
    }
}
