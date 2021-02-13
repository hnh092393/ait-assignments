using AppView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppView.Controllers
{
    

    public class MediaViewController : Controller
    {
        BorrowWSReference.BorrowClient borrowClient = new BorrowWSReference.BorrowClient();
        MediaWSReference.MediaClient mediaClient = new MediaWSReference.MediaClient();
        ReserveWSReference.ReserveClient reserveClient = new ReserveWSReference.ReserveClient();
        SearchWSReference.SearchClient searchClient = new SearchWSReference.SearchClient();

        // create a list of search options
        private List<SelectListItem> CreateSearchOptions(){
            List<SelectListItem> searchOptions = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Title",
                    Value = "Title"
                },
                new SelectListItem
                {
                    Text = "Genre",
                    Value = "Genre",
                },
                new SelectListItem
                {
                    Text = "Director",
                    Value = "Director"
                },
                new SelectListItem
                {
                    Text = "Language",
                    Value = "Language"
                },
                new SelectListItem
                {
                    Text = "Publish Year",
                    Value = "PublishYear",
                },
                new SelectListItem
                {
                    Text = "Budget",
                    Value = "Budget",
                }
            };

            return searchOptions;
        }

        public void SelectBorrowOrReserve()
        {
            if (Session["UID"] != null)
            {
                int uID = (int)Session["UID"];

                // borrow actions
                KeyValuePair<int, int>[] borrowList = borrowClient.GetBorrowData();
                List<int> borrowListByThisUser = new List<int>();
                List<int> borrowListByOtherUsers = new List<int>();
                foreach (KeyValuePair<int, int> borrow in borrowList)
                {
                    if (borrow.Key == uID)
                    {
                        borrowListByThisUser.Add(borrow.Value);
                    }
                    else
                    {
                        borrowListByOtherUsers.Add(borrow.Value);
                    }
                }
                ViewData["BorrowListByThisUser"] = borrowListByThisUser;
                ViewData["BorrowListByOtherUsers"] = borrowListByOtherUsers;

                // reserve actions
                KeyValuePair<int, int>[] reserveList = reserveClient.GetReservedData();
                List<int> reserveListByThisUser = new List<int>();
                List<int> reserveListByOtherUsers = new List<int>();
                foreach (KeyValuePair<int, int> reserve in reserveList)
                {
                    if (reserve.Key == uID)
                    {
                        reserveListByThisUser.Add(reserve.Value);
                    }
                    else
                    {
                        reserveListByOtherUsers.Add(reserve.Value);
                    }
                }
                ViewData["ReserveListByThisUser"] = reserveListByThisUser;
                ViewData["ReserveListByOtherUsers"] = reserveListByOtherUsers;
            }
        }

        public ActionResult Index()
        {
            ViewData["SearchOptions"] = CreateSearchOptions();

            // transfer data from AppController to AppView

            MediaWSReference.MediaDTO[] mediaList = mediaClient.GetAllMedia();
            List<MediaViewDTO> mediaViewList = new List<MediaViewDTO>();



            foreach (MediaWSReference.MediaDTO media in mediaList)
            {
                mediaViewList.Add(new MediaViewDTO(media.MediaID, media.Title, media.Genre, media.Director, media.Language, media.PublishYear, media.Budget));
            }

            ViewData["MediaList"] = mediaViewList;

            SelectBorrowOrReserve();            

            return View();
        }

        // search media when user click search button
        public ActionResult Search(string searchOption, string searchText)
        {

            SearchWSReference.MediaDTO[] mediaList = searchClient.Search(searchOption, searchText);
            List<MediaViewDTO> mediaViewList = new List<MediaViewDTO>();

            foreach (SearchWSReference.MediaDTO media in mediaList)
            {
                mediaViewList.Add(new MediaViewDTO(media.MediaID, media.Title, media.Genre, media.Director, media.Language, media.PublishYear, media.Budget));
            }

            ViewData["SearchOptions"] = CreateSearchOptions();
            ViewData["MediaList"] = mediaViewList;
            ViewData["IsSearchResult"] = true;

            SelectBorrowOrReserve();

            return View("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        // add new media to database
        public ActionResult AddMedia(MediaViewDTO mediaView)
        {
            MediaWSReference.MediaDTO media = new MediaWSReference.MediaDTO();
            media.MediaID = mediaView.MediaID;
            media.Title = mediaView.Title;
            media.Genre = mediaView.Genre;
            media.Director = mediaView.Director;
            media.Language = mediaView.Language;
            media.PublishYear = mediaView.PublishYear;
            //media.Budget = mediaView.Budget;

            if (mediaClient.IsMediaInserted(media))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Create");
            }

        }

        // edit media
        public ActionResult Edit(int ID, string title, string genre, string director, string language, int publishYear, decimal budget)
        {
            MediaViewDTO mediaView = new MediaViewDTO(ID, title, genre, director, language, publishYear, budget);
            ViewData["Media"] = mediaView;
            return View();
        }
        
        // save into database after edition
        public ActionResult SaveMedia(MediaViewDTO mediaView)
        {
            MediaWSReference.MediaDTO media = new MediaWSReference.MediaDTO();
            media.MediaID = mediaView.MediaID;
            media.Title = mediaView.Title;
            media.Genre = mediaView.Genre;
            media.Director = mediaView.Director;
            media.Language = mediaView.Language;
            media.PublishYear = mediaView.PublishYear;
            //media.Budget = mediaView.Budget;


            if (mediaClient.IsMediaUpdated(media))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Media"] = mediaView;
                return View("Edit");
            }
        }

        // delete media
        public ActionResult Delete(int ID)
        {
            mediaClient.IsMediaDeleted(ID);
            return RedirectToAction("Index");
        }
        
        // show all borrow records
        public ActionResult ReportBorrowedMedia()
        {
            BorrowWSReference.BorrowDTO[] borrowList = borrowClient.GetBorrowInfo();
            ViewData["BorrowList"] = borrowList;
            return View();
        }

        // show all reserve records
        public ActionResult ReportReservedMedia()
        {
            ReserveWSReference.ReserveDTO[] reserveList = reserveList = reserveClient.GetReservedInfo();
            ViewData["ReserveList"] = reserveList;
            return View();
        }
    }
}
