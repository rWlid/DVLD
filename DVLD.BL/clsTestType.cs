using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.DAL;

namespace DVLD.BL
{
    public class clsTestType
    {
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
        public enTestType ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }
        private clsTestType(enTestType ID, string Title, string Description, decimal Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
        }
        public bool UpdateTestType()
        {
            return clsTestTypeData.UpdateTestType((int)this.ID, this.Title, this.Description, this.Fees);
        }
        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestTypes();
        }
        public static clsTestType Find(enTestType ID)
        {
            string Title = string.Empty, Description = string.Empty;
            decimal Fees = 0;

            if (clsTestTypeData.GetTestTypeByID((int)ID, ref Title, ref Description, ref Fees))
            {
                return new clsTestType(ID, Title, Description, Fees);
            }
            else { return null; }

        }
    }
}
