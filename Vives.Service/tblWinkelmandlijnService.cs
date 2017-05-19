using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vives.Models;
using Vives.DAO;

namespace Vives.Service
{
    public class tblWinkelmandlijnService
    {
        private WinkelmandlijnDAO winkelmandlijnDAO = new WinkelmandlijnDAO();
        
        public IEnumerable<tblWinkelmandlijn> getWinkelmandlijnenByGebruiker(string ID)
        {
           
                return winkelmandlijnDAO.getWinkelmandlijnenByGebruiker(ID);
            
        }
        public void deleteWinkelmandlijn(int id)
        {
            
                winkelmandlijnDAO.deleteWinkelmandlijn(id);
           
        }
        //verwijder alle winkelmandlijnen van een gebruiker
        public void clearWinkelmand(string ID)
        {
           
                winkelmandlijnDAO.clearWinkelmand(ID);
            
        }
        //voeg een winkelmandlijn toe
        public void addWinkelmandLijn(tblWinkelmandlijn winkelmandlijn)
        {
            winkelmandlijnDAO.addWinkelmandLijn(winkelmandlijn);
        }
        //zoek winkelmandlijn
        public tblWinkelmandlijn getWinkelmandLijn(int ID)
        {
            return winkelmandlijnDAO.getWinkelmandLijn(ID);
        }
    }
}

