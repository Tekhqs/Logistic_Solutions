using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace LogisticSolutions.Areas.WareHouse.Controllers.api
{
    public class WareHouseController : ApiController
    {
        LogisticSolutionDevDBEntities db = new LogisticSolutionDevDBEntities();

        // GET: api/WareHouse
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/WareHouse/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/WareHouse
        [ResponseType(typeof(tblWarehouseMaster))]

        public IHttpActionResult Post(tblWarehouseMaster wareHouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //var userId = Convert.ToInt32(Session["UserId"]);

            string z = ""; string z1 = "";
            var max = db.tblWarehouseMasters.OrderByDescending(x => x.WareHouseCode).Select(x => x.WareHouseCode).FirstOrDefault();
            if (max != null)
            {
                z = max;
                z1 = "WAR_" + (Convert.ToInt32(z.Replace("WAR_", "")) + 1).ToString().PadLeft(5, '0');

            }
            else
            {
                z1 = "WAR_00001";
            }
            wareHouse.WareHouseCode = z1;
            wareHouse.isDeleted = false;
            wareHouse.CreatedOn = DateTime.Now;
            wareHouse.CreatedBy = 6;
            db.tblWarehouseMasters.Add(wareHouse);
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
            return CreatedAtRoute("DefaultApi", new { id = wareHouse.WarehouseID }, wareHouse);

        }
        [ResponseType(typeof(tblWarehouseMaster))]
        // PUT: api/WareHouse/5
        public IHttpActionResult Put(tblWarehouseMaster wareHouse, int wareHouseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var warehouse = db.tblWarehouseMasters.Where(c => c.WarehouseID == wareHouseId).FirstOrDefault();
            

            try
            {
                warehouse.WareHouseDescription = wareHouse.WareHouseDescription;
                warehouse.Address1 = wareHouse.Address1;
                warehouse.Address2 = wareHouse.Address2;
                warehouse.CityName = wareHouse.CityName;
                warehouse.CountryID = wareHouse.CountryID;
                warehouse.State_Province = wareHouse.State_Province;
                warehouse.Zip_PostalCode = wareHouse.Zip_PostalCode;
                warehouse.Email = wareHouse.Email;
                warehouse.PhoneNumber = wareHouse.PhoneNumber;
                warehouse.MobileNumber = wareHouse.MobileNumber;
                warehouse.FaxNumber = wareHouse.FaxNumber;
                warehouse.Remarks = wareHouse.Remarks;
                warehouse.isActive = wareHouse.isActive;
                warehouse.UpdatedBy = 6;
                warehouse.UpdatedOn = DateTime.Now;
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
            return CreatedAtRoute("DefaultApi", new { id = warehouse.WarehouseID }, warehouse);



        }

        // DELETE: api/WareHouse/5
        public void Delete(int id)
        {
        }
    }
}
