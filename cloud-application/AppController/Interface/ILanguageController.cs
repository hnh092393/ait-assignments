using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController
{
    public interface ILanguageController
    {
        List<LanguageDTO> GetAllLanguage();
        bool IsLanguageInserted(LanguageDTO language);
        bool IsLanguageUpdated(LanguageDTO language);
        bool IsLanguageDeleted(int ID);
    }
}
