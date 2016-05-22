using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Entity
{
    public class User
    {
        public User(string userName)
        {
            this.UserName = userName;
        }

        public string UserName { get; set; }
    }
}
