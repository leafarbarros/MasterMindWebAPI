using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterMind.WebAPI.Models
{
    public class UserGuessModel
    {

        public string GameName { get; set; }

        public string UserName { get; set; }
        
        public string[] GameColorsCodes { get; set; }

    }
}