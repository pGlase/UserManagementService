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
            var MockUserSource = new Mock<IEntitySource>();
            _ = new SessionManagement(MockUserSource.Object);
        }

        [Fact]
        public void ConstructEmptySessionManagement_HasNoActiveSessions_Success()
        {
            var MockUserSource = new Mock<IEntitySource>();
            var SManagement = new SessionManagement(MockUserSource.Object);
            Assert.Equal(0, SManagement.GetActiveSessionCount());
        }

        [Fact]
        public void SessionManagement_CreateSession_NonExistingUser_Failure()
        {
            var TestUser = UsertestTools.CreateTestEntityWithoutPassword();
            var MockUserSource = new Mock<IEntitySource>();
            MockUserSource.Setup(x => x.DoesUserExist(TestUser)).Returns(false).Verifiable();
            var SManagement = new SessionManagement(MockUserSource.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() =>SManagement.CreateSession(TestUser));

            MockUserSource.Verify(x => x.DoesUserExist(TestUser), Times.Once());
        }

        [Fact]
        public void SessionManagement_CreateSession_ExistingUser_Success()
        {
            var TestUser = UsertestTools.CreateTestEntityWithoutPassword();
            var MockUserSource = new Mock<IEntitySource>();
            MockUserSource.Setup(x => x.DoesUserExist(TestUser)).Returns(true).Verifiable();
            var SManagement = new SessionManagement(MockUserSource.Object);

            var SessionToken = SManagement.CreateSession(TestUser);

            Assert.Equal(TestUser.Identity, SessionToken.SessionOwner);
            Assert.Equal(1, SManagement.GetActiveSessionCount());
            MockUserSource.Verify(x => x.DoesUserExist(TestUser), Times.Once());
        }

        [Fact]
        public void SessionManagement_CreateSession_ExistingUser_Twice_Failure()
        {
            var TestUser = UsertestTools.CreateTestEntityWithoutPassword();
            var MockUserSource = new Mock<IEntitySource>();
            MockUserSource.Setup(x => x.DoesUserExist(TestUser)).Returns(true);
            var SManagement = new SessionManagement(MockUserSource.Object);

            var SessionToken = SManagement.CreateSession(TestUser);
            Assert.Throws<UserSessionAlreadyExistsException>(() => SManagement.CreateSession(TestUser));
        }

    }
}
