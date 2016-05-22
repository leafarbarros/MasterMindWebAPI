using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Handlers.Exceptions
{
    public class ThisGameIsNotInProgressException : Exception
    {
        public ThisGameIsNotInProgressException()
            : base("This game is not in progress")
        {
        }
    }
}
