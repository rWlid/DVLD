using System.Data;
using DVLD.DAL;
namespace DVLD.BL
{
    public class ApplicationType
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Fees { get; set; }
        private ApplicationType(int ID, string Title, decimal Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Fees = Fees;
        }
        public bool UpdateApplicationType()
        {
            return ApplicationTypeData.UpdateApplicationType(ID, Title, Fees);
        }
        public static DataTable GetAllApplicationTypes()
        {
            return ApplicationTypeData.GetAllApplicationTypes();
        }
        public static ApplicationType GetApplicationType(int ID)
        {
            string Title = string.Empty;
            decimal Fees = 0;

            if (ApplicationTypeData.GetApplicationTypeByID(ID, ref Title, ref Fees))
            {
                return new ApplicationType(ID, Title, Fees);
            }
            else { return null; }

        }

    }
}
