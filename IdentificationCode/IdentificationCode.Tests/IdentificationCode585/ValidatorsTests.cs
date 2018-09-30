using Xunit;

namespace IdentificationCode585.Tests
{
    public class ValidatorsTests
    {
        [Fact]
        public void IsDigitsOnly_OK()
        {
            var controllNumber = Validators.CalculateControllNumber("51107121760");
            var controllNumber2 = Validators.CalculateControllNumber("61107121760");
        }
    }
}
