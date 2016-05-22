using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MasterMind.WebApi.Controllers
{
    public class MasterMindGameController : ApiController
    {
        // GET: api/MasterMindGame
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MasterMindGame/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MasterMindGame
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MasterMindGame/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MasterMindGame/5
        public void Delete(int id)
        {
        }
    }
}
