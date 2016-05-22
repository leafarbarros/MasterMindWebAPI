using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Handlers.Exceptions
{
    public class ThisGuessHasDifferentQtOfColors : Exception
    {
        public ThisGuessHasDifferentQtOfColors()
            : base("This guess has different quantity of colors")
        {
        }
    }
}
