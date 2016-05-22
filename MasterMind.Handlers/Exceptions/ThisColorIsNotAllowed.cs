using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Handlers.Exceptions
{
    public class ThisColorIsNotAllowed : Exception
    {
        public ThisColorIsNotAllowed()
            : base("This color is not allowed")
        {
        }
    }
}
