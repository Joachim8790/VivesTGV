using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vives.DAO;
using Vives.Models;

namespace Vives.Service
{
    public class tblHotelService
    {
        private tblHotelDAO hotelDAO = new tblHotelDAO();
        //Zoek alle hotels in een stad
        public tblHotel[] getHotelsByStad(int stadID)
        {
            return hotelDAO.getHotelsByStad(stadID);


        }
        //Zoek een hotel op ID
        public tblHotel getHotelsByID(int ID)
        {
            return hotelDAO.getHotelsByID(ID);


        }
    }
}
