using System;
using Xunit;

namespace IdentificationCode.Tests
{
    public class ValidatorsTests
    {
        [Fact]
        public void IsDigitsOnly_OK()
        {
            Assert.True(Validators.IsDigitsOnly(TestingHelper.IdentificationCode1));
            Assert.True(Validators.IsDigitsOnly(TestingHelper.IdentificationCode2));
            Assert.True(Validators.IsDigitsOnly(TestingHelper.IdentificationCode3));

            Assert.True(Validators.IsDigitsOnly(TestingHelper.ProblematicCode1));
            Assert.True(Validators.IsDigitsOnly(TestingHelper.ProblematicCode2));
        }

        [Fact]
        public void IsDigitsOnly_Fail()
        {
            Assert.False(Validators.IsDigitsOnly("1234567890a"));
            Assert.False(Validators.IsDigitsOnly(Guid.NewGuid().ToString()));
        }

        [Fact]
        public void GetCenturyByByte_OK()
        {
            Assert.Equal(1800, Validators.GetCentury(1));
            Assert.Equal(1800, Validators.GetCentury(2));

            Assert.Equal(1900, Validators.GetCentury(3));
            Assert.Equal(1900, Validators.GetCentury(4));

            Assert.Equal(2000, Validators.GetCentury(5));
            Assert.Equal(2000, Validators.GetCentury(6));

            Assert.Equal(2100, Validators.GetCentury(7));
            Assert.Equal(2100, Validators.GetCentury(8));
        }

        [Fact]
        public void GetCenturyByByte_Fail()
        {
            Assert.Throws<InvalidOperationException>(() => Validators.GetCentury(0));
            Assert.Throws<InvalidOperationException>(() => Validators.GetCentury(9));
        }

        [Fact]
        public void GetCenturyByChar_OK()
        {
            Assert.Equal(1800, Validators.GetCentury('1'));
            Assert.Equal(1800, Validators.GetCentury('2'));

            Assert.Equal(1900, Validators.GetCentury('3'));
            Assert.Equal(1900, Validators.GetCentury('4'));

            Assert.Equal(2000, Validators.GetCentury('5'));
            Assert.Equal(2000, Validators.GetCentury('6'));

            Assert.Equal(2100, Validators.GetCentury('7'));
            Assert.Equal(2100, Validators.GetCentury('8'));
        }

        [Fact]
        public void GetCenturyByChar_Fail()
        {
            Assert.Throws<InvalidOperationException>(() => Validators.GetCentury('0'));
            Assert.Throws<InvalidOperationException>(() => Validators.GetCentury('9'));
            Assert.Throws<InvalidOperationException>(() => Validators.GetCentury('a'));
            Assert.Throws<InvalidOperationException>(() => Validators.GetCentury('X'));
        }

        [Fact]
        public void CalculateControllNumber_OK()
        {
            Assert.Equal(char.GetNumericValue(TestingHelper.IdentificationCode1[10]), Validators.CalculateControllNumber(TestingHelper.IdentificationCode1));
            Assert.Equal(char.GetNumericValue(TestingHelper.IdentificationCode2[10]), Validators.CalculateControllNumber(TestingHelper.IdentificationCode2));
            Assert.Equal(char.GetNumericValue(TestingHelper.IdentificationCode3[10]), Validators.CalculateControllNumber(TestingHelper.IdentificationCode3));

            Assert.Equal(char.GetNumericValue(TestingHelper.ProblematicCode1[10]), Validators.CalculateControllNumber(TestingHelper.ProblematicCode1));
            Assert.Equal(char.GetNumericValue(TestingHelper.ProblematicCode2[10]), Validators.CalculateControllNumber(TestingHelper.ProblematicCode2));
        }

        [Fact]
        public void CalculateControllNumber_InvalidControllNumber_Fail()
        {
            Assert.NotEqual(1, Validators.CalculateControllNumber(TestingHelper.IdentificationCode1));
            //Assert.NotEqual(2, Validators.CalculateControllNumber(TestingHelper.IdentificationCode1));
            Assert.NotEqual(3, Validators.CalculateControllNumber(TestingHelper.IdentificationCode1));
            Assert.NotEqual(4, Validators.CalculateControllNumber(TestingHelper.IdentificationCode1));
            Assert.NotEqual(5, Validators.CalculateControllNumber(TestingHelper.IdentificationCode1));
            Assert.NotEqual(6, Validators.CalculateControllNumber(TestingHelper.IdentificationCode1));
            Assert.NotEqual(7, Validators.CalculateControllNumber(TestingHelper.IdentificationCode1));
            Assert.NotEqual(8, Validators.CalculateControllNumber(TestingHelper.IdentificationCode1));
            Assert.NotEqual(9, Validators.CalculateControllNumber(TestingHelper.IdentificationCode1));
            Assert.NotEqual(0, Validators.CalculateControllNumber(TestingHelper.IdentificationCode1));
        }

        [Fact]
        public void CalculcateControllNumber_StringEmptyOrNullOrWhitespaces_Fail()
        {
            Assert.Throws<InvalidOperationException>(() => Validators.CalculateControllNumber(null));
            Assert.Throws<InvalidOperationException>(() => Validators.CalculateControllNumber(string.Empty));
            Assert.Throws<InvalidOperationException>(() => Validators.CalculateControllNumber("           "));
        }

        [Fact]
        public void CalculcateControllNumber_InvalidLenght_Fail()
        {
            Assert.Throws<InvalidOperationException>(() => Validators.CalculateControllNumber(new string('1', 9)));
            Assert.Throws<InvalidOperationException>(() => Validators.CalculateControllNumber(new string('1', 12)));
        }

        [Fact]
        public void CalculateControllNumber_IsDigitsOnly_Fail()
        {
            Assert.Throws<InvalidOperationException>(() => Validators.CalculateControllNumber(new string('1', 9) + 'a'));
        }
    }
}
