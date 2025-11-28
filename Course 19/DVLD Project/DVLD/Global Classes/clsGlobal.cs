using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD.Global_Classes
{
    public class clsGlobal
    {
        public static clsUser CurrentUser;

        private static string _CurrentUserDataPath = Directory.GetCurrentDirectory() + "\\CurrentUserCredentials.txt";
        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            try
            {
                if (Username == "" && File.Exists(_CurrentUserDataPath))
                {
                    File.Delete(_CurrentUserDataPath);
                    return true;
                }

                string DataToSave = Username + "#//#" + Password;

                using (StreamWriter sw = File.CreateText(_CurrentUserDataPath))
                {
                    sw.WriteLine(DataToSave);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            try
            {
                if (!File.Exists(_CurrentUserDataPath)) return false;

                using (StreamReader sr = File.OpenText(_CurrentUserDataPath))
                {
                    string UserDataLine = sr.ReadLine();

                    if (UserDataLine != null)
                    {
                        string[] UserData = UserDataLine.Split(new string[] { "#//#" }, StringSplitOptions.None);

                        Username = UserData[0];
                        Password = UserData[1];

                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

        
    }
}
