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
            StoredPassword = password;
        }

        string StoredPassword;
        
        public bool Validate(string toValidate)
        {
            return true;
        }
    }
}
