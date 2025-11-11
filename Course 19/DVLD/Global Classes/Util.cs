using System;
using System.IO;
using System.Windows.Forms;

namespace DVLD.Global_Classes
{
    public class Util
    {
        public static string GenerateGUID()
        {
            Guid guid = new Guid();

            return guid.ToString();
        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }

            }

            return true;
        }

        public static string ReplaceFileNameWithGUID(string SourceFile)
        {
            string FileName = SourceFile;
            FileInfo Info = new FileInfo(FileName);
            string Extn = Info.Extension;
            
            return GenerateGUID() + Extn;
        }

        public static bool CopyImageToProjectImagesFolder(ref string SourceFile)
        {

            string DestinationDirectory = @"C:\DVLD-People-Images\";

            if (!Directory.Exists(DestinationDirectory)) 
                return false;

            string DestinationFile = DestinationDirectory + ReplaceFileNameWithGUID(SourceFile);

            try
            {
                File.Copy(SourceFile, DestinationFile, true);
            }
            catch(IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            SourceFile = DestinationFile;
            return true;    
        }
    }
}
