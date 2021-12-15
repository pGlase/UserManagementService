using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Credentials;
using UserManagementService.Users;
using Xunit;

namespace Unittests
{
    public class EntityTests
    {
        [Fact]
        public void ConstructValidUserEntity_WithoutPassword()
        {
            var TestIdentity = UsertestTools.CreateTestIdentity();

            var TestEntity = new Entity(TestIdentity);

            Assert.Equal(TestIdentity, TestEntity.Identity);
        }

        [Fact]
        public void ConstructValidUserEntity_WithPassword()
        {
            var TestPassword = new Password("test");
            var TestIdentity = UsertestTools.CreateTestIdentity();

            var TestEntity = new Entity(TestIdentity, TestPassword);

            Assert.Equal(TestIdentity, TestEntity.Identity);
            Assert.Equal(TestPassword, TestEntity.Password);
        }

        [Fact]
        public void CreateVaildEnitity_SetNewPassword()
        {
            var FirstPassword = new Password("test");
            var SecondPassword = new Password("newPassword");
            var TestIdentity = UsertestTools.CreateTestIdentity();
            var TestEntity = new Entity(TestIdentity, FirstPassword);

            TestEntity.UpdatePassword(SecondPassword);

            Assert.Equal(SecondPassword, TestEntity.Password);
        }

    }
}
