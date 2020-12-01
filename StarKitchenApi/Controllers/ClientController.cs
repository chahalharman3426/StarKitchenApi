using StarKitchenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarKitchenApi.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        StarKitchenEntities dbc = new StarKitchenEntities();
        public ActionResult ViewClient()
        {
            return View(dbc.ClientCredentials.ToList());
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
        public ActionResult Create([Bind(Exclude = "id")]ClientCredential client)
        {
            if (!ModelState.IsValid)
                return View();
            dbc.ClientCredentials.Add(client);
            dbc.SaveChanges();
            return RedirectToAction("ViewClient");
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in dbc.ClientCredentials where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(ClientCredential IdToEdit)
        {
            var orignalRecord = (from m in dbc.ClientCredentials where m.id == IdToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            dbc.Entry(orignalRecord).CurrentValues.SetValues(IdToEdit);

            dbc.SaveChanges();
            return RedirectToAction("ViewClient");


        }

        // GET: Client/Delete/5
        public ActionResult Delete(ClientCredential IdToRemove)
        {
            var d =dbc.ClientCredentials.Where(x => x.id == IdToRemove.id).FirstOrDefault();
            dbc.ClientCredentials.Remove(d);
            dbc.SaveChanges();
            return RedirectToAction("ViewClient");
        }

        // POST: Client/Delete/5
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
