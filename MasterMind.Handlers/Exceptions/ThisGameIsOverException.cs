using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Handlers.Exceptions
{
    public class ThisGameIsOverException : Exception
    {
        public ThisGameIsOverException()
            : base("This game is over.")
        {
        }
    }
}
