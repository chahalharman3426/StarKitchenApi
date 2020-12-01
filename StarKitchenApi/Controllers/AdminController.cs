using StarKitchenApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarKitchenApi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DatabaseCredential dbC = new DatabaseCredential();
        public ActionResult adminEnter()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AdminDetail(AdminCredential user)
        {
            //Pass the data to store the record into the table 

            DataTable tbl = new DataTable();
            tbl = dbC.CheckLogin("select * from AdminCredential where UserDetail='" + user.UserDetail + "'and PasswordDetail='" + user.PasswordDetail + "'");

            if (tbl.Rows.Count > 0)
            {
                return View("AdminZone");
            }
            else
            {
                return View("invalid");
            }
        }
        public ActionResult AdminZone()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Invalid()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
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
