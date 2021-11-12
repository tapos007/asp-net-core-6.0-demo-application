using UniversityApp.BLL.ForDemo;
using Xunit;

namespace UniversityApp.BLL.Testing
{
    public class CalulatorTesting
    {
        [Fact]
        public void TestCalculator()
        {
            var calculator = new Calculator();
            var result = calculator.Add(3, 4);
            Assert.Equal(7,7);
        }

        [Theory]
        [InlineData(3,5,8)]
        [InlineData(30,20,50)]
        [InlineData(2,1,3)]
        [InlineData(3,3,6)]
        public void TestCalculatorTheory(int value1, int value2, int expected)
        {
            var calculator = new Calculator();
            var result = calculator.Add(value1, value2);
            Assert.Equal(expected,result);
        }
    }
    
    
    // [Theory]
    // [InlineData(1, 2, 3)]
    // [InlineData(-4, -6, -10)]
    // [InlineData(-2, 2, 0)]
    // [InlineData(int.MinValue, -1, int.MaxValue)]
    // public void CanAddTheory(int value1, int value2, int expected)
    // {
    // var calculator = new Calculator();
    //
    // var result = calculator.Add(value1, value2);
    //
    // Assert.Equal(expected, result);
    // }
}