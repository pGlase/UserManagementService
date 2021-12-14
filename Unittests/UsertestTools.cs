using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Users;

namespace Unittests
{
    public class UsertestTools
    {
        public static Identity CreateTestIdentity()
        {
            return new Identity("Pascal", "Glase", 5);
        }
    }
}
