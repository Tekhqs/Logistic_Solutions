using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DAL;
using System.Data.Entity.Validation;
using System.Web;
using System.Data.Entity.Infrastructure;

namespace LogisticSolutions.Areas.BusinessPartner.Controllers
{
    public class BusinessPartnerController : ApiController
    {
        LogisticSolutionDevDBEntities db = new LogisticSolutionDevDBEntities();

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
        [ResponseType(typeof(tblPartner))]
        public IHttpActionResult Post(tblPartner partner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string z = ""; string z1 = "";
            var max = db.tblPartners.OrderByDescending(x => x.PartnerCode).Select(x => x.PartnerCode).FirstOrDefault();
            if (max != null)
            {
                z = max;
                z1 = "PTR_" + (Convert.ToInt32(z.Replace("PTR_", "")) + 1).ToString().PadLeft(5, '0');

            }
            else
            {
                z1 = "PTR_00001";
            }
            partner.PartnerCode = z1;
            partner.BillingRateUnit = 2;
            partner.isDeleted = false;
            partner.isBonded = true;
            partner.isEnabled = true;
            partner.CreatedOn = System.DateTime.Now;
            partner.CreatedBy = 1;// Convert.ToInt32(HttpContext.Current.Session["UserId"]);

            db.tblPartners.Add(partner);

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
            return CreatedAtRoute("DefaultApi", new { id = partner.PartnerID }, partner);
        }

        // PUT: api/BusinessPartner/5
        public IHttpActionResult Put(int PartnerID,int BillingAddressID, int ShippingAddressID, tblPartner partner)
        {
            tblPartner partner2 = db.tblPartners.Find(PartnerID);

            if (PartnerID != partner2.PartnerID)
            {
                return BadRequest();
            }
            partner2.BillingAddressID = BillingAddressID;
            partner2.ShippingAddressID = ShippingAddressID;
            partner2.UpdatedOn = System.DateTime.Now;
            partner2.UpdatedBy = 1;

            db.Entry(partner2).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnerExists(PartnerID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/BusinessPartner/5
        public void Delete(int id)
        {
        }

        private bool PartnerExists(int id)
        {
            return db.tblPartners.Count(e => e.PartnerID == id) > 0;
        }
    }
}
