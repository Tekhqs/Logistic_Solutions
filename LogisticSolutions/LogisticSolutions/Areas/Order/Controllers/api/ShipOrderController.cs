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

namespace LogisticSolutions.Areas.Order.Controllers
{
    public class ShipOrderController : ApiController
    {
        LogisticSolutionDevDBEntities db = new LogisticSolutionDevDBEntities();
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
        [ResponseType(typeof(tblShippingOrder))]
        public IHttpActionResult Post(tblShippingOrder shippingOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //var partnerID = db.tblPartners.Where(x => x.AccountID == shippingOrder.AccountID).Select(x => x.PartnerID);
            //shippingOrder.PartnerID = Convert.ToInt32(partnerID);

            shippingOrder.isDeleted = false;
            shippingOrder.isActive = true;
            shippingOrder.StartDate = Convert.ToDateTime(shippingOrder.StartDate);
            shippingOrder.CancelDate = Convert.ToDateTime(shippingOrder.CancelDate);
            shippingOrder.ActualShipDate = Convert.ToDateTime(shippingOrder.ActualShipDate);
            shippingOrder.DeliverDate = Convert.ToDateTime(shippingOrder.DeliverDate);
            shippingOrder.CreatedOn = System.DateTime.Now;
            shippingOrder.CreatedBy = 1;
            // Convert.ToInt32(HttpContext.Current.Session["UserId"]);

            db.tblShippingOrders.Add(shippingOrder);

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
            return CreatedAtRoute("DefaultApi", new { id = shippingOrder.ShippingOrderID }, shippingOrder);
        }

        // PUT: api/ShipOrder/5

        public IHttpActionResult Put(int Id, tblShippingOrder shippingOrder)
        {
            
            

            try
            {
                var order = db.tblShippingOrders.Where(c => c.ShippingOrderID == Id).FirstOrDefault();

                order.TransactionNumber = shippingOrder.TransactionNumber;
                order.SalesOrderNumber = shippingOrder.SalesOrderNumber;
                order.QuantityPlanned = shippingOrder.QuantityPlanned;
                order.SourceID = shippingOrder.SourceID;
                order.PONumber = shippingOrder.PONumber;
                order.QuantityShipped = shippingOrder.QuantityShipped;
                order.ShippingStatus = shippingOrder.ShippingStatus;
                order.BillFreightTermNumber = shippingOrder.BillFreightTermNumber;
                order.BLNumber = shippingOrder.BLNumber;
                order.TransactionNumber = shippingOrder.TransactionNumber;
                order.ShippingOrderNumber = shippingOrder.ShippingOrderNumber;
                order.TotalShippedWeight = shippingOrder.TotalShippedWeight;
                order.TotalShippedWeightUnit = shippingOrder.TotalShippedWeightUnit;
                order.SWC = shippingOrder.SWC;
                order.StartDate = shippingOrder.StartDate;
                order.ActualShipDate = shippingOrder.ActualShipDate;
                order.CancelDate = shippingOrder.CancelDate;
                order.DeliverDate = shippingOrder.DeliverDate;
                order.AccountID = shippingOrder.AccountID;
                order.OrderShipper = shippingOrder.OrderShipper;
                order.OrderBillFreightTo = shippingOrder.OrderBillFreightTo;
                order.ShippingCarrierID = shippingOrder.ShippingCarrierID;
                order.OtherInstruction = shippingOrder.OtherInstruction;
                order.UpdatedOn = DateTime.Now;
                order.UpdatedBy = 6;
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Id))
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

        // DELETE: api/ShipOrder/5
        public void Delete(int id)
        {
        }
        private bool OrderExists(int id)
        {
            return db.tblShippingOrders.Count(e => e.ShippingOrderID == id) > 0;
        }
    }
}
