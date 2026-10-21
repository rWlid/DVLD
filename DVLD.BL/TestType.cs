using System.Data;
using DVLD.DAL;

namespace DVLD.BL
{
    public class TestType
    {
        public enum TestKind { VisionTest = 1, WrittenTest = 2, StreetTest = 3 }
        public TestKind ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }
        private TestType(TestKind ID, string Title, string Description, decimal Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
        }
        public bool UpdateTestType()
        {
            return TestTypeData.UpdateTestType((int)ID, Title, Description, Fees);
        }
        public static DataTable GetAllTestTypes()
        {
            return TestTypeData.GetAllTestTypes();
        }
        public static TestType Find(TestKind ID)
        {
            string Title = string.Empty, Description = string.Empty;
            decimal Fees = 0;

            if (TestTypeData.GetTestTypeByID((int)ID, ref Title, ref Description, ref Fees))
            {
                return new TestType(ID, Title, Description, Fees);
            }
            else { return null; }

        }
    }
}
