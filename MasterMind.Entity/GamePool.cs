using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterMind.Entity
{
    public class GamePool
    {

        public GamePool()
        {
            Games = new List<Game>();
            LoggedUsers = new List<User>();
        }

        public IList<Game> Games { get; set; }

        public IList<User> LoggedUsers { get; set; }

    }
}
