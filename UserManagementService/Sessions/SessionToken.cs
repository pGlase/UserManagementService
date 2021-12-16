using System;
using System.Diagnostics.CodeAnalysis;
using UserManagementService.Users;

namespace UserManagementService.Sessions
{
    ///<summary>
    ///stores information about a session. 
    ///Is stored by the user and is needed to access further functions of the API
    ///</summary>

    public class SessionToken : IEquatable<SessionToken>
    {
        public Identity SessionOwner { get; }
        public string InternalId { get; }

        public SessionToken(Identity _SessionOwner, string _InternalId)
        {

            if (_SessionOwner is null)
            {
                throw new ArgumentNullException(nameof(_SessionOwner), "SessionToken must have an valid owner!");
            }

            if (string.IsNullOrEmpty(_InternalId))
            {
                throw new ArgumentNullException(nameof(_InternalId), "SessionToken must have a valid id!");
            }

            SessionOwner = _SessionOwner;
            InternalId = _InternalId;
        }

        public bool Equals(SessionToken other)
        {
            //comparing the id's should be enough - SessionManagement will enforce 1 session per user
            return InternalId == other.InternalId;
        }

        [ExcludeFromCodeCoverage]
        public override bool Equals(object obj)
        {
            return Equals(obj as SessionToken);
        }

        [ExcludeFromCodeCoverage]
        public override int GetHashCode() => (InternalId, SessionOwner).GetHashCode();
    }
}