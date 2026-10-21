using DVLD.DAL;

namespace DVLD.BL
{
    public class LicenseClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinimumAge { get; set; }
        public int ValidityLength { get; set; }
        public decimal Fees { get; set; }
        public LicenseClass()
        {
            ID = -1;
            Name = string.Empty;
            Description = string.Empty;
            MinimumAge = -1;
            ValidityLength = -1;
            Fees = -1;

        }
        private LicenseClass(int ID, string Name, string Description, int MinimumAge, int ValidityLength, decimal Fees)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.MinimumAge = MinimumAge;
            this.ValidityLength = ValidityLength;
            this.Fees = Fees;

        }
        public static LicenseClass Find(int ID)
        {
            string Name = string.Empty, Description = string.Empty;
            int MinimumAge = -1, ValidityLength = -1;
            decimal Fees = -1;

            if (LicenseClassData.GetLicenseClassInfo(ID, ref Name, ref Description, ref MinimumAge,
                ref ValidityLength, ref Fees))
            {
                return new LicenseClass(ID, Name, Description, MinimumAge, ValidityLength, Fees);
            }
            else { return null; }

        }
    }
}
