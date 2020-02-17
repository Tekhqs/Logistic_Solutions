using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace LogisticSolutions.Areas.BusinessPartner.Controllers.api
{
    public class BusinessPartnerShipAdressController : ApiController
    {
        LogisticSolutionDevDBEntities db = new LogisticSolutionDevDBEntities();
        // GET: api/BusinessPartnerShipAdress
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BusinessPartnerShipAdress/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BusinessPartnerShipAdress
        [ResponseType(typeof(tblPartnerShippingAddress))]
        public IHttpActionResult Post(tblPartnerShippingAddress partnerShippingAddress, int PartnerID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            partnerShippingAddress.PartnerID = PartnerID;
            partnerShippingAddress.isDeleted = false;
            partnerShippingAddress.isActive = true;
            partnerShippingAddress.CreatedOn = System.DateTime.Now;
            partnerShippingAddress.CreatedBy = 1;// Convert.ToInt32(HttpContext.Current.Session["UserId"]);
            partnerShippingAddress.UpdatedBy = 1;// Convert.ToInt32(HttpContext.Current.Session["UserId"]);
            db.tblPartnerShippingAddresses.Add(partnerShippingAddress);

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = partnerShippingAddress.ShippingAddressID}, partnerShippingAddress);
        }

        // PUT: api/BusinessPartnerShipAdress/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BusinessPartnerShipAdress/5
        public void Delete(int id)
        {
        }
    }
}
