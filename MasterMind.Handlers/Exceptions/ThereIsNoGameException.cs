using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Handlers.Exceptions
{
    public class ThereIsNoGameException : Exception
    {
        public ThereIsNoGameException()
            : base("There is no game in the server.")
        {
        }
    }
}
