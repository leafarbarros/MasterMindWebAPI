using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Handlers.Exceptions
{
    public class PlayerAlreadyInAGameException : Exception
    {
        public PlayerAlreadyInAGameException()
            : base("This player is already in a game")
        {
        }
    }
}
