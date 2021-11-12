using System;
using UniversityApp.BLL.ForDemo;
using Xunit;

namespace UniversityApp.BLL.Testing
{
    public class EmployeeTesting
    {
        [Fact]
        public void FullNameTest()
        {
            // arrange
            Employee employee = new Employee();
            employee.FirstName = "tapos";
            employee.LastName = "ghosh";

            // act
            var fullName = employee.GetFullName();

            // assert

            Assert.Equal("tapos ghosh", fullName);
        }

        [Fact]
        public void EmployeeNullInformationTest()
        {
            // arrange
            Employee employee = new Employee();

            // act

            //assert
            Assert.Null(employee.FirstName);
            Assert.Null(employee.FirstName);
            Assert.Null(employee.LastName);
            Assert.True(employee.IsYoungerEmployee());
            employee.FirstName = "tapos";
            Assert.NotNull(employee.FirstName);
        }

        [Fact]
        public void EmployeeFullNameTesting()
        {
            /*
             * this area for string testing rules
             */

            // arrange
            Employee employee = new Employee();
            employee.FirstName = "tapos";
            employee.LastName = "ghosh";


            // act
            var fullName = employee.GetFullName();

            //assert

            Assert.StartsWith("ta", fullName);
            Assert.EndsWith("sh", fullName);
            Assert.Contains("OS", fullName, StringComparison.OrdinalIgnoreCase);
            Assert.StrictEqual("tapos", employee.FirstName);
            Assert.Equal("tapos ghosh", fullName);
        }

        [Fact]
        public void EmployeeAgeTesting()
        {
            /*
             * this area for integer / long testing rules
             */

            // arrange
            Employee employee = new Employee();
            employee.Age = 66;


            // act

            //assert

            Assert.Equal(66, employee.Age);
            Assert.NotEqual(32, employee.Age);
            Assert.False(employee.Age > 20 && employee.Age < 50);
            Assert.InRange(employee.Age, 60, 70);
        }

        [Fact]
        public void EmployeeSalaryTesting()
        {
            /*
             * this area for decimal value  testing rules
             */

            // arrange 
            Employee employee = new Employee();
            employee.Salary = 34565366;

            // act
            var earning = employee.GetHalfEarning();


            // assert
            Assert.Equal(14879.624, earning, 3);
        }

        [Fact]
        public void EmployeeAgeExceptionTesting()
        {
            // arrange
            Employee employee = new Employee();
            employee.Age = -30;

            // act

            var exception = Assert.Throws<Exception>(() => employee.IsYoungerEmployee());
            Assert.Throws<Exception>(() => employee.IsYoungerEmployee());
            Assert.Equal("age can not less than 0", exception.Message);
            Assert.IsType(typeof(Exception), exception);

            // assert
        }
        
        
    }
}