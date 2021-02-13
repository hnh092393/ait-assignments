using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AppService
{
    [ServiceContract]
    public interface ILanguage
    {
        [OperationContract]
        List<LanguageDTO> GetAllLanguage();

        [OperationContract]
        bool IsLanguageInserted(LanguageDTO language);

        [OperationContract]
        bool IsLanguageUpdated(LanguageDTO language);

        [OperationContract]
        bool IsLanguageDeleted(int ID);
    }
}
