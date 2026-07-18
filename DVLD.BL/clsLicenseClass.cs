using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.DAL;

namespace DVLD.BL
{
    public class clsLicenseClass
    {
        public int ID { get; set;}
        public string Name { get; set;}
        public string Description { get; set;}
        public int MinimumAge { get; set;}
        public int ValidityLength { get; set; }
        public decimal Fees { get; set;}
        public clsLicenseClass() 
        {
            this.ID = -1;
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.MinimumAge = -1;
            this.ValidityLength = -1;
            this.Fees = -1;

        }
        private clsLicenseClass(int ID, string Name, string Description, int MinimumAge, int ValidityLength, decimal Fees)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.MinimumAge = MinimumAge;
            this.ValidityLength = ValidityLength;
            this.Fees = Fees;

        }
        public static clsLicenseClass Find(int ID)
        {
            string Name = string.Empty, Description = string.Empty;
            int MinimumAge = -1, ValidityLength = -1;
            decimal Fees = -1;

            if(clsLicenseClassData.GetLicenseClassInfo(ID, ref Name, ref Description, ref MinimumAge, ref ValidityLength, ref Fees))
            {
                return new clsLicenseClass(ID, Name, Description, MinimumAge, ValidityLength, Fees);
            }
            else { return null; }

        }
    }
}
