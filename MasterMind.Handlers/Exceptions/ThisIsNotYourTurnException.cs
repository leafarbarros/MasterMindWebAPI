using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Handlers.Exceptions
{
    public class ThisIsNotYourTurnException : Exception
    {
        public ThisIsNotYourTurnException()
            : base("This is not your turn, please wait.")
        {
        }
    }
}
