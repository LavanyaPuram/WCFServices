using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService
{
    public class Employee
    {
        #region Private class fields
            private int _id;
            private string _name;
            private string _gender;
            private DateTime _dob;
        #endregion
        #region Public properties
            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            public string Gender
            {
                get { return _gender; }
                set { _gender = value; }
            }
            public DateTime DOB
            {
                get { return _dob; }
                set { _dob = value; }
            }
        #endregion
    }
    
}

