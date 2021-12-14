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
            var TestIdentity = UsertestTools.CreateTestIdentity();
            var TestToken = new SessionToken(TestIdentity, "TestId");
            var _ = new Session(TestToken);
            Assert.Equal(TestIdentity, _.InternalToken.SessionOwner);
        }

        [Fact]
        public void ConstructSession_NullSessiontoken_Fail()
        {
            Assert.Throws<ArgumentNullException>(() => new Session(null));
        }

        [Fact]
        public void ConstructSession_Sessiontoken_WithNullIdentity_Fail()
        {
            var TestToken = new SessionToken(null, "TestId");
            Assert.Throws<ArgumentNullException>(() => new Session(TestToken));
        }

        [Fact]
        public void ConstructSession_Sessiontoken_WithEmptyId_Fail()
        {
            var TestIdentity = UsertestTools.CreateTestIdentity();
            var TestToken = new SessionToken(TestIdentity, "");
            Assert.Throws<ArgumentNullException>(() => new Session(TestToken));
        }
    }
}
