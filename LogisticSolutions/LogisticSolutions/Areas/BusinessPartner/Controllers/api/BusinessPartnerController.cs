using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LogisticSolutions.Areas.BusinessPartner.Controllers
{
    public class BusinessPartnerController : ApiController
    {
        // GET: api/BusinessPartner
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BusinessPartner/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BusinessPartner
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/BusinessPartner/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BusinessPartner/5
        public void Delete(int id)
        {
        }
    }
}
