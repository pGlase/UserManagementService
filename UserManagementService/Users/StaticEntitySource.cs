using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementService.Users
{
    public class StaticEntitySource : IEntitySource
    {
        private List<Entity> Users;
        public StaticEntitySource()
        {
            Users = new List<Entity>();
        }
        public StaticEntitySource(List<Entity> toInject)
        {
            Users = toInject;
        }
        public bool AddUser(Entity user)
        {
            if (user != null && !DoesUserExist(user) )
            {
                Users.Add(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DoesUserExist(Entity user)
        {
            var res = Users.SingleOrDefault(res => res.Identity.Equals(user.Identity));
            if(res is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool RemoveUser(Entity user)
        {
            if (DoesUserExist(user))
            {
                Users.Remove(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int StoredUserCount()
        {
            return Users.Count();
        }
    }
}
