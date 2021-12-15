using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Credentials;
using UserManagementService.Users;

namespace Unittests
{
    public class UsertestTools
    {
        public static Identity CreateTestIdentity()
        {
            return new Identity("Pascal", "Glase", 5);
        }

        public static Entity CreateTestEntityWithoutPassword()
        {
            return new Entity(CreateTestIdentity());
        }

        public static Entity CreateTestEntityWithPassword()
        {
            return new Entity(CreateTestIdentity(), new Password("test"));
        }

        public static List<Identity> CreateFiveUniqueIdenities()
        {
            return new List <Identity>
            {
                new Identity("Sarina", "Ahmad", 1),
                new Identity("Gina", "Zavala", 2),
                new Identity("Zac", "Elliott", 3),
                new Identity("Giselle", "Roche", 4),
                new Identity("Jimmie", "Mccarty", 5)
            };
        }

        public static Entity[] CreateFiveUniqueEntitesWithoutPassword()
        {
            var result = new List<Entity>();
            foreach (var identity in CreateFiveUniqueIdenities())
            {
                result.Add(new Entity(identity));
            }
            return result.ToArray();
        }

    }
}
