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
        public clsPerson PersonInfo;
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
        private clsUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.ID = UserID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
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
        public static DataTable GettAllUsers()
        {
            return clsUserData.GetAllUsers();
        }
        public static clsUser FindByUserID(int UserID)
        {

            string UserName = "", Password = "";
            bool IsActive = false;
            int PersonID = -1;

            if (clsUserData.GetUserInfoByID(UserID, ref PersonID, ref UserName, ref IsActive))
            {
                return new clsUser(UserID, PersonID,UserName,Password,IsActive);
            }
            else { return null; }

        }
        public static clsUser FindByPersonID(int PersonID)
        {

            string UserName = "", Password = "";
            bool IsActive = false;
            int UserID = -1;

            if (clsUserData.GetUserInfoByPersonID(PersonID, ref UserID, ref UserName, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            else { return null; }

        }
        public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        {

            bool IsActive = false;
            int UserID = -1, PersonID = -1;

            if (clsUserData.GetUserInfoByUsernameAndPassword(UserName, Password, ref UserID, ref PersonID, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            else { return null; }
        }

        public static clsUser Find(string UserName)
        {

            string Password = "";
            bool IsActive = false;
            int UserID = -1, PersonID = -1;

            if (clsUserData.GetUserInfoByUsername(UserName, ref UserID, ref PersonID, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
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
                    if (!clsUser.IsUserExistForPerson(this.PersonID) && _AddNewUser())
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
            if (!clsUserData.AreCredintialsValid(UserID, oldPassword))
            {
                return false;
            }
            return clsUserData.UpdatePassword(UserID,newPassword);
        }
        public static bool IsUserExist(int UserID)
        {
            return clsUserData.IsUserExist(UserID);
        }
        public static bool IsUserExist(string UserName)
        {
            return clsUserData.IsUserExist(UserName);
        }
        public static bool IsUserExistForPerson(int PersonID)
        {
            return clsUserData.IsUserExistForPerson(PersonID);
        }
        public static bool ValidateCredintials(string Username, string Password)
        {
            return clsUserData.AreCredintialsValid(Username, Password);
        }
    }
}
