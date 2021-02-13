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
    public class SearchControllerImpl : ISearchController
    {
        public List<MediaDTO> Search(string searchType, string searchText)
        {
            // list for storing media from search result
            List<MediaDTO> foundMediaList = new List<MediaDTO>();

            MediaDataSet.TabMediaDataTable tabMediaDataTable = new MediaDataSet.TabMediaDataTable();
            TabMediaTableAdapter tabMediaTableAdapter = new TabMediaTableAdapter();

            try
            {
                // get results by query based on search type
                switch (searchType)
                {
                    case "Title":
                        searchText = "%" + searchText + "%";
                        tabMediaTableAdapter.SelectMediaByTitle(tabMediaDataTable, searchText);
                        break;
                    case "Genre":
                        searchText = "%" + searchText + "%";
                        tabMediaTableAdapter.SelectMediaByGenreName(tabMediaDataTable, searchText);
                        break;
                    case "Director":
                        searchText = "%" + searchText + "%";
                        tabMediaTableAdapter.SelectMediaByDirectorName(tabMediaDataTable, searchText);
                        break;
                    case "Language":
                        searchText = "%" + searchText + "%";
                        tabMediaTableAdapter.SelectMediaByLanguageName(tabMediaDataTable, searchText);
                        break;
                    case "PublishYear":
                        tabMediaTableAdapter.SelectMediaByPublishYear(tabMediaDataTable, Convert.ToInt32(searchText));
                        break;
                    case "Budget":
                        tabMediaTableAdapter.SelectMediaByBudget(tabMediaDataTable, Convert.ToDecimal(searchText));
                        break;
                    default:
                        tabMediaTableAdapter.Fill(tabMediaDataTable);
                        break;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                try
                {
                    tabMediaTableAdapter.Fill(tabMediaDataTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                try
                {
                    tabMediaTableAdapter.Fill(tabMediaDataTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // convert raw data from table into media objects
            foreach (DataRow mediaRow in tabMediaDataTable.Rows)
            {
                MediaDTO media = new MediaDTO
                {
                    MediaID = Convert.ToInt32(mediaRow[0]),
                    Title = mediaRow[1].ToString(),
                    Genre = mediaRow[4].ToString(),
                    Director = mediaRow[5].ToString(),
                    Language = mediaRow[6].ToString(),
                    PublishYear = Convert.ToInt32(mediaRow[2]),
                    Budget = Convert.ToDecimal(mediaRow[3])
                };

                foundMediaList.Add(media);

            }
            return foundMediaList;
        }
    }
}
