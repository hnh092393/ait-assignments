using AppModel;
using AppModel.MediaDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController
{
    public class LanguageControllerImpl : ILanguageController
    {
        MediaDataSet.TabLanguageDataTable tabLanguageDataTable = new MediaDataSet.TabLanguageDataTable();
        TabLanguageTableAdapter tabLanguageTableAdapter = new TabLanguageTableAdapter();

        // get all language records
        public List<LanguageDTO> GetAllLanguage()
        {
            List<LanguageDTO> LanguageList = new List<LanguageDTO>();

            try
            {
                // get all rows in the table using query
                tabLanguageTableAdapter.Fill(tabLanguageDataTable);
                foreach (DataRow Row in tabLanguageDataTable.Rows)
                {
                    LanguageDTO Language = new LanguageDTO
                    {
                        LID = (int)Row[0],
                        LanguageName = (string)Row[1]
                    };
                    LanguageList.Add(Language);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return LanguageList;
        }

        public bool IsLanguageDeleted(int ID)
        {
            // delete language from TabLanguage
            tabLanguageTableAdapter.DeleteLanguage(ID);
            return true;
        }

        // add new language row into Language table
        public bool IsLanguageInserted(LanguageDTO newLanguage)
        {

            try
            {
                // insert row using query
                tabLanguageTableAdapter.InsertLanguage(newLanguage.LanguageName);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        // update a language row
        public bool IsLanguageUpdated(LanguageDTO updatedLanguage)
        {
            try
            {
                // update row using query
                tabLanguageTableAdapter.UpdateLanguage(updatedLanguage.LanguageName, updatedLanguage.LID);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
