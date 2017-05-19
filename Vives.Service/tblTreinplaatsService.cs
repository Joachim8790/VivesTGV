using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vives.DAO;
using Vives.Models;

namespace Vives.Service
{
    public class tblTreinplaatsService
    {

        private tblTreinplaatsDAO treinplaatsDAO = new tblTreinplaatsDAO();
        public int addTreinplaats(tblTreinplaats treinplaats)
        {
            
                return treinplaatsDAO.addTreinplaats(treinplaats);
            
        }
        public void deleteTreinplaats(tblTreinplaats treinplaats)
        {
            if (treinplaatsDAO.getTreinplaats(treinplaats.TreinplaatsID) != null)//kijkt als de treinplaats wel bestaat
            {
                treinplaatsDAO.deleteTreinplaats(treinplaats);
            }
            else
            {
                throw new NullReferenceException("treinplaats bestaat niet in de database of heeft een null waarde");
            }
        }
        //zoek een treinplaats
        public tblTreinplaats getTreinplaats(int ID)
        {
            return treinplaatsDAO.getTreinplaats(ID);
        }

    }
}
