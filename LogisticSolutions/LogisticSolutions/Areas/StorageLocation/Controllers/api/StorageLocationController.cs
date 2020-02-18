using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LogisticSolutions.Areas.StorageLocation.Controllers.api
{
    public class StorageLocationController : ApiController
    {
        // GET: api/StorageLocation
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/StorageLocation/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/StorageLocation
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/StorageLocation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/StorageLocation/5
        public void Delete(int id)
        {
        }
    }
}
