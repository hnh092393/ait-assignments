using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppView.Controllers
{
    public class ReserveViewController : Controller
    {
        ReserveWSReference.ReserveClient reserveClient = new ReserveWSReference.ReserveClient();

        public ActionResult Reserve(int mediaID)
        {
            // get user ID from session
            int uID = (int)Session["UID"];

            // get reserve date
            string reserveDate = DateTime.Now.ToString();

            // add reserve into database
            reserveClient.IsReservedInserted(uID, mediaID, reserveDate);

            return RedirectToAction("Index", "MediaView");
        }
    }
}