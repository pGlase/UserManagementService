using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementService.Credentials
{
    public class Password
    {
        public Password(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(password, "Passwords may not be null or empty");
            }
            StoredPassword = password;
            SetDate = DateTime.Now;
        }
        public Password(string password, DateTime setDate) : this(password)
        {
            SetDate = setDate;
        }

        string StoredPassword;
        DateTime SetDate;
        public bool Validate(string toValidate)
        {
            return StoredPassword.Equals(toValidate);
        }
    }
}
