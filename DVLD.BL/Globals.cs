using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.BL;

namespace DVLD
{
    public static class Globals
    {
        public static clsUser CurrentUser;
        public static (string Username, string Password) GetStoredCredintials()
        {
            string[] credintials = File.ReadAllLines(@"D:\LastLoginUser.txt");
            return (credintials[0], credintials[1]);
        }
        public static void StoreCredintials(string Username, string Password)
        {
            File.WriteAllLines(@"D:\LastLoginUser.txt", new string[] { Username, Password });
        }
    }
}
