using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTestType
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;
        public int TestTypeID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Fees { get; set; }

        clsTestType() 
        {
            _Mode = enMode.AddNew;

            this.TestTypeID = -1;
            this.Title = "";
            this.Description = "";
            this.Fees = 0;
        }

        public clsTestType(int TestTypeID, string Title, string Description, float Fees)
        {
            _Mode = enMode.Update;

            this.TestTypeID = TestTypeID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestTypes();
        }

        public static clsTestType Find(int TestTypeID)
        {
            string Title = "", Description = "";
            float Fees = 0;

            if (clsTestTypeData.GetTestTypeDataByID(TestTypeID, ref Title, ref Description, ref Fees))
                return new clsTestType(TestTypeID, Title, Description, Fees);

            return null;
        }

        public bool _UpdateTestType()
        {
            return clsTestTypeData.UpdateTestType(this.TestTypeID, this.Title, this.Description, this.Fees);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.Update:
                    return _UpdateTestType();
            }

            return false;
        }
    }
}
