
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Users;

namespace UserManagementService.Sessions
{
    public abstract class ISessionManagement
    {
        protected readonly IEntitySource ActiveUsers;

        protected ISessionManagement(IEntitySource SystemUsers)
        {
            if(SystemUsers is null) {
                throw new ArgumentNullException(nameof(SystemUsers), "EnitySource may not be null");
            }
            this.ActiveUsers = SystemUsers;
        }

        public abstract SessionToken CreateSession(Entity SessionOwner);
        public abstract bool IsValidToken(SessionToken Token);
        public abstract int GetActiveSessionCount();
    }
}
