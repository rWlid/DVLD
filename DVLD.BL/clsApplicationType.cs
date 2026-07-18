using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.DAL;
namespace DVLD.BL
{
    public class clsApplicationType
    {
        public int ID {  get; set; }
        public string Title { get; set; }
        public decimal Fees { get; set; }
        private clsApplicationType(int ID, string Title, decimal Fees) 
        {
            this.ID = ID;
            this.Title = Title;
            this.Fees = Fees;
        }
        public bool UpdateApplicationType()
        {
            return clsApplicationTypeData.UpdateApplicationType(this.ID, this.Title, this.Fees);
        }
        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypeData.GetAllApplicationTypes();
        }
        public static clsApplicationType GetApplicationType(int ID) 
        {
            string Title = string.Empty;
            decimal Fees = 0;

            if(clsApplicationTypeData.GetApplicationTypeByID(ID, ref Title, ref Fees))
            {
                return new clsApplicationType(ID, Title, Fees);
            }
            else { return null; }

        }
        
    }
}
