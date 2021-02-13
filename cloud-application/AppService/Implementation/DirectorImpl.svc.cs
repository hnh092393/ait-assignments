using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AppService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DirectorImp" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DirectorImp.svc or DirectorImp.svc.cs at the Solution Explorer and start debugging.
    public class DirectorImpl : IDirector
    {
        AppController.IDirectorController directorController = new AppController.DirectorControllerImpl();
        public bool IsDirectorInserted(DirectorDTO director)
        {
            AppController.DirectorDTO directorFromController = new AppController.DirectorDTO
            {
                DirectorName = director.DirectorName
            };
            return directorController.IsDirectorInserted(directorFromController);
        }

        public bool IsDirectorDeleted(int ID)
        {
            return directorController.IsDirectorDeleted(ID);
        }

        public List<DirectorDTO> GetAllDirector()
        {
            List<AppController.DirectorDTO> directorControllerList = directorController.GetAllDirector();
            List<DirectorDTO> directorList = new List<DirectorDTO>();
            foreach (AppController.DirectorDTO director in directorControllerList)
            {
                directorList.Add(new DirectorDTO(director.DID, director.DirectorName));
            }

            return directorList;
        }

        public bool IsDirectorUpdated(DirectorDTO director)
        {
            AppController.DirectorDTO directorFromController = new AppController.DirectorDTO
            {
                DID = director.DID,
                DirectorName = director.DirectorName
            };

            return directorController.IsDirectorUpdated(directorFromController);
        }
    }
}
