using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.DAL;

namespace DVLD.BL
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public string NationalNo { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public DateTime DateOfBirth { set; get; }
        public byte Gender { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int CountryID { set; get; }
        public string ImagePath { set; get; }

        public clsPerson()
        {
            this.ID = -1;
            this.NationalNo = string.Empty;
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;
            this.ThirdName = null;
            this.LastName = string.Empty;
            this.DateOfBirth = DateTime.Now.AddYears(-18);
            this.Gender = 0;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Email = null;
            this.CountryID = -1;
            this.ImagePath = null;

            Mode = enMode.AddNew;
        }

        private clsPerson(int ID, string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, DateTime DateOfBirth, byte Gender,
            string Address, string Phone, string Email, int CountryID, string ImagePath)
        {
            this.ID = ID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.CountryID = CountryID;
            this.ImagePath = ImagePath;
            Mode = enMode.Update;
        }
        private bool _Validate()
        {
            if (string.IsNullOrWhiteSpace(this.NationalNo)) return false;
            if (string.IsNullOrWhiteSpace(this.FirstName)) return false;
            if (string.IsNullOrWhiteSpace(this.SecondName)) return false;
            if (string.IsNullOrWhiteSpace(this.LastName)) return false;
            if (this.DateOfBirth == null) return false;
            if (string.IsNullOrWhiteSpace(this.Address)) return false;
            if (string.IsNullOrWhiteSpace(this.Phone)) return false;
            if (this.CountryID == -1) return false;

            return true;
        }
        private bool _UpdatePerson() 
        {
            return clsPersonDataAccess.UpdatePerson(this.ID, this.NationalNo, this.FirstName, this.SecondName,
             this.ThirdName, this.LastName, this.DateOfBirth, this.Gender,
             this.Address, this.Phone, this.Email, this.CountryID, this.ImagePath);
        }
        private bool _AddNewPerson()
        {
            this.ID = clsPersonDataAccess.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName,
             this.ThirdName, this.LastName, this.DateOfBirth, this.Gender,
             this.Address, this.Phone, this.Email, this.CountryID, this.ImagePath);

            return (this.ID != -1);
        }
        public static DataTable GetAllPeople()
        {
            return clsPersonDataAccess.GetAllPeople();
        }
        public static clsPerson Find(int ID)
        {

            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "",
                Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int CountryID = -1;
            byte Gender = 1;

            if (clsPersonDataAccess.GetPersonInfoByID(ID, ref  NationalNo, ref  FirstName, ref  SecondName,
            ref  ThirdName, ref  LastName, ref  DateOfBirth, ref  Gender,
            ref  Address, ref  Phone, ref  Email, ref  CountryID, ref ImagePath))
            {
                return new clsPerson(ID, NationalNo, FirstName, SecondName,
                            ThirdName, LastName, DateOfBirth, Gender,
                            Address, Phone, Email, CountryID, ImagePath);
            }
            else { return null; }
                
        }
        public static bool DeletePerson(int PersonID)
        {
            if (clsPersonDataAccess.IsPersonExist(PersonID))
            {
                return clsPersonDataAccess.DeletePerson(PersonID);
            }

            return false;
        }
        public bool Save()
        {
            if (!_Validate()) {  return false; }

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else { return false; }

                case enMode.Update:
                    return _UpdatePerson();

            }
            return false;
        }
        
    }
}
