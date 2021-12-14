using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementService.Users
{
    public class Identity : IEquatable<Identity>
    {
        public Identity(string _firstName, string _lastName, int _age)
        {
            FirstName = _firstName;
            LastName = _lastName;
            Age = _age;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public bool Equals(Identity other)
        {
            return FirstName == other.FirstName && LastName == other.LastName && Age == other.Age;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Identity);
        }

        public override int GetHashCode() => (FirstName, LastName, Age).GetHashCode();
    }

}
