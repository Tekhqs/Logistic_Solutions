using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
        public IHttpActionResult Put(int BillingAddressID, tblPartnerBillingAddress partnerbillingAddress)
        {
            

            try
            {
                var Billadress = db.tblPartnerBillingAddresses.FirstOrDefault(c => c.BillingAddressID == BillingAddressID);
                Billadress.Address1 = partnerbillingAddress.Address1;
                Billadress.Address2 = partnerbillingAddress.Address2;
                Billadress.CityName = partnerbillingAddress.CityName;
                Billadress.State_Province = partnerbillingAddress.State_Province;
                Billadress.CountryID = partnerbillingAddress.CountryID;
                Billadress.Zip_PostalCode = partnerbillingAddress.Zip_PostalCode;
                Billadress.UpdatedBy = 1;
                Billadress.UpdatedOn = DateTime.Now;
                db.Entry(Billadress).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnerBillAdressExists(BillingAddressID))
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

        // DELETE: api/BusinessPartnerBillAdress/5
        public void Delete(int id)
        {
        }
        private bool PartnerBillAdressExists(int id)
        {
            return db.tblPartnerBillingAddresses.Count(e => e.PartnerID == id) > 0;
        }
    }
}
