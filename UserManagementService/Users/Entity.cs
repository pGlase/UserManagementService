using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementService.Users
{
    public class Entity
    {
        public Entity(Identity identity)
        {
            Identity = identity;
        }

        //public Entity(Identity identity, List<Credental.Credental> credentals)
        //{
        //    Identity = identity;
        //    Credentals = credentals;
        //}
        //public List<Credental.Credental> Credentals { get; set; }

        public Identity Identity { get; set; }
    }
}
