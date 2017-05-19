using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vives.Models;
using System.Data.Entity;
namespace Vives.DAO
{
    public class tblHotelDAO
    {
        //Zoek alle hotels in een stad
        public tblHotel[] getHotelsByStad(int stadID)
        {
            using (var db = new VivesTGVEntities())
            {
                return db.tblHotel.Where(a => a.StadID == stadID).ToArray();
            }


        }
        //Zoek een hotel op ID
        public tblHotel getHotelsByID(int ID)
        {
            using (var db = new VivesTGVEntities())
            {
                return db.tblHotel.Where(a => a.HotelID == ID).FirstOrDefault();
            }


        }
    }
}
