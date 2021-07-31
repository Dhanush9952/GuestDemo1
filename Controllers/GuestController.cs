using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuestDemo1.Models;

namespace GuestDemo1.Controllers
{
    public class GuestController : Controller
    {
        //
        // GET: /Guest/

        public ActionResult Details(int id)
        {
            GuestService gs = new GuestService();
            Guest guest = gs.ShowGuest(id);
            return View(guest);
        }

        public ActionResult Index()
        {
            var guestDetails = new GuestService();
            var guests = guestDetails.GetAllGuests();
            return View(guests);
        }

        public ActionResult Edit(int id)
        {
            GuestService gs = new GuestService();
            Guest guest = gs.ShowGuest(id);
            return View(guest);
        }

        [HttpPost]
        public ActionResult Create(Guest newGuest)
        {
            if (ModelState.IsValid)
            {
                GuestService gs = new GuestService();
                gs.AddGuest(newGuest);

                return RedirectToAction("Index");
            }
            else
            {
                return View(newGuest);
            }
 
        }

        public ActionResult Edit(int id, FormCollection collection)
        {
            Guest updateGuest = null;
            try
            {
                updateGuest = new Guest();
                updateGuest.GuestNo = id;
                updateGuest.GuestName = collection["GuestName"];
                updateGuest.PhoneNumber = collection["Phone Number"];
                GuestService gs = new GuestService();
                gs.UpdateGuest(updateGuest);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(updateGuest);
            }
        }

        public ActionResult Delete(int id)
        {
            GuestService gs = new GuestService();
            Guest guest = gs.ShowGuest(id);
            return View(guest);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Guest deleteGuest = null;
            try
            {
                deleteGuest = new Guest();
                deleteGuest.GuestName = collection["GuestName"];
                deleteGuest.PhoneNumber = collection["PhoneNumber"];
                GuestService gs = new GuestService();
                gs.RemoveGuest(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(deleteGuest);
            }
        }

        public ActionResult Create()
        {
            return View(new Guest());
        }

    }
}
