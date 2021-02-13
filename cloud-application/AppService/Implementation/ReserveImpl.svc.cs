using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AppService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReservedMediaImp" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ReservedMediaImp.svc or ReservedMediaImp.svc.cs at the Solution Explorer and start debugging.
    public class ReserveImpl : IReserve
    {
        AppController.IReserveController reserveController = new AppController.ReserveControllerImpl();
        public bool IsReservedDeleted(int MediaID)
        {
            return reserveController.IsReservedDeleted(MediaID);
        }

        public List<ReserveDTO> GetReservedInfo()
        {
            List<AppController.ReserveDTO> reserveControllerList = new List<AppController.ReserveDTO>();
            reserveControllerList = reserveController.GetReservedInfo();
            List<ReserveDTO> reserveList = new List<ReserveDTO>();
            foreach (AppController.ReserveDTO reserve in reserveControllerList)
            {
                reserveList.Add(new ReserveDTO(reserve.UserName, reserve.Title, reserve.ReservedDate));
            }
            return reserveList;
        }

        public List<KeyValuePair<int, int>> GetReservedData()
        {
            List<KeyValuePair<int, int>> reserveList = new List<KeyValuePair<int, int>>();
            reserveList = reserveController.GetReservedData();
            return reserveList;
        }

        public bool IsReservedInserted(int UID, int MediaID, string ReservedDate)
        {
            return reserveController.IsReservedInserted(UID, MediaID, ReservedDate);
        }
    }
}
