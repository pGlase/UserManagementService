using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementService.Sessions
{
    [Serializable]
public class UserSessionAlreadyExistsException : Exception
{
    public UserSessionAlreadyExistsException() { }
    public UserSessionAlreadyExistsException(string message) : base(message) { }
    public UserSessionAlreadyExistsException(string message, Exception inner) : base(message, inner) { }
    protected UserSessionAlreadyExistsException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
}
 