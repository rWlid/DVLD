using System.Data;
using DVLD.DAL;

namespace DVLD.BL
{
    public class User
    {
        public Mode Mode = Mode.AddNew;

        public int ID { get; set; }
        public int PersonID { get; set; }
        public Person PersonInfo;
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public User()
        {
            ID = -1;
            PersonID = -1;
            UserName = string.Empty;
            Password = string.Empty;
            IsActive = false;
            Mode = Mode.AddNew;
        }
        private User(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            ID = UserID;
            this.PersonID = PersonID;
            PersonInfo = Person.Find(PersonID);
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;

            Mode = Mode.Update;
        }
        private bool Validate()
        {
            if (PersonID == -1)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(UserName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                return false;
            }

            return true;
        }
        private bool AddNewUser()
        {
            ID = UserData.AddNewUser(PersonID, UserName, Password, IsActive);

            return (ID != -1);
        }
        private bool UpdateUser()
        {
            return UserData.UpdateUser(ID, PersonID, UserName, Password, IsActive);
        }
        public static DataTable GettAllUsers()
        {
            return UserData.GetAllUsers();
        }
        public static User FindByUserID(int UserID)
        {

            string UserName = "", Password = "";
            bool IsActive = false;
            int PersonID = -1;

            if (UserData.GetUserInfoByID(UserID, ref PersonID, ref UserName, ref IsActive))
            {
                return new User(UserID, PersonID, UserName, Password, IsActive);
            }
            else { return null; }

        }
        public static User FindByPersonID(int PersonID)
        {

            string UserName = "", Password = "";
            bool IsActive = false;
            int UserID = -1;

            if (UserData.GetUserInfoByPersonID(PersonID, ref UserID, ref UserName, ref IsActive))
            {
                return new User(UserID, PersonID, UserName, Password, IsActive);
            }
            else { return null; }

        }
        public static User FindByUsernameAndPassword(string UserName, string Password)
        {

            bool IsActive = false;
            int UserID = -1, PersonID = -1;

            if (UserData.GetUserInfoByUsernameAndPassword(UserName, Password, ref UserID, ref PersonID, ref IsActive))
            {
                return new User(UserID, PersonID, UserName, Password, IsActive);
            }
            else { return null; }
        }

        public static User Find(string UserName)
        {

            string Password = "";
            bool IsActive = false;
            int UserID = -1, PersonID = -1;

            if (UserData.GetUserInfoByUsername(UserName, ref UserID, ref PersonID, ref IsActive))
            {
                return new User(UserID, PersonID, UserName, Password, IsActive);
            }
            else { return null; }

        }
        public static bool DeleteUser(int UserID)
        {
            return UserData.DeleteUser(UserID);
        }
        public bool Save()
        {
            if (!Validate()) { return false; }

            switch (Mode)
            {
                case Mode.AddNew:
                    if (!User.IsUserExistForPerson(PersonID) && AddNewUser())
                    {
                        Mode = Mode.Update;
                        return true;
                    }
                    else { return false; }

                case Mode.Update:
                    return UpdateUser();

            }
            return false;
        }
        public static bool ChangeUserPassword(int UserID, string oldPassword, string newPassword)
        {
            if (!UserData.AreCredentialsValid(UserID, oldPassword))
            {
                return false;
            }
            return UserData.UpdatePassword(UserID, newPassword);
        }
        public static bool IsUserExist(int UserID)
        {
            return UserData.IsUserExist(UserID);
        }
        public static bool IsUserExist(string UserName)
        {
            return UserData.IsUserExist(UserName);
        }
        public static bool IsUserExistForPerson(int PersonID)
        {
            return UserData.IsUserExistForPerson(PersonID);
        }
        public static bool ValidateCredentials(string Username, string Password)
        {
            return UserData.AreCredentialsValid(Username, Password);
        }
    }
}
