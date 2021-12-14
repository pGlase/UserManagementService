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
