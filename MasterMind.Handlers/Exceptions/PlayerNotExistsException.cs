using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Handlers.Exceptions
{
    public class PlayerNotExistsException : Exception
    {
        public PlayerNotExistsException()
            : base("This player does not exists in the server.")
        {
        }
    }
}
