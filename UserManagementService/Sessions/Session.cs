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
        public Identity SessionOwner { get; private set; }
        public readonly SessionToken InternalToken;
        public Session(Identity NewSessionowner, SessionToken SessionToken)
        {
            if (NewSessionowner is null)
            {
                throw new ArgumentNullException(nameof(NewSessionowner), "Session must have an valid owner!");
            }

            if (string.IsNullOrEmpty(SessionToken.InternalId))
            {
                throw new ArgumentNullException(nameof(SessionToken), "SessionToken must have a valid id!");
            }
            this.SessionOwner = NewSessionowner;
            this.InternalToken = SessionToken;
        }
    }
}
