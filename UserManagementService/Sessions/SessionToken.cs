using System;
using UserManagementService.Users;

namespace UserManagementService.Sessions
{
    ///<summary>
    ///stores information about a session. 
    ///Is stored by the user and is needed to access further functions of the API
    ///</summary>

    public class SessionToken
    {
        public SessionToken(Identity _SessionOwner, string _InternalId)
        {
            SessionOwner = _SessionOwner;
            InternalId = _InternalId;
        }
        public readonly Identity SessionOwner;
        public readonly string InternalId;
    }
}