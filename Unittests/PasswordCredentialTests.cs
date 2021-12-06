using System;
using Xunit;
using UserManagementService.Credentials;

namespace Unittests
{
    public class PasswordCredentialTests
    {
        [Fact]
        public void ConstructFromNullString_Failure()
        {
            Assert.Throws<ArgumentNullException>(() => new Password(null));
        }

        [Fact]
        public void ConstructFromEmptyString_Failure()
        {
            Assert.Throws<ArgumentNullException>(() => new Password(""));
        }

        [Theory]
        [InlineData ("blubb")]
        [InlineData("123")]
        [InlineData("+-#")]
        public void ConstructFromValidString(string testInput)
        {
            _ = new Password(testInput);
        }

        [Theory]
        [InlineData("1.1.1970")]
        [InlineData("1.2.2003")]
        [InlineData("4.4.2015")]
        public void ConstructFromValidDateString(string dateString)
        {
            _ = new Password("test", DateTime.Parse(dateString));
        }

        [Theory]
        [InlineData("blubb", "blubb", true)]
        [InlineData("blubb", "Blubb", false)]
        [InlineData("blubb", "", false)]
        [InlineData("blubb", "blu", false)]
        public void ValidatePasswordHandling(string testPassword, string toCompare, bool expectedResult)
        {
            Password toTest = new Password(testPassword);
            Assert.Equal(toTest.Validate(toCompare), expectedResult);
        }

    }
}
