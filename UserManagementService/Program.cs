using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UserManagementService.Credentials;
using UserManagementService.Sessions;
using UserManagementService.Users;


namespace UserManagementService
{
    class Program
    {
        /* This is not "proper" DI, but has to suffice without reliance on external inputs or frameworks
         * Usually, one would setup containers or parse config files, which in turn would determine the
         * specific type and contents of the interface-class
         * The 'new' keyword and usage of 
         */
        [ExcludeFromCodeCoverage]
        public static IEntitySource InitUserSource()
        {
            List<Entity> SystemUsers = new()
            {
                new Entity(new Identity("Sarina", "Ahmad", 1), new Password("test")),
                new Entity(new Identity("Gina", "Zavala", 2), new Password("test")),
                new Entity(new Identity("Zac", "Elliott", 3), new Password("test")),
                new Entity(new Identity("Giselle", "Roche", 4), new Password("test")),
                new Entity(new Identity("Jimmie", "Mccarty", 5), new Password("test")),
            };
            return new StaticEntitySource(SystemUsers);
        }
        [ExcludeFromCodeCoverage]
        public static ISessionManagement InitSessionManagement(IEntitySource Users)
        {
            return new SessionManagement(Users);
        }

        [ExcludeFromCodeCoverage]
        static void Main()
        {
            //Root of Configuration
            IEntitySource SystemUserSource = InitUserSource();
            ISessionManagement SystemSessionMgmt = InitSessionManagement(SystemUserSource);

            var NewUser = new Entity(new Identity("Pascal", "Glase", 12), new Password("hunter2"));

            SystemUserSource.AddUser(NewUser);
            var SessionToken = SystemSessionMgmt.CreateSession(NewUser);
            Console.WriteLine("User {0} has established connection with GUID {1}",
                SessionToken.SessionOwner.LastName, SessionToken.InternalId
                );
        }
    }
}