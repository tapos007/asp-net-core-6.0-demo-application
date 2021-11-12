using System;

namespace UniversityApp.BLL.ForDemo
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }

        public string GetFullName()
        {
            return FirstName +" " + LastName;
        }

        public bool IsYoungerEmployee()
        {
            if (Age < 0)
            {
                throw new Exception("age can not less than 0");
            }
            return Age <= 20;
        }

        public double GetHalfEarning()
        {
            return Salary / 2323;
        }
    }
}