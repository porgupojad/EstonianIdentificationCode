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
        }

    }
}