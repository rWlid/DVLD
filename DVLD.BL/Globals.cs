using System.IO;
using DVLD.BL;

namespace DVLD.BL
{
    public static class Globals
    {
        public static User CurrentUser;
        public static (string Username, string Password) GetStoredCredentials()
        {
            string[] credentials = File.ReadAllLines(@"D:\LastLoginUser.txt");
            return (credentials[0], credentials[1]);
        }
        public static void StoreCredentials(string Username, string Password)
        {
            File.WriteAllLines(@"D:\LastLoginUser.txt", new string[] { Username, Password });
        }
    }
}
