using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Vives.Models;

namespace Vives.DAO
{
    public class tblTreinplaatsDAO
    {
        //voeg treinplaats toe
        
        public int addTreinplaats(tblTreinplaats treinplaats)
        {
            using (var db = new VivesTGVDatabaseEntities())
            {
                db.tblTreinplaats.Add(treinplaats);
                db.SaveChanges();
                return treinplaats.TreinplaatsID;
            }
        }
        //verwijder treinplaats
        public void deleteTreinplaats(tblTreinplaats treinplaats)
        {
            using (var db = new VivesTGVDatabaseEntities())
            {
                db.tblTreinplaats.Remove(treinplaats);
            }
        }

        //geef het aantal treinplaatsen per bestellijn
        public int getAantalTreinplaatsenPerBestellijn(tblBestellijn bestellijn)
        {
            using (var db = new VivesTGVDatabaseEntities())
            {
                return db.tblTreinplaats.Where(a => a.BestellijnID == bestellijn.BestellijnID).Count();
            }
        }
        //zoek een treinplaats
        public tblTreinplaats getTreinplaats(int ID)
        {
            using (var db = new VivesTGVDatabaseEntities())
            {
                return db.tblTreinplaats.Where(a => a.TreinplaatsID == ID).FirstOrDefault();
            }
        }
        
    }
}
