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
            this.ActiveUsers = SystemUsers;
        }

        public int GetActiveSessionCount()
        {
            return 0;
        }

        public SessionToken CreateSession(Entity SessionOwner)
        {
            var newSession = new Session(SessionOwner.Identity, 
                new SessionToken(SessionOwner.Identity, GenerateNewSessionId()));
            ActiveSessions.Add(newSession);
            return new SessionToken(SessionOwner.Identity, "");
        }
    private static string GenerateNewSessionId()
        {
            return "lol";
        }
    
    }
}
