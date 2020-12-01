using StarKitchenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarKitchenApi.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service

        StarKitchenEntities dbc = new StarKitchenEntities();
        public ActionResult ViewSevice()
        {
            return View(dbc.ServicesCredentials.ToList());
        }


        public ActionResult SeviceCorner()
        {
            return View(dbc.ServicesCredentials.ToList());
        }


        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")]ServicesCredential services)
        {
            if (!ModelState.IsValid)
                return View();
            dbc.ServicesCredentials.Add(services);
            dbc.SaveChanges();
            return RedirectToAction("ViewService");
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in dbc.ServicesCredentials where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(ServicesCredential IdToEdit)
        {
            var orignalRecord = (from m in dbc.ServicesCredentials where m.id == IdToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            dbc.Entry(orignalRecord).CurrentValues.SetValues(IdToEdit);

            dbc.SaveChanges();
            return RedirectToAction("ViewService");


        }

        // GET: Client/Delete/5
        public ActionResult Delete(ServicesCredential IdToRemove)
        {
            var d = dbc.ServicesCredentials.Where(x => x.id == IdToRemove.id).FirstOrDefault();
            dbc.ServicesCredentials.Remove(d);
            dbc.SaveChanges();
            return RedirectToAction("ViewService");
        }

        // POST: Service/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
