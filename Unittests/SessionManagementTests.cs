using Moq;
using System;
using UserManagementService.Sessions;
using UserManagementService.Users;
using Xunit;

namespace Unittests
{
    public class SessionManagementTests
    {
        public readonly Mock<IEntitySource> MockUserSource;
        public SessionManagement SManagement { get; private set; }
        public Entity TestUser { get; private set; }

        public SessionManagementTests()
        {
            MockUserSource = new Mock<IEntitySource>();
            SManagement = new(MockUserSource.Object);
            TestUser = UsertestTools.CreateTestEntityWithoutPassword();
        }

        [Fact]
        public void ConstructSessionManagement()
        {
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
            Assert.Equal(0, SManagement.GetActiveSessionCount());
        }

        [Fact]
        public void SessionManagement_CreateSession_ChecksUserExistance()
        {
            MockUserSource.Setup(x => x.DoesUserExist(TestUser)).Returns(true).Verifiable();

            var _ = SManagement.CreateSession(TestUser);

            MockUserSource.Verify(x => x.DoesUserExist(TestUser), Times.Once());
        }


        [Fact]
        public void SessionManagement_CreateSession_NonExistentUser_Failure()
        {
            MockUserSource.Setup(x => x.DoesUserExist(It.IsAny<Entity>())).Returns(false).Verifiable();

            Assert.Throws<ArgumentOutOfRangeException>(() => SManagement.CreateSession(TestUser));
            MockUserSource.Verify(x => x.DoesUserExist(TestUser), Times.Once());
        }

        [Fact]
        public void SessionManagement_CreateSession_ExistingUser_Success()
        {
            MockUserSource.Setup(x => x.DoesUserExist(TestUser)).Returns(true);

            var SessionToken = SManagement.CreateSession(TestUser);

            Assert.Equal(TestUser.Identity, SessionToken.SessionOwner);
            Assert.Equal(1, SManagement.GetActiveSessionCount());
        }

        [Fact]
        public void SessionManagement_CreateSession_ExistingUser_Twice_Failure()
        {
            MockUserSource.Setup(x => x.DoesUserExist(TestUser)).Returns(true);

            var SessionToken = SManagement.CreateSession(TestUser);

            Assert.Throws<UserSessionAlreadyExistsException>(() => SManagement.CreateSession(TestUser));
        }

        [Fact]
        public void SessionManagement_CreateSessions_MultipleUsers_VerifySessionCount_Success()
        {
            var TestUsers = UsertestTools.CreateFiveUniqueEntitesWithoutPassword();
            MockUserSource.Setup(x => x.DoesUserExist(It.IsAny<Entity>())).Returns(true);

            foreach (var user in TestUsers)
            {
                var _ = SManagement.CreateSession(user);
            }

            Assert.Equal(TestUsers.Length, SManagement.GetActiveSessionCount());
        }

        [Fact]
        public void SessionManagement_IsValidToken_NullToken_Failure()
        {
            Assert.Throws<ArgumentNullException>(() => SManagement.IsValidToken(null));
        }

        [Fact]
        public void SessionManagement_IsValidToken_InvalidToken_NonExistantSession_Failure()
        {
            var FraudToken = new SessionToken(TestUser.Identity, "invalid");

            Assert.False(SManagement.IsValidToken(FraudToken));
        }

        [Fact]
        public void SessionManagement_IsValidToken_InvalidToken_SameUser_Failure()
        {
            MockUserSource.Setup(x => x.DoesUserExist(TestUser)).Returns(true);

            var ValidToken = SManagement.CreateSession(TestUser);
            var FraudToken = new SessionToken(ValidToken.SessionOwner, "invalid");

            Assert.False(SManagement.IsValidToken(FraudToken));
        }

        [Fact]
        public void SessionManagement_IsValidToken_InvalidToken_SameId_Failure()
        {
            MockUserSource.Setup(x => x.DoesUserExist(TestUser)).Returns(true);

            var ValidToken = SManagement.CreateSession(TestUser);
            var FraudToken = new SessionToken(
                new Identity("another", "user", 5), ValidToken.InternalId
                );

            Assert.False(SManagement.IsValidToken(FraudToken));
        }

        [Fact]
        public void SessionManagement_IsValidToken_ValidToken_Success()
        {
            MockUserSource.Setup(x => x.DoesUserExist(TestUser)).Returns(true);

            var TestToken = SManagement.CreateSession(TestUser);

            Assert.True(SManagement.IsValidToken(TestToken));
        }

    }
}
