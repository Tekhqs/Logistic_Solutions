using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LogisticSolutions.Areas.Order.Controllers
{
    public class ShipOrderController : ApiController
    {
        // GET: api/ShipOrder
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ShipOrder/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ShipOrder
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ShipOrder/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ShipOrder/5
        public void Delete(int id)
        {
        }
    }
}
