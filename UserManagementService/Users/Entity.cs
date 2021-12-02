using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Credental;

namespace UserManagementService.Users
{
    public class Entity
    {
        public Entity(Identity identity)
        {
            Identity = identity;
        }

        public Entity(Identity identity, List<ICredental> credentals)
        {
            Identity = identity;
            Credentals = credentals;
        }
        public List<ICredental> Credentals { get; set; }

        public Identity Identity { get; set; }
    }
}
