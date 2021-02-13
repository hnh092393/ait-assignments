using AppView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppView.Controllers
{
    public class GenreViewController : Controller
    {
        GenreWSReference.GenreClient genreClient = new GenreWSReference.GenreClient();

        public ActionResult Index()
        {
            // get genre list from AppModel
            GenreWSReference.GenreDTO[] genreList = genreClient.GetAllGenre();

            // transfer data from AppModel to AppView
            List<GenreViewDTO> genreViewList = new List<GenreViewDTO>();
            foreach (GenreWSReference.GenreDTO genre in genreList)
            {
                genreViewList.Add(new GenreViewDTO(genre.GID, genre.GenreName));
            }

            ViewData["GenreList"] = genreViewList;

            return View();
        }

        // create genre
        public ActionResult Create()
        {
            return View();
        }

        // delete genre
        public ActionResult Delete(int ID)
        {
            genreClient.IsGenreDeleted(ID);
            return RedirectToAction("Index");
        }

        // edit genre
        public ActionResult Edit(int ID, string genreName)
        {
            GenreViewDTO genreView = new GenreViewDTO(ID, genreName);
            ViewData["Genre"] = genreView;
            return View();
        }

        // add new genre data into AppModel
        public ActionResult AddGenre(GenreViewDTO genreView)
        {
            // get data from user input
            GenreWSReference.GenreDTO genre = new GenreWSReference.GenreDTO
            {
                GenreName = genreView.GenreName
            };

            // add data into database and confirm
            if (genreClient.IsGenreInserted(genre))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create");
            }
        }

        // save genre after editing
        public ActionResult SaveGenre(GenreViewDTO genreView)
        {
            // transfer data from view to controller
            GenreWSReference.GenreDTO genre = new GenreWSReference.GenreDTO
            {
                GID = genreView.GID,
                GenreName = genreView.GenreName
            };

            // edit database in model
            if (genreClient.IsGenreUpdated(genre))
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