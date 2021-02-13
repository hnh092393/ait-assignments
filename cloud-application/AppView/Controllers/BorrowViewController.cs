using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppView.Controllers
{
    public class BorrowViewController : Controller
    {
        BorrowWSReference.BorrowClient borrowClient = new BorrowWSReference.BorrowClient();
        ReserveWSReference.ReserveClient reserveClient = new ReserveWSReference.ReserveClient();

        // borrow a media
        public ActionResult Borrow(int mediaID)
        {
            int uID = (int)Session["UID"];
            string borrowDate = DateTime.Now.ToString();

            // user have 7 days to return book
            string returnDate = DateTime.Now.AddDays(7).ToString();

            // add borrow row into borrow table
            borrowClient.IsBorrowInserted(uID, mediaID, borrowDate, returnDate);

            // remove media from reserved table
            reserveClient.IsReservedDeleted(mediaID);

            return RedirectToAction("Index", "MediaView");
        }

        // return a media
        public ActionResult Return(int mediaID)
        {
            // set actual return date
            string actualReturnDate = DateTime.Now.ToString();
            borrowClient.IsBorrowUpdated(actualReturnDate, mediaID);

            return RedirectToAction("Index", "MediaView");
        }
    }
}