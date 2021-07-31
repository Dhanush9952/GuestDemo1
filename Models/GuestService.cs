using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuestDemo1.Models
{
    public class GuestService
    {
        public static List<Guest> guestList = null;

        static GuestService()
        {
            guestList = new List<Guest>();
            guestList.Add(new Guest { GuestNo = 101, GuestName = "Dhanush", PhoneNumber = "9952866481" });
            guestList.Add(new Guest { GuestNo = 102, GuestName = "Tarun", PhoneNumber = "9952836481" });
            guestList.Add(new Guest { GuestNo = 103, GuestName = "Rajes", PhoneNumber = "9952867481" });
            guestList.Add(new Guest { GuestNo = 104, GuestName = "Govind", PhoneNumber = "9952866481" });
            guestList.Add(new Guest { GuestNo = 105, GuestName = "Rob", PhoneNumber = "9952166481" });
            guestList.Add(new Guest { GuestNo = 106, GuestName = "Tom", PhoneNumber = "9952806481" });
            guestList.Add(new Guest { GuestNo = 107, GuestName = "Bob", PhoneNumber = "9852866481" });
        }

        public bool AddGuest(Guest newGuest)
        {
            bool guestAdded = false;
            int oldCount = guestList.Count;
            guestList.Add(newGuest);
            int newCount = guestList.Count;
            if (newCount > oldCount)
                guestAdded = true;
            return guestAdded;
        }

        public List<Guest> GetAllGuests()
        {
            return guestList;
        }

        public Guest ShowGuest(int guestNumber)
        {
            return guestList.First(g => g.GuestNo == guestNumber);
            //return guestList.Select(x => x.GuestNo == guestNumber).FirstOrDefault<Guest>();
        }

        public Guest UpdateGuest(Guest updateGuest)
        {
            Guest guest = guestList.First(g => g.GuestNo == updateGuest.GuestNo);
            guest.GuestName = updateGuest.GuestName;
            guest.PhoneNumber = updateGuest.PhoneNumber;
            return guest;
        }


        internal void RemoveGuest(int id)
        {
            throw new NotImplementedException();
        }
    }
}