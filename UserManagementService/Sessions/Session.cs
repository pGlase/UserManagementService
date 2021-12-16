using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Users;

namespace UserManagementService.Sessions
{
    public class Session
    {
        public readonly SessionToken InternalToken;
        public Session(SessionToken SessionToken)
        {
            if(SessionToken is null)
            {
                throw new ArgumentNullException(nameof(SessionToken), "SessionToken must not be null!");
            }

            this.InternalToken = SessionToken;
        }
    }
}
