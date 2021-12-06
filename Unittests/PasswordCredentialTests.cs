using System;
using Xunit;
using UserManagementService.Credentials;

namespace Unittests
{
    public class PasswordCredentialTests
    {
        [Fact]
        public void ConstructFromNullParams_Failure()
        {
            Assert.Throws<ArgumentNullException>(() => new Password(null));
        }

        [Theory]
        [InlineData ("blubb")]
        public void ConstructFromValidString(string testInput)
        {
            new Password(testInput);
        }

        [Theory]
        [InlineData("blubb", "blubb", true)]
        [InlineData("blubb", "Blubb", false)]
        [InlineData("blubb", "", false)]
        [InlineData("blubb", "blu", false)]
        public void ConstructAndValidatePassword(string testPassword, string toCompare, bool expectedResult)
        {
            Password toTest = new Password(testPassword);
            Assert.Equal(toTest.Validate(toCompare), expectedResult);
        }

    }
}
