using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementService.Credental
{
    class Password : ICredental
    {
        SecureString HashedPassword;
    }
}
