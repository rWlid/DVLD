using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }

        }
        public DateTime DateOfBirth { set; get; }
        public short Gender { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int CountryID { set; get; }
        public string ImagePath { set; get; }
        public clsCountry CountryInfo { set; get; }
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
            string ThirdName, string LastName, DateTime DateOfBirth, short Gender,
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
            this.CountryInfo = clsCountry.Find(CountryID);
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
        private bool _AddNewPerson()
        {
            this.ID = clsPersonData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName,
             this.ThirdName, this.LastName, this.DateOfBirth, this.Gender,
             this.Address, this.Phone, this.Email, this.CountryID, this.ImagePath);

            return (this.ID != -1);
        }
        private bool _UpdatePerson() 
        {
            return clsPersonData.UpdatePerson(this.ID, this.NationalNo, this.FirstName, this.SecondName,
             this.ThirdName, this.LastName, this.DateOfBirth, this.Gender,
             this.Address, this.Phone, this.Email, this.CountryID, this.ImagePath);
        }
        private static bool _DeletePersonImage(int PersonID)
        {
            string imagePath = clsPersonData.GetPersonImagePathByID(PersonID);
            if (!string.IsNullOrEmpty(imagePath))
            {
                try
                {
                    if (File.Exists(imagePath))
                        File.Delete(imagePath);

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }
        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }
        public static clsPerson Find(int ID)
        {

            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "",
                Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int CountryID = -1;
            short Gender = 1;

            if (clsPersonData.GetPersonInfoByID(ID, ref NationalNo, ref FirstName, ref SecondName,
            ref ThirdName, ref LastName, ref DateOfBirth, ref Gender,
            ref Address, ref Phone, ref Email, ref CountryID, ref ImagePath))
            {
                return new clsPerson(ID, NationalNo, FirstName, SecondName,
                            ThirdName, LastName, DateOfBirth, Gender,
                            Address, Phone, Email, CountryID, ImagePath);
            }
            else { return null; }
                
        }
        public static clsPerson Find(string NationalNo)
        {

            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "",
                Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int ID = -1, CountryID = -1;
            short Gender = 1;

            bool found = clsPersonData.GetPersonInfoByNationalNo(NationalNo, ref ID, ref FirstName, ref SecondName,
            ref ThirdName, ref LastName, ref DateOfBirth, ref Gender,
            ref Address, ref Phone, ref Email, ref CountryID, ref ImagePath);

            if (found)
            {
                return new clsPerson(ID, NationalNo, FirstName, SecondName,
                            ThirdName, LastName, DateOfBirth, Gender,
                            Address, Phone, Email, CountryID, ImagePath);
            }
            else { return null; }

        }
        public static bool DeletePerson(int PersonID)
        {
            return _DeletePersonImage(PersonID) && clsPersonData.DeletePerson(PersonID);
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
        public static bool IsPersonExist(int PersonID)
        {
            return clsPersonData.IsPersonExist(PersonID);
        }
        public static bool IsPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }
    }
}
