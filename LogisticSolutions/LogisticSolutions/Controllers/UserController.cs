using DAL;
using LogisticSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogisticSolutions.Controllers
{
    public class UserController : Controller
    {
        LogisticSolutionDevDBEntities db = new LogisticSolutionDevDBEntities();

        // GET: User
        public ActionResult Index()
        {
            var Users = db.tblUserProfiles.ToList();

            return View(Users);
        }

        public ActionResult Create(int? id)
        {
            tblUserProfile UserProfile=new tblUserProfile();
            var customer = db.tblLSCustomers.Select(c => new
            {
                CustomerID = c.CustomerID,
                CompanyName = c.CompanyName
            }).Distinct().OrderBy(x => x.CompanyName).ToList();

            var group = db.tblSecurityGroups.Select(c => new
            {
                SecurityGroupID = c.SecurityGroupID,
                GroupName = c.GroupName
            }).Distinct().OrderBy(x => x.GroupName).ToList();
            ViewBag.Group = group;
            ViewBag.Customer = customer;
            ViewBag.Wearhouse = db.tblWarehouseMasters.ToList();
           
            if (id==0 || id==null)
            { 
                


                return View(UserProfile);




            }
            else
            {
             
                var User = db.tblUserProfiles.Where(c => c.UserID == id).FirstOrDefault();
                
                UserProfile = new tblUserProfile
                {
                    UserID = User.UserID,
                    UserName=User.UserName,
                    Email=User.Email,
                    EncryptedPassword= EncryptDecrypt.Decrypt(User.EncryptedPassword),
                    CustomerID =User.CustomerID,
                    PhoneNumber=User.PhoneNumber,
                    Mobile=User.Mobile,
                    isActive=User.isActive,
                    WarehouseID=User.WarehouseID,
                    SecurityGroupID=User.SecurityGroupID,

                   
             
                };
                
                return View(UserProfile);


            }

        }


        [HttpPost]
        public JsonResult CreatePost( tblUserProfile userProfile)
        {

            var userId = Convert.ToInt32(Session["UserId"]);
            if (userProfile.UserID == 0)
            {
                try
                {
                    
                    userProfile.EncryptedPassword = EncryptDecrypt.Encrypt(userProfile.EncryptedPassword);
                    userProfile.CreatedOn = DateTime.Now;
                    userProfile.CreatedBy = userId;
                    db.tblUserProfiles.Add(userProfile);
                    db.SaveChanges();
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {

                    throw;
                }






            }
            else
            {
                try
                {

                    var User = db.tblUserProfiles.Where(c => c.UserID == userProfile.UserID).FirstOrDefault();
                    User.UpdatedBy = userId;
                    User.UpdatedOn = DateTime.Now;
                    User.Email = userProfile.Email;
                    User.EncryptedPassword = EncryptDecrypt.Encrypt(userProfile.EncryptedPassword);
                    User.SecurityGroupID = userProfile.SecurityGroupID;
                    User.WarehouseID = userProfile.WarehouseID;
                    User.isActive = userProfile.isActive;
                    User.PhoneNumber = userProfile.PhoneNumber;
                    User.Mobile = userProfile.Mobile;
                    User.UserName = userProfile.UserName;

                    db.SaveChanges();
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {

                    throw;
                }

            }
           
        }


    }
}