using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Handlers.Exceptions
{
    public class GameIsFullException : Exception
    {
        public GameIsFullException()
            : base("This game is full.")
        {
        }
    }
}
