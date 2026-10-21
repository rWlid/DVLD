using System;
using System.Data;
using System.IO;
using DVLD.DAL;

namespace DVLD.BL
{
    public class Person
    {
        public Mode Mode = Mode.AddNew;

        public int ID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }

        }
        public DateTime DateOfBirth { get; set; }
        public short Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CountryID { get; set; }
        public string ImagePath { get; set; }
        public Country CountryInfo { get; set; }
        public Person()
        {
            ID = -1;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = null;
            LastName = string.Empty;
            DateOfBirth = DateTime.Now.AddYears(-18);
            Gender = 0;
            Address = string.Empty;
            Phone = string.Empty;
            Email = null;
            CountryID = -1;
            ImagePath = null;
            Mode = Mode.AddNew;
        }

        private Person(int ID, string NationalNo, string FirstName, string SecondName,
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
            CountryInfo = Country.Find(CountryID);
            Mode = Mode.Update;
        }
        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(NationalNo))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(FirstName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(SecondName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(LastName))
            {
                return false;
            }

            if (DateOfBirth == null)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Address))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Phone))
            {
                return false;
            }

            if (CountryID == -1)
            {
                return false;
            }

            return true;
        }
        private bool AddNewPerson()
        {
            ID = PersonData.AddNewPerson(NationalNo, FirstName, SecondName,
             ThirdName, LastName, DateOfBirth, Gender,
             Address, Phone, Email, CountryID, ImagePath);

            return (ID != -1);
        }
        private bool UpdatePerson()
        {
            return PersonData.UpdatePerson(ID, NationalNo, FirstName, SecondName,
             ThirdName, LastName, DateOfBirth, Gender,
             Address, Phone, Email, CountryID, ImagePath);
        }
        private static bool DeletePersonImage(int PersonID)
        {
            string imagePath = PersonData.GetPersonImagePathByID(PersonID);
            if (!string.IsNullOrEmpty(imagePath))
            {
                try
                {
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }
        public static DataTable GetAllPeople()
        {
            return PersonData.GetAllPeople();
        }
        public static Person Find(int ID)
        {

            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "",
                Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int CountryID = -1;
            short Gender = 1;

            if (PersonData.GetPersonInfoByID(ID, ref NationalNo, ref FirstName, ref SecondName,
            ref ThirdName, ref LastName, ref DateOfBirth, ref Gender,
            ref Address, ref Phone, ref Email, ref CountryID, ref ImagePath))
            {
                return new Person(ID, NationalNo, FirstName, SecondName,
                            ThirdName, LastName, DateOfBirth, Gender,
                            Address, Phone, Email, CountryID, ImagePath);
            }
            else { return null; }

        }
        public static Person Find(string NationalNo)
        {

            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "",
                Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int ID = -1, CountryID = -1;
            short Gender = 1;

            bool found = PersonData.GetPersonInfoByNationalNo(NationalNo, ref ID, ref FirstName, ref SecondName,
            ref ThirdName, ref LastName, ref DateOfBirth, ref Gender,
            ref Address, ref Phone, ref Email, ref CountryID, ref ImagePath);

            if (found)
            {
                return new Person(ID, NationalNo, FirstName, SecondName,
                            ThirdName, LastName, DateOfBirth, Gender,
                            Address, Phone, Email, CountryID, ImagePath);
            }
            else { return null; }

        }
        public static bool DeletePerson(int PersonID)
        {
            return DeletePersonImage(PersonID) && PersonData.DeletePerson(PersonID);
        }
        public bool Save()
        {
            if (!Validate()) { return false; }

            switch (Mode)
            {
                case Mode.AddNew:
                    if (AddNewPerson())
                    {
                        Mode = Mode.Update;
                        return true;
                    }
                    else { return false; }

                case Mode.Update:
                    return UpdatePerson();

            }
            return false;
        }
        public static bool IsPersonExist(int PersonID)
        {
            return PersonData.IsPersonExist(PersonID);
        }
        public static bool IsPersonExist(string NationalNo)
        {
            return PersonData.IsPersonExist(NationalNo);
        }
    }
}
