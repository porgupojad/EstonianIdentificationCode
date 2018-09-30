using System;
using Xunit;

namespace IdentificationCode.Tests
{
    public class IdentificationCodeTests
    {
        [Fact]
        public void IsValid_OK()
        {
            Assert.True(IdentificationCode.IsValid(TestingHelper.IdentificationCode1));
            Assert.True(IdentificationCode.IsValid(TestingHelper.IdentificationCode2));
            Assert.True(IdentificationCode.IsValid(TestingHelper.IdentificationCode3));

            Assert.True(IdentificationCode.IsValid(TestingHelper.ProblematicCode1));
            Assert.True(IdentificationCode.IsValid(TestingHelper.ProblematicCode2));

            Assert.True(IdentificationCode.IsValid("11010101010"));
        }

        [Fact]
        public void IsValid_NullOrEmptyOrWhitespacesString_Fail()
        {
            Assert.False(IdentificationCode.IsValid(null));
            Assert.False(IdentificationCode.IsValid(string.Empty));
            Assert.False(IdentificationCode.IsValid("           "));
        }

        [Fact]
        public void IsValid_InvalidLenght_Fail()
        {
            Assert.False(IdentificationCode.IsValid(Guid.NewGuid().ToString()));
            Assert.False(IdentificationCode.IsValid(new string('1', 10)));
            Assert.False(IdentificationCode.IsValid(new string('1', 12)));
        }

        [Fact]
        public void IsValid_DigitsOnly_Fail()
        {
            Assert.False(IdentificationCode.IsValid(new string('1', 10) + 'a'));
        }

        [Fact]
        public void IsValid_InvalidDate_Fail()
        {
            Assert.False(IdentificationCode.IsValid("12312328901"));
            Assert.False(IdentificationCode.IsValid("12313678901"));

            Assert.False(IdentificationCode.IsValid("12300328901"));
            Assert.False(IdentificationCode.IsValid("12313008901"));
        }

        [Fact]
        public void GetBirthDate_OK()
        {
            Assert.Equal(new DateTime(1955, 12, 27), IdentificationCode.GetBirthDate(TestingHelper.IdentificationCode1));
            Assert.Equal(new DateTime(1970, 6, 7), IdentificationCode.GetBirthDate(TestingHelper.IdentificationCode2));
            Assert.Equal(new DateTime(1951, 5, 25), IdentificationCode.GetBirthDate(TestingHelper.IdentificationCode3));

            Assert.Equal(new DateTime(2011, 7, 12), IdentificationCode.GetBirthDate(TestingHelper.ProblematicCode1));
            Assert.Equal(new DateTime(2011, 7, 12), IdentificationCode.GetBirthDate(TestingHelper.ProblematicCode2));
        }

        [Fact]
        public void GetBirthDate_Fail()
        {
            Assert.Null(IdentificationCode.GetBirthDate("12345678901"));
        }

        [Fact]
        public void GetSex_OK()
        {
            Assert.Equal(1, IdentificationCode.GetSex(TestingHelper.IdentificationCode1));
            Assert.Equal(2, IdentificationCode.GetSex(TestingHelper.IdentificationCode2));
            Assert.Equal(1, IdentificationCode.GetSex(TestingHelper.IdentificationCode3));

            Assert.Equal(1, IdentificationCode.GetSex(TestingHelper.ProblematicCode1));
            Assert.Equal(2, IdentificationCode.GetSex(TestingHelper.ProblematicCode2));
        }

        [Fact]
        public void GetSex_Fail()
        {
            Assert.Equal(0, IdentificationCode.GetSex("12345678901"));
        }
    }
}