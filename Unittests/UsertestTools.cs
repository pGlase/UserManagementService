using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Credentials;
using UserManagementService.Users;

namespace Unittests
{
    public class UsertestTools
    {
        public static Identity CreateTestIdentity()
        {
            return new Identity("Pascal", "Glase", 5);
        }

        public static Entity CreateTestEntityWithoutPassword()
        {
            return new Entity(CreateTestIdentity());
        }

        public static Entity CreateTestEntityWithPassword()
        {
            return new Entity(CreateTestIdentity(), new Password("test"));
        }

    }
}
