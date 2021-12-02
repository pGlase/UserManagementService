using System;
using System.Collections.Generic;
using UserManagementService.Users;
using Xunit;

namespace Unittests
{
    public class StaticEnitySourceTests
    {
        [Fact]
        public void UserCountZeroByRefConstructor()
        {
            StaticEntitySource EntitySource = new(new());
            Assert.True(EntitySource.StoredUserCount() == 0);
        }

        public class EmptyStaticEnitySource
        {
            StaticEntitySource EmptySource = new();
            readonly Entity testUser = new(new Identity("Pascal", "Glase", 5));

            [Fact]
            public void UserCountZeroByDefaultConstructor()
            {
                Assert.True(EmptySource.StoredUserCount() == 0);
            }

            [Fact]
            public void AddSingleNewUser_Success()
            {
                Assert.True(EmptySource.AddUser(testUser));
                Assert.True(EmptySource.StoredUserCount() == 1);
            }

            [Fact]
            public void AddSameUserTwice_Failed()
            {
                Assert.True(EmptySource.AddUser(testUser));
                Assert.False(EmptySource.AddUser(testUser));
            }

            [Fact]
            public void AddSingleNullUser_Failure()
            {
                Assert.False(EmptySource.AddUser(null));
                Assert.True(EmptySource.StoredUserCount() == 0);
            }

            [Fact]
            public void DeleteMissingUser_Failure()
            {
                Assert.False(EmptySource.RemoveUser(testUser));
            }

            [Fact]
            public void AddAndDeleteUser_Failure()
            {
                Assert.True(EmptySource.AddUser(testUser));
                Assert.True(EmptySource.RemoveUser(testUser));
            }

        }
        public class FilledStaticEnitySource
        {
            public static readonly List<Entity> TestUsers = new()
            {
                new(new Identity("Pascal", "Glase", 5)),
                new(new Identity("A", "B", 15)),
                new(new Identity("D", "F", 15))
            };
            StaticEntitySource TestSource = new(TestUsers);

           [Fact]
            public void UserCountMatchingData()
            {
                Assert.True(TestSource.StoredUserCount() == TestUsers.Count);
            }

        }
    }
}
