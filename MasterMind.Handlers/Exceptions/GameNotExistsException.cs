using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Handlers.Exceptions
{
    public class GameNotExistsException : Exception
    {
        public GameNotExistsException()
            : base("This game not exists in the server.")
        {
        }
    }
}
