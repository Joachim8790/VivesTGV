using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vives.DAO;
using Vives.Models;

namespace Vives.Service
{
    public class tblTrajectService
    {
        private tblTrajectDAO trajectDAO = new tblTrajectDAO();
        public tblTraject getTrajectByVertrekAankomst(string vertrek, string aankomst)
        {
            if (vertrek.Equals(aankomst))// is vertrek = aankomst?
            {
                throw new Exception("Vertrek kan niet gelijk zijn aan Aankomst");
            }
            else
            {
                return trajectDAO.getTrajectByVertrekAankomst(vertrek, aankomst);
            }
        }
        //Zoek traject op TrajectID
        public tblTraject getTrajectByID(int ID)
        {


            return trajectDAO.getTrajectByID(ID);
            


        }
        //krijg alle tussenlocaties van een traject
        public IEnumerable<string> getStopsByTraject(tblTraject traject)
        {
            if (trajectDAO.getTrajectByID(traject.TrajectID) != null)//bestaat traject
            {
                return trajectDAO.getStopsByTraject(traject);
            }
            else
            {
                throw new Exception("Traject bestaat niet");
            }

            
            
        }
        //kijkt als er plaatsen vrij zijn
        public bool checkPlaatsvrij(tblTraject traject, DateTime datum, byte treinklasse)
        {
            return trajectDAO.checkPlaatsvrij(traject, datum, treinklasse);
        }
        //geeft plaatsnummer
        public int getPlaatsnummer(tblTraject traject, DateTime datum, byte treinklasse)
        {
            return trajectDAO.getPlaatsnummer(traject, datum, treinklasse);
        }
    }
}
