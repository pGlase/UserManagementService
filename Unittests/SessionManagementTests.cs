using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Users;
using UserManagementService.Sessions;
using Moq;
using Xunit;

namespace Unittests
{
    public class SessionManagementTests
    {


        [Fact]
        public void ConstructSessionManagement()
        {
            var X = new Mock<IEntitySource>();
            _ = new SessionManagement(X.Object);
        }

        [Fact]
        public void ConstructEmptySessionManagement_HasNoActiveSessions_Success()
        {
            var X = new Mock<IEntitySource>();
            var SManagement = new SessionManagement(X.Object);
            Assert.Equal(0, SManagement.GetActiveSessionCount());
        }
        [Fact]
        public void SessionManagement_CreateSession_ExistingUser_Success()
        {
            //arrange
            var TestUser = new Entity(new Identity("Pascal", "Glase", 5));
            var X = new Mock<IEntitySource>();
            X.Setup(x => x.DoesUserExist(TestUser)).Returns(true);
            var SManagement = new SessionManagement(X.Object);

            //act
            var SessionToken = SManagement.CreateSession(TestUser);

            //assert
            Assert.Equal(TestUser.Identity, SessionToken.SessionOwner);
            Assert.Equal(SManagement.GetActiveSessionCount(), (1));
        }


    }
}
