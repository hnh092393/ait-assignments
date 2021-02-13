using AppView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppView.Controllers
{
    public class DirectorViewController : Controller
    {
        DirectorWSReference.DirectorClient directorClient = new DirectorWSReference.DirectorClient();

        public ActionResult Index()
        {
            // get director list from AppModel
            DirectorWSReference.DirectorDTO[] directorList = directorClient.GetAllDirector();

            // transfer data from AppModel to AppView
            List<DirectorViewDTO> directorViewList = new List<DirectorViewDTO>();
            foreach (DirectorWSReference.DirectorDTO director in directorList)
            {
                directorViewList.Add(new DirectorViewDTO(director.DID, director.DirectorName));
            }

            ViewData["DirectorList"] = directorViewList;

            return View();
        }

        // create director
        public ActionResult Create()
        {
            return View();
        }

        // delete director
        public ActionResult Delete(int ID)
        {
            directorClient.IsDirectorDeleted(ID);
            return RedirectToAction("Index");
        }

        // edit director
        public ActionResult Edit(int ID, string directorName)
        {
            DirectorViewDTO directorView = new DirectorViewDTO(ID, directorName);
            ViewData["Director"] = directorView;
            return View();
        }

        // add new director data into AppModel
        public ActionResult AddDirector(DirectorViewDTO directorView)
        {
            // get data from user input
            DirectorWSReference.DirectorDTO director = new DirectorWSReference.DirectorDTO
            {
                DirectorName = directorView.DirectorName
            };

            // add data into database and confirm
            if (directorClient.IsDirectorInserted(director))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create");
            }
        }

        // save director after editing
        public ActionResult SaveDirector(DirectorViewDTO directorView)
        {
            // transfer data from view to controller
            DirectorWSReference.DirectorDTO director = new DirectorWSReference.DirectorDTO
            {
                DID = directorView.DID,
                DirectorName = directorView.DirectorName
            };

            // edit database in model
            if (directorClient.IsDirectorUpdated(director))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit");
            }
        }
    }
}