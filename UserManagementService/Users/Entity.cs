using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Credentials;

namespace UserManagementService.Users
{
    public class Entity
    {
        public Entity(Identity identity)
        {
            Identity = identity;
        }

        public Entity(Identity identity, Password password)
        {
            Identity = identity;
            Password = password;
        }

        public Identity Identity { get; private set; }
        public Password Password { get; private set; }

        public void UpdatePassword(Password NewPassword) => Password = NewPassword;
    }
}
