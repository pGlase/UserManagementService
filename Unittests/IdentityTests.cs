using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Users;
using Xunit;

namespace Unittests
{
    public class IdentityTests
    {
        const string TestFirstName = "Pascal";
        const string TestLastName = "Glase";
        const int TestAge = 5;

        [Fact]
        public void ConstructValidIdentity()
        {
            var TestIdentity = new Identity(TestFirstName, TestLastName, TestAge);

            Assert.Equal(TestFirstName, TestIdentity.FirstName);
            Assert.Equal(TestLastName, TestIdentity.LastName);
            Assert.Equal(TestAge, TestIdentity.Age);
        }

        [Fact]
        public void Compare_EqualIdentities()
        {
            var TestIdentity = new Identity(TestFirstName, TestLastName, TestAge);
            var TestIdentity2 = new Identity(TestFirstName, TestLastName, TestAge);

            Assert.Equal(TestIdentity, TestIdentity2);
        }

        [Fact]
        public void Compare_InEqualIdentities()
        {
            var TestIdentity = new Identity(TestFirstName, TestLastName, TestAge);
            var TestIdentityOtherAge = new Identity(TestFirstName, TestLastName, 3);
            var TestIdentityOtherLastName = new Identity(TestFirstName, "Test", TestAge);
            var TestIdentityOtherFirstName = new Identity("Test", TestLastName, TestAge);

            Assert.NotEqual(TestIdentity, TestIdentityOtherAge);
            Assert.NotEqual(TestIdentity, TestIdentityOtherLastName);
            Assert.NotEqual(TestIdentity, TestIdentityOtherFirstName);
        }

        [Fact]
        public void Compare_Equal_Hashcodes()
        {
            var TestIdentity = new Identity(TestFirstName, TestLastName, TestAge);
            var TestIdentity2 = new Identity(TestFirstName, TestLastName, TestAge);

            Assert.Equal(TestIdentity.GetHashCode(), TestIdentity2.GetHashCode());
        }
    }
}
