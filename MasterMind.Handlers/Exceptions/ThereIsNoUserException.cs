using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Handlers.Exceptions
{
    public class ThereIsNoUserException : Exception
    {
        public ThereIsNoUserException()
            : base("There is no user in the server.")
        {
        }
    }
}
