using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exception
{
    public class EntityRepeatException : System.Exception
    {
        public EntityRepeatException(string message) : base(message)
        {
        }
    }

    public class EntityIsNullException : System.Exception
    {
        public EntityIsNullException(string message) : base(message)
        {
        }
    }

    public class UserOrPasswordException : System.Exception
    {

    }
    public class FieldIsNullOrEmptyException : System.Exception
    {

    }
}
