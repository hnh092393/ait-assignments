using AppView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppView.Controllers
{
    public class LanguageViewController : Controller
    {
        LanguageWSReference.LanguageClient languageClient = new LanguageWSReference.LanguageClient();

        public ActionResult Index()
        {
            // get language list from AppModel
            LanguageWSReference.LanguageDTO[] languageList = languageClient.GetAllLanguage();

            // transfer data from AppModel to AppView
            List<LanguageViewDTO> languageViewList = new List<LanguageViewDTO>();
            foreach (LanguageWSReference.LanguageDTO language in languageList)
            {
                languageViewList.Add(new LanguageViewDTO(language.LID, language.LanguageName));
            }

            ViewData["LanguageList"] = languageViewList;

            return View();
        }

        // create language
        public ActionResult Create()
        {
            return View();
        }

        // delete language
        public ActionResult Delete(int ID)
        {
            languageClient.IsLanguageDeleted(ID);
            return RedirectToAction("Index");
        }

        // edit language
        public ActionResult Edit(int ID, string languageName)
        {
            LanguageViewDTO languageView = new LanguageViewDTO(ID, languageName);
            ViewData["Language"] = languageView;
            return View();
        }

        // add new language data into AppModel
        public ActionResult AddLanguage(LanguageViewDTO languageView)
        {
            // get data from user input
            LanguageWSReference.LanguageDTO language = new LanguageWSReference.LanguageDTO
            {
                LanguageName = languageView.LanguageName
            };

            // add data into database and confirm
            if (languageClient.IsLanguageInserted(language))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create");
            }
        }

        // save language after editing
        public ActionResult SaveLanguage(LanguageViewDTO languageView)
        {
            // transfer data from view to controller
            LanguageWSReference.LanguageDTO language = new LanguageWSReference.LanguageDTO
            {
                LID = languageView.LID,
                LanguageName = languageView.LanguageName
            };

            // edit database in model
            if (languageClient.IsLanguageUpdated(language))
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