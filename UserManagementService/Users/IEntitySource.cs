using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementService.Users
{
    interface IEntitySource
    {
        bool AddUser(Entity user);
        bool RemoveUser(Entity user);
        bool DoesUserExist(Entity user);
        int StoredUserCount();
    }
}
