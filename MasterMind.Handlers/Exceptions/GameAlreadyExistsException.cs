﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Handlers.Exceptions
{
    public class GameAlreadyExistsException : Exception
    {

        public GameAlreadyExistsException()
            : base("This game already exists")
        {
        }

    }
}
