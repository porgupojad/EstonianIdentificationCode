using Xunit;

namespace IdentificationCode.Tests.IdentificationCode585
{
    public class IdentificationCode585
    {
        [Fact]
        public void IsValid_OK()
        {
            Assert.True(global::IdentificationCode585.IdentificationCode585.IsValid(TestingHelper585.IdentificationCode1));
            Assert.True(global::IdentificationCode585.IdentificationCode585.IsValid(TestingHelper585.IdentificationCode2));
            Assert.True(global::IdentificationCode585.IdentificationCode585.IsValid(TestingHelper585.IdentificationCode3));

            Assert.True(global::IdentificationCode585.IdentificationCode585.IsValid(TestingHelper585.ProblematicCode1));
            Assert.True(global::IdentificationCode585.IdentificationCode585.IsValid(TestingHelper585.ProblematicCode2));
        }

    }
}