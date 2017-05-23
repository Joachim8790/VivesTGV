using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;
using Vives.Models;
namespace Vives.DAO
{
    public class tblTrajectDAO
    {
        //Zoek traject op vertrek en aankomst
        public tblTraject getTrajectByVertrekAankomst(string vertrek,string aankomst)
        {
            using (var db = new VivesTGVEntities1())
            {
                int vertrekID = db.tblStad.Where(a => a.Naam == vertrek).FirstOrDefault().StadID;
                int aankomstID = db.tblStad.Where(a => a.Naam == aankomst).FirstOrDefault().StadID;

                var traject = from t in db.tblTraject
                              where ((t.Vertrek == vertrekID) && (t.Aankomst == aankomstID))
                              select t;

                return traject.FirstOrDefault();
            }

        }
        //Zoek traject op TrajectID
        public tblTraject getTrajectByID(int ID)
        {
            using (var db = new VivesTGVEntities1())
            {
                

                return db.tblTraject.Where(c => c.TrajectID == ID).FirstOrDefault();
            }


        }
        //krijg alle tussenlocaties van een traject
        public IEnumerable<string> getStopsByTraject(tblTraject traject)
        {
            using (var db = new VivesTGVEntities1())
            {


                
              return  db.tblTussenlocatie.Where(c => c.TrajectID == traject.TrajectID).OrderBy(d => d.Volgnummer).Select(e =>e.Naam).ToList();
            }
        }
        //kijkt als er plaatsen vrij zijn
        public bool checkPlaatsvrij(tblTraject traject, DateTime datum, byte treinklasse)
        {
            int aantalplaatsen = 0;
            double multiplier = 0;
            
            if((traject.Aankomst  ==3||traject.Aankomst ==2)&&datum.AddMonths(1)>=new DateTime(DateTime.Today.Year, 12, 25))
            {
                multiplier = 0.3;
            }
            if ((traject.Aankomst == 3 || traject.Aankomst == 4 || traject.Aankomst==1) && datum >= new DateTime(DateTime.Today.Year, 3, 31)&& datum < new DateTime(DateTime.Today.Year,4,15))
            {
                multiplier = 0.3;
            }
            using (var db = new VivesTGVEntities1())
            {
                if (treinklasse == 0)
                {
                    aantalplaatsen = traject.EconomicPlaatsen;
                    aantalplaatsen = (int)Math.Floor(aantalplaatsen *(1 + multiplier));
                }
                else if (treinklasse == 1)
                {
                    aantalplaatsen = traject.BusinessPlaatsen;
                    aantalplaatsen = (int)Math.Floor(aantalplaatsen * (1 + multiplier));
                }

                int aantalplaatsenbezet = db.tblTreinplaats.Where(a => a.Treinklasse == treinklasse).Select(v => v.Plaatsnummer).Max();
                int aantalplaatsenvrij = aantalplaatsen - aantalplaatsenbezet;
                if (aantalplaatsenvrij > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //geeft plaatsnummer
        public int getPlaatsnummer(tblTraject traject, DateTime datum, byte treinklasse)
        {
            int aantalplaatsen = 0;


            using (var db = new VivesTGVEntities1())
            {
                if (treinklasse == 0)
                {
                    aantalplaatsen = traject.EconomicPlaatsen;
                }
                else if (treinklasse == 1)
                {
                    aantalplaatsen = traject.BusinessPlaatsen;
                }
                Debug.WriteLine("treinklasse: " + treinklasse);

                if (db.tblTreinplaats.Count() != 0)
                {
                    int aantalplaatsenbezet = db.tblTreinplaats.Where(a => a.Treinklasse == treinklasse).Select(v => v.Plaatsnummer).Max();
                    Debug.WriteLine(aantalplaatsenbezet);
                    return aantalplaatsenbezet + 1;
                }
                else
                {
                    return 1;
                }
                

               
                
            }
        }
    }
}
