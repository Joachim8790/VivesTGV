using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Vives.Models;

namespace Vives.DAO
{
    public class tblBestellijnDAO
    {
        //krijg het aantal personen voor hotel of trein van de bestellijn
        public int countPersonen(tblBestellijn bestellijn)
        {
            using (var db = new VivesTGVEntities())
            {
                return db.tblTreinplaats.Where(a => a.BestellijnID == bestellijn.BestellijnID).Count();
            }
        }
        //krijg een lijst van de personen van de bestellijn
        public IEnumerable<tblTreinplaats> getPersonen(tblBestellijn bestellijn)
        {
            using (var db = new VivesTGVDatabaseEntities())
            {
                return db.tblTreinplaats.Where(a => a.BestellijnID == bestellijn.BestellijnID).ToList();
            }
        }
        //Schrijf bestellijnen weg
        public int addBestellijn(tblBestellijn bestellijn)
        {
            using (var db = new VivesTGVDatabaseEntities())
            {
                db.tblBestellijn.Add(bestellijn);
                db.SaveChanges();
                return bestellijn.BestellijnID;

            }
        }
    }
}
