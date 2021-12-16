using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Sessions;
using Xunit;

namespace Unittests
{
    public class SessionTokenTests
    {

        [Fact]
        public void ConstructSessiontoken_Success()
        {
            var TestIdentity = UsertestTools.CreateTestIdentity();
            var SessionToken = new SessionToken(TestIdentity, "TestId");
            Assert.Equal(TestIdentity, SessionToken.SessionOwner);
        }

        [Fact]
        public void ConstructSessiontoken_WithNullIdentity_Fail()
        {
            Assert.Throws<ArgumentNullException>(() => new SessionToken(null, "TestId"));
        }

        [Fact]
        public void ConstructSessiontoken_WithEmptyId_Fail()
        {
            var TestIdentity = UsertestTools.CreateTestIdentity();
            Assert.Throws<ArgumentNullException>(() => new SessionToken(TestIdentity, ""));
        }
    }
}
