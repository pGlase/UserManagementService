using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using UserManagementService.Sessions;
using UserManagementService.Users;

namespace Unittests
{
    public class SessionTests
    {

        [Fact]
        public void ConstructValidSession()
        {
            var TestIdentity = new Identity(null, null, 0);
            var TestToken = new SessionToken(TestIdentity, "TestId");
            var _ = new Session(TestIdentity, TestToken);
            Assert.Equal(TestIdentity, _.SessionOwner);
        }

        [Fact]
        public void ConstructSession_NullIdentity_Fail()
        {
            var TestIdentity = new Identity(null, null, 0);
            var TestToken = new SessionToken(TestIdentity, "TestId");
            Assert.Throws<ArgumentNullException>(() => new Session(null, TestToken));
        }


        [Fact]
        public void ConstructSession_NullSessiontoken_Fail()
        {
            var TestIdentity = new Identity(null, null, 0);
            Assert.Throws<ArgumentNullException>(() => new Session(TestIdentity, null));
        }
    }
}
