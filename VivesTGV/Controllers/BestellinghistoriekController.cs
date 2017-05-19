using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Vives.Models;
using Vives.Service;
using VivesTGV.Models;
using System.Diagnostics;

namespace VivesTGV.Controllers
{
    public class BestellinghistoriekController : Controller
    {
        // GET: Bestellinghistoriek
        public ActionResult Index()
        {
            tblBestellingService bestellingservice = new tblBestellingService();
            BestellinghistoriekViewModel vm = new BestellinghistoriekViewModel();
            tblBestellijnService bestellijnservice = new tblBestellijnService();
            tblProductService productservice = new tblProductService();

            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {

                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    string id = userIdClaim.Value;

                    IEnumerable<tblBestelling> bestellijst = bestellingservice.getBestellingenBytblGebruiker(id);
                    vm.bestellingID = bestellijst.Select(a => a.BestellingID).ToArray();
                    vm.besteldatum = bestellijst.Select(a => a.Besteldatum).ToArray();
                    vm.vertekdatum = bestellijst.Select(a => a.Vertrekdatum).ToArray();
                    double[] ordertotalen = new double[bestellijst.Count()];
                    Bestellingstatus[] bestelstatussen = new Bestellingstatus[bestellijst.Count()];
                    
                    for (int i = 0; i < bestellijst.Count(); i++)
                    {
                        double ordertotaal = 0;
                       IEnumerable<tblBestellijn> bestellijnen =  bestellingservice.getBestellijnenByBestelling(bestellijst.ElementAt(i));
                        for (int j = 0; j < bestellijnen.Count(); j++)
                        {
                            tblProduct product = productservice.getProduct(bestellijnen.ElementAt(j).ProductID);
                            ordertotaal += productservice.getPrijs(product);
                        }
                        ordertotalen[i] = ordertotaal;
                        Bestellingstatus status =Bestellingstatus.InBewerking;
                        if (bestellijst.ElementAt(i).Geannuleerd == 1)
                        {
                            status = Bestellingstatus.Geannuleerd;
                        }
                        else
                        {
                            if (bestellijst.ElementAt(i).Vertrekdatum <= DateTime.Today)
                            {
                                status = Bestellingstatus.Voltooid;
                            }
                            else
                            {
                                status = Bestellingstatus.InBewerking;
                            }
                            
                        }
                        bestelstatussen[i] = status;

                    }
                    vm.ordertotaal = ordertotalen;
                    vm.status = bestelstatussen;
                    
                }
            }
            return View(vm);
        }
        [HttpPost]
        public void AnnuleerBestelling(int id)
        {
            Debug.WriteLine("POST: " + id);
            tblBestellingService service = new tblBestellingService();
            service.bestellingAnnuleren(id);
        }
    }
}