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
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace VivesTGV.Controllers
{
    public class WinkelmandController : Controller
    {
        // GET: Winkelmand
        [Authorize]
        public ActionResult Index()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {

                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    string id = userIdClaim.Value;
                    tblWinkelmandlijnService winkelmandlijnservice = new tblWinkelmandlijnService();
                    tblProductService productservice = new tblProductService();
                    tblHotelService hotelservice = new tblHotelService();
                    tblTrajectService trajectservice = new tblTrajectService();
                    tblStadService stadservice = new tblStadService();
                    tblWinkelmandlijn[] winkelmandlijnen = winkelmandlijnservice.getWinkelmandlijnenByGebruiker(id).ToArray();
                    WinkelmandViewModel vm = new WinkelmandViewModel();
                    
                    List<bool> treinklassen = new List<bool>();
                    List<int> treinplaatsen = new List<int>();
                    List<double> hotelprijzen = new List<double>();
                    List<double> trajectprijzen = new List<double>();
                    List<string> vertrek = new List<string>();
                    List<string> aankomst = new List<string>();
                    List<DateTime> hoteldatum = new List<DateTime>();
                    List<DateTime> trajectdatum = new List<DateTime>();
                    List<string> hotelnamen = new List<string>();
                    List<string> trajectnamen = new List<string>();
                    List<int> hotelID = new List<int>();
                    List<int> trajectID = new List<int>();
                    List<string> hotelnaam = new List<string>();
                    List<int> trajectwinkelmandIDs = new List<int>();
                    List<int> hotelwinkelmandIDs = new List<int>();
                    int plaatsincrement = 0;

                    for (int i = 0; i < winkelmandlijnen.Count(); i++)
                    {
                        tblProduct product = productservice.getProduct((winkelmandlijnen[i].ProductID));

                        if (productservice.isHotel(product))
                        {
                           
                            hoteldatum.Add(winkelmandlijnen[i].Datum);
                            hotelprijzen.Add(productservice.getPrijs(product));
                            tblHotel hotel = hotelservice.getHotelsByID(product.HotelID.Value);
                            hotelID.Add(hotel.HotelID);
                            hotelnaam.Add(hotel.Naam);
                            hotelnamen.Add(winkelmandlijnen[i].Naam);
                            hotelwinkelmandIDs.Add(winkelmandlijnen[i].WinkelmandlijnID);
                        }
                        else
                        {
                            trajectnamen.Add(winkelmandlijnen[i].Naam);
                            trajectprijzen.Add(productservice.getPrijs(product));
                            trajectdatum.Add(winkelmandlijnen[i].Datum);
                            tblTraject traject = trajectservice.getTrajectByID(product.TrajectID.Value);
                            trajectID.Add(traject.TrajectID);
                            vertrek.Add(stadservice.getStad(traject.Vertrek).Naam);
                            aankomst.Add(stadservice.getStad(traject.Aankomst).Naam);
                            treinplaatsen.Add(trajectservice.getPlaatsnummer(traject, winkelmandlijnen[i].Datum, product.Treinklasse.Value) + plaatsincrement);
                            trajectwinkelmandIDs.Add(winkelmandlijnen[i].WinkelmandlijnID);
                            if (product.Treinklasse.Value == 1)
                            {
                                treinklassen.Add(true);
                            }
                            else
                            {
                                treinklassen.Add(false);
                            }
                            
                            plaatsincrement++;
                        }

                    }
                    vm.trajectvertrek = vertrek.ToArray();
                    vm.trajectaankomst = aankomst.ToArray();
                    vm.trajectdatum = trajectdatum.ToArray();
                    vm.hoteldatum = hoteldatum.ToArray();
                    vm.trajectenIDs = trajectID.ToArray();
                    vm.treinplaats = treinplaatsen.ToArray();
                    vm.hotelprijzen = hotelprijzen.ToArray();
                    vm.trajectprijzen = trajectprijzen.ToArray();
                    vm.hotelIDs = hotelID.ToArray();
                    vm.hotelnaam = hotelnaam.ToArray();
                    vm.trajectnamen = trajectnamen.ToArray();
                    vm.hotelnamen = hotelnamen.ToArray();
                    vm.treinklassen = treinklassen.ToArray();
                    vm.hotelwinkelmandIDs = hotelwinkelmandIDs.ToArray();
                    vm.trajectwinkelmandIDs = trajectwinkelmandIDs.ToArray();

                    return View(vm);

                }
            }

            return View();
        }
        // POST: Winkelmand
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Index(WinkelmandViewModel vm)
        {
            tblBestellijnService bestellijnservice = new tblBestellijnService();
            tblBestellingService bestellingservice = new tblBestellingService();
            tblTreinplaatsService treinplaatsservice = new tblTreinplaatsService();
            tblProductService productservice = new tblProductService();
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {

                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    string id = userIdClaim.Value;

                    tblBestelling bestelling = new tblBestelling();
                    bestelling.GebruikersID = id;
                    bestelling.Vertrekdatum = vm.trajectdatum.FirstOrDefault();
                    bestelling.Besteldatum = DateTime.Today;
                    bestelling.Geannuleerd = 0;
                    int bestellingid = bestellingservice.addBestelling(bestelling);
                    List<tblBestellijn> bestellijnen = new List<tblBestellijn>();
                    for (int i = 0; i < vm.hotelIDs.Count();i++)
                    {
                        tblBestellijn bestellijn = new tblBestellijn();
                        bestellijn.BestellingID = bestellingid;
                        tblProduct product = productservice.getProductByHotel(vm.hotelIDs[i]);
                        bestellijn.ProductID = product.ProductID;
                        int bestellijnID = bestellijnservice.addBestellijn(bestellijn);

                    }
                    for (int i = 0; i < vm.trajectenIDs.Count(); i++)
                    {
                        tblBestellijn bestellijn = new tblBestellijn();
                        bestellijn.BestellingID = bestellingid;
                        tblProduct product;
                        
                             product = productservice.getProductByTraject(vm.trajectenIDs[i], vm.treinklassen[i]);
                       
                       
                        bestellijn.ProductID = product.ProductID;

                        int bestellijnID = bestellijnservice.addBestellijn(bestellijn);
                        tblTreinplaats treinplaats = new tblTreinplaats();
                        treinplaats.BestellijnID = bestellijnID;
                        treinplaats.Naam = vm.trajectnamen[i];
                        treinplaats.Plaatsnummer = vm.treinplaats[i];
                        if (vm.treinklassen[i])
                        {
                            treinplaats.Treinklasse = 1;
                        }
                        else
                        {
                            treinplaats.Treinklasse = 0;
                        }
                        
                        treinplaatsservice.addTreinplaats(treinplaats);
                    }

                    tblWinkelmandlijnService winkelmandlijnservice = new tblWinkelmandlijnService();
                    winkelmandlijnservice.clearWinkelmand(id);
                    string bericht = "Dit zijn de gegevens van uw bestelling<br/><br/> <table class='table'><thead> <tr><th> Beschrijving </th><th> Vertrekdatum </th><th> Naam reiziger </th><th> Prijs </th></tr></thead> ";
                    for (int i = 0; i < vm.trajectenIDs.Count(); i++)
                    {
                        string tablelijn = "<tr><td>Treinticket van " + vm.trajectvertrek[i] + " naar " + vm.trajectaankomst[i] + " treinplaats " + vm.treinplaats[i] + "</td><td>" + vm.trajectdatum[i].Date.ToShortDateString() + " </td><td>" + vm.trajectnamen[i] + " </td><td>€" + vm.trajectprijzen[i] + "</td> </tr>";
                        bericht += tablelijn;
                    }
                    for (int i = 0; i < vm.hotelIDs.Count(); i++)
                    {
                        string tablelijn = "<tr><td>Hotelboeking in " + vm.hotelnaam[i] + "</td><td>" + vm.hoteldatum[i].Date.ToShortDateString() + " </td><td>" + vm.hotelnamen[i] + " </td><td>€" + vm.hotelprijzen[i] + "</td> </tr>";
                        bericht += tablelijn;
                    }
                    bericht += "</table>";
                    
                    var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    await userManager.SendEmailAsync(id, "VivesTGV: Uw bestelling "+bestelling.BestellingID,bericht);
                       
                    
                }
            }
           
            return RedirectToAction("Index","Home");

        }

        [HttpDelete]
        public void VerwijderLijn(int id)
        {
            Debug.WriteLine(id);

            tblWinkelmandlijnService winkelmandlijnservice = new tblWinkelmandlijnService();
            winkelmandlijnservice.deleteWinkelmandlijn(id);
        }
    }
}