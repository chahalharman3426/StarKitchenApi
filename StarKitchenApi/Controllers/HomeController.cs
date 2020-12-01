using StarKitchenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarKitchenApi.Controllers
{
    public class HomeController : Controller
    {
        DatabaseCredential dbC = new DatabaseCredential();
        StarKitchenEntities dbc = new StarKitchenEntities();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult mailView()
        {
            ViewBag.Title = "Home Page";

            return View(dbc.MailCredentials.ToList());
        }

        // GET: Client/Delete/5
        public ActionResult Delete(MailCredential IdToRemove)
        {
            var d = dbc.MailCredentials.Where(x => x.id == IdToRemove.id).FirstOrDefault();
            dbc.MailCredentials.Remove(d);
            dbc.SaveChanges();
            return RedirectToAction("mailView");
        }

        public ActionResult About()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Gallery()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult mailUs()
        {
            ViewBag.Title = "Home Page";

            return View();
        }



        [HttpPost]
        public ActionResult sendFeedback(Contact dataBlock)
        {
            //Pass the data to store the record into the table 

            dbC.Addcontact("insert into MailCredential(Name,Email,Phone,Message) values('" + dataBlock.Name + "','" + dataBlock.Email + "','" + dataBlock.Phone+ "','" + dataBlock.Message + "')");

            return View("Successfull");



        }

        public ActionResult Sucessfull()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

    }
}
