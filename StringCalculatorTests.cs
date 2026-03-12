using Xunit;
using StringCalc = global::StringCalculator.StringCalculator;

namespace StringCalculator.Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void Add_EmptyString_ReturnsZero()
        {
            var calc = new StringCalc();

            int result = calc.Add("");

            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_SingleNumber_ReturnsNumber()
        {
            var calc = new StringCalc();

            int result = calc.Add("1");

            Assert.Equal(1, result);
        }

        [Fact]
        public void Add_TwoNumbers_ReturnsSum()
        {
            var calc = new StringCalc();

            int result = calc.Add("1,2");

            Assert.Equal(3, result);
        }

        [Fact]
        public void Add_MultipleNumbers_ReturnsSum()
        {
            var calc = new StringCalc();

            int result = calc.Add("1,2,3,4");

            Assert.Equal(10, result);
        }

        [Fact]
        public void Add_NegativeNumber_ThrowsException()
        {
            var calc = new StringCalc();

            var ex = Assert.Throws<System.Exception>(() => calc.Add("1,-2,3,-4"));

            Assert.Contains("negatives not allowed", ex.Message);
        }

        [Fact]
        public void Add_NumbersGreaterThan1000_Ignored()
        {
            var calc = new StringCalc();

            int result = calc.Add("2,1001");

            Assert.Equal(2, result);
        }

        [Fact]
        public void Add_CustomDelimiter_ReturnsSum()
        {
            var calc = new StringCalc();

            int result = calc.Add("//[*]//1*2*3");

            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_MultipleDelimiters_ReturnsSum()
        {
            var calc = new StringCalc();

            int result = calc.Add("//[*][%]//1*2%3");

            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_LongDelimiters_ReturnsSum()
        {
            var calc = new StringCalc();

            int result = calc.Add("//[***][%%]//1***2%%3");

            Assert.Equal(6, result);
        }
    }
}
