using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Users;

namespace UserManagementService.Sessions
{
    public class SessionManagement
    {
        private IEntitySource ActiveUsers;
        private List<Session> ActiveSessions;

        public SessionManagement(IEntitySource SystemUsers)
        {
            ActiveSessions = new();
            this.ActiveUsers = SystemUsers;
        }

        public int GetActiveSessionCount()
        {
            return ActiveSessions.Count;
        }

        public SessionToken CreateSession(Entity SessionOwner)
        {
            bool UserHasSession = ActiveSessions.Any(
                s => s.InternalToken.SessionOwner.Equals(SessionOwner.Identity));
            if (UserHasSession)
            {
                throw new UserSessionAlreadyExistsException();
            }

            bool UserExistsInSystem = ActiveUsers.DoesUserExist(SessionOwner);
            if (!UserExistsInSystem)
            {
                throw new ArgumentOutOfRangeException(nameof(SessionOwner), "Given user does not exist in the system!");
            }

            var newToken = new SessionToken(SessionOwner.Identity, GenerateNewSessionId());
            var newSession = new Session(newToken);
            ActiveSessions.Add(newSession);
            return newToken;
        }
        private static string GenerateNewSessionId()
        {
            return Guid.NewGuid().ToString();
        }

    }
}
