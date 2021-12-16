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
        public void CreateSourceWithNullReference()
        {
            Assert.Throws<ArgumentNullException>(() => new SessionManagement(null));
        }

        [Fact]
        public void ConstructEmptySessionManagement_HasNoActiveSessions_Success()
        {
            var MockUserSource = new Mock<IEntitySource>();
            var SManagement = new SessionManagement(MockUserSource.Object);
            Assert.Equal(0, SManagement.GetActiveSessionCount());
        }

        [Fact]
        public void SessionManagement_CreateSession_ChecksUserExistance()
        {
            var TestUser = UsertestTools.CreateTestEntityWithoutPassword();
            var MockUserSource = new Mock<IEntitySource>();
            MockUserSource.Setup(x => x.DoesUserExist(TestUser)).Returns(true).Verifiable();
            var SManagement = new SessionManagement(MockUserSource.Object);

            var _ = SManagement.CreateSession(TestUser);

            MockUserSource.Verify(x => x.DoesUserExist(TestUser), Times.Once());
        }


        [Fact]
        public void SessionManagement_CreateSession_NonExistentUser_Failure()
        {
            var TestUser = UsertestTools.CreateTestEntityWithoutPassword();
            var MockUserSource = new Mock<IEntitySource>();
            MockUserSource.Setup(x => x.DoesUserExist(It.IsAny<Entity>())).Returns(false).Verifiable();
            var SManagement = new SessionManagement(MockUserSource.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => SManagement.CreateSession(TestUser));
            MockUserSource.Verify(x => x.DoesUserExist(TestUser), Times.Once());
        }

        [Fact]
        public void SessionManagement_CreateSession_ExistingUser_Success()
        {
            var TestUser = UsertestTools.CreateTestEntityWithoutPassword();
            var MockUserSource = new Mock<IEntitySource>();
            MockUserSource.Setup(x => x.DoesUserExist(TestUser)).Returns(true);
            var SManagement = new SessionManagement(MockUserSource.Object);

            var SessionToken = SManagement.CreateSession(TestUser);

            Assert.Equal(TestUser.Identity, SessionToken.SessionOwner);
            Assert.Equal(1, SManagement.GetActiveSessionCount());
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

        [Fact]
        public void SessionManagement_CreateSessions_MultipleUsers_VerifySessionCount_Success()
        {
            var TestUsers = UsertestTools.CreateFiveUniqueEntitesWithoutPassword();
            var MockUserSource = new Mock<IEntitySource>();
            MockUserSource.Setup(x => x.DoesUserExist(It.IsAny<Entity>())).Returns(true);
            var SManagement = new SessionManagement(MockUserSource.Object);

            foreach (var user in TestUsers)
            {
                var _ = SManagement.CreateSession(user);
            }

            Assert.Equal(TestUsers.Length, SManagement.GetActiveSessionCount());
        }

        [Fact]
        public void SessionManagement_IsValidToken_NullToken_Failure()
        {
            var MockUserSource = new Mock<IEntitySource>();
            var SManagement = new SessionManagement(MockUserSource.Object);
            Assert.Throws<ArgumentNullException>(() => SManagement.IsValidToken(null));
        }

        [Fact]
        public void SessionManagement_IsValidToken_InvalidToken_Failure()
        {
            var MockUserSource = new Mock<IEntitySource>();
            var SManagement = new SessionManagement(MockUserSource.Object);
            var TestToken = new SessionToken(UsertestTools.CreateTestIdentity(), "invalid");

            Assert.False(SManagement.IsValidToken(TestToken));
        }

        [Fact]
        public void SessionManagement_IsValidToken_ValidToken_Success()
        {
            var TestUser = UsertestTools.CreateTestEntityWithoutPassword();
            var MockUserSource = new Mock<IEntitySource>();
            MockUserSource.Setup(x => x.DoesUserExist(TestUser)).Returns(true);
            var SManagement = new SessionManagement(MockUserSource.Object);
            var TestToken = SManagement.CreateSession(TestUser);

            Assert.True(SManagement.IsValidToken(TestToken));
        }

    }
}
