using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vives.DAO;
using Vives.Models;

namespace Vives.Service
{
    public class tblBestellingService
    {
        private tblBestellingDAO bestellingDAO = new tblBestellingDAO();
        private AspNetUsers aspnetusers = new AspNetUsers();
        //Zoek alle bestellingen van gebruiker
        public IEnumerable<tblBestelling> getBestellingenBytblGebruiker(string gebruikersid)
        {
           
                return bestellingDAO.getBestellingenBytblGebruiker(gebruikersid);
           

        }
        //Zoek bestelling op ID
        public tblBestelling getBestellingByID(int ID)
        {
            return bestellingDAO.getBestellingByID(ID);
        }

        //Lijst van bestellijnen per bestelling
        public IEnumerable<tblBestellijn> getBestellijnenByBestelling(tblBestelling bestelling)
        {
            if (bestellingDAO.getBestellingByID(bestelling.BestellingID) != null)//bestelling bestaat
            {
                return bestellingDAO.getBestellijnenByBestelling(bestelling);
            }
            else
            {
                throw new Exception("Bestelling bestaat niet");
            }
        }
        //Schrijf nieuwe bestelling weg
        public int addBestelling(tblBestelling bestelling)
        {
            return bestellingDAO.addBestelling(bestelling);
        }
        //bestelling annuleren
        public void bestellingAnnuleren(int id)
        {
            bestellingDAO.bestellingAnnuleren(id);
        }
    }
}
