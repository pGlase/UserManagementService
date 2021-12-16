using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Users;

namespace UserManagementService.Sessions
{
    public class SessionManagement : ISessionManagement
    {
        private List<Session> ActiveSessions;

        public SessionManagement(IEntitySource SystemUsers) : base(SystemUsers)
        {
            ActiveSessions = new();
        }

        public override int GetActiveSessionCount() 
        {
            return ActiveSessions.Count;
        }

        public override SessionToken CreateSession(Entity SessionOwner)
        {
            bool UserHasSession = ActiveSessions.Any(
                s => s.InternalToken.SessionOwner.Equals(SessionOwner.Identity)
                );
            if (UserHasSession)
            {
                throw new UserSessionAlreadyExistsException();
            }

            bool UserExistsInSystem = ActiveUsers.DoesUserExist(SessionOwner);
            if (!UserExistsInSystem)
            {
                throw new ArgumentOutOfRangeException(nameof(SessionOwner), "Given user does not exist in the system!");
            }

            //ToDo: Refactor into SessionFactory and inject it into Management
            var newToken = new SessionToken(SessionOwner.Identity, GenerateNewSessionId());
            var newSession = new Session(newToken);
            ActiveSessions.Add(newSession);
            return newToken;
        }

        public override bool IsValidToken(SessionToken Token)
        {
            if (Token is null) { throw new ArgumentNullException(nameof(Token), "Null Tokens may not be checked"); }
            return ActiveSessions.Any(x => x.InternalToken.Equals(Token));
        }

        private static string GenerateNewSessionId()
        {
            return Guid.NewGuid().ToString().Split('-').First();
        }

    }
}
