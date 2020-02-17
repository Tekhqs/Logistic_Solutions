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
    public class BusinessPartnerBillAdressController : ApiController
    {
        LogisticSolutionDevDBEntities db = new LogisticSolutionDevDBEntities();
        // GET: api/BusinessPartnerBillAdress
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BusinessPartnerBillAdress/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BusinessPartnerBillAdress
        [ResponseType(typeof(tblPartnerBillingAddress))]
        public IHttpActionResult Post(tblPartnerBillingAddress partnerbillingAddress, int PartnerID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            partnerbillingAddress.PartnerID = PartnerID;
            partnerbillingAddress.isDeleted = false;
            partnerbillingAddress.isActive = true;
            partnerbillingAddress.CreatedOn = System.DateTime.Now;
            partnerbillingAddress.CreatedBy = 1;// Convert.ToInt32(HttpContext.Current.Session["UserId"]);
            partnerbillingAddress.UpdatedBy = 1;// Convert.ToInt32(HttpContext.Current.Session["UserId"]);
            db.tblPartnerBillingAddresses.Add(partnerbillingAddress);

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

            return CreatedAtRoute("DefaultApi", new { id = partnerbillingAddress.BillingAddressID }, partnerbillingAddress);
        }

        // PUT: api/BusinessPartnerBillAdress/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BusinessPartnerBillAdress/5
        public void Delete(int id)
        {
        }
    }
}
