using projectLaundry.DataContext;
using projectLaundry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectLaundry.Controllers
{
    public class loginController : Controller
    {
                
        // GET: login
        public ActionResult Index()
        {
        
            return View();    
        }
        [HttpPost]
        public ActionResult Autherize(adminClass adminModel)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                var admin = db.adminobj.Where(x => x.username_admin == adminModel.username_admin && x.password_admin == adminModel.password_admin).FirstOrDefault();
                if (admin != null)
                {
                    Session["id_admin"] = admin.id_admin;
                    return RedirectToAction("Index","admin");


                }
                else
                {
                    
                    return View("Index");
                }
                return View();
            }
            
        }
    }
}