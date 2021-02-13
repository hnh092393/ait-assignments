using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AppService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LanguageImp" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LanguageImp.svc or LanguageImp.svc.cs at the Solution Explorer and start debugging.
    public class LanguageImpl : ILanguage
    {
        AppController.ILanguageController languageController = new AppController.LanguageControllerImpl();
        public bool IsLanguageInserted(LanguageDTO language)
        {
            AppController.LanguageDTO languageFromController = new AppController.LanguageDTO
            {
                LanguageName = language.LanguageName
            };
            return languageController.IsLanguageInserted(languageFromController);
        }

        public bool IsLanguageDeleted(int ID)
        {
            return languageController.IsLanguageDeleted(ID);
        }

        public List<LanguageDTO> GetAllLanguage()
        {
            List<AppController.LanguageDTO> languageControllerList = languageController.GetAllLanguage();
            List<LanguageDTO> languageList = new List<LanguageDTO>();
            foreach (AppController.LanguageDTO language in languageControllerList)
            {
                languageList.Add(new LanguageDTO(language.LID, language.LanguageName));
            }

            return languageList;
        }

        public bool IsLanguageUpdated(LanguageDTO language)
        {
            AppController.LanguageDTO languageFromController = new AppController.LanguageDTO
            {
                LID = language.LID,
                LanguageName = language.LanguageName
            };

            return languageController.IsLanguageUpdated(languageFromController);
        }
    }
}
