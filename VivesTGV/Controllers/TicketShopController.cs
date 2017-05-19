using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VivesTGV.Models;
using Vives.Models;
using Vives.Service;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Diagnostics;
using System.Security.Claims;
using System.Globalization;

namespace VivesTGV.Controllers
{
    public class TicketShopController : Controller
    {
        private int aantal;
        // GET: TicketShop
        [Authorize]
        public ActionResult Index()
        {
            tblStadService stadservice = new tblStadService();
            TicketShopViewModels vm = new TicketShopViewModels();
            

            vm.aankomst = stadservice.getSteden().ToArray();
            vm.vertrek = stadservice.getSteden().ToArray();


            return View(vm);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Index(TicketShopViewModels vm)
        {
            tblTrajectService trajectService = new tblTrajectService();
           
            if (vm.namen == null)
            {
                string strVertrek = Request.Form["vertrek"].ToString();
                string strAankomst = Request.Form["aankomst"].ToString();

                
                
               
              
                if (strVertrek.Equals(strAankomst))
                {
                    ViewBag.errormsg = "Je vertreklocatie mag niet gelijk zijn met je aankomstlocatie.";
                    vm.aantal = 0;
                    tblStadService stadservice = new tblStadService();

                    vm.aankomst = stadservice.getSteden().ToArray();
                    vm.vertrek = stadservice.getSteden().ToArray();
                }
                else
                {
                    tblStadService stadservice = new tblStadService();

                    vm.aankomst = stadservice.getSteden().ToArray();
                    vm.vertrek = stadservice.getSteden().ToArray();
                    ViewBag.vertrek = strVertrek;
                    ViewBag.aankomst = strAankomst;
                    Debug.WriteLine("aantal: " + vm.aantal);
                    Debug.WriteLine("vertrek: " + strVertrek);
                    Debug.WriteLine("aankomst: " + strAankomst);
                    Debug.WriteLine("vertrekdatum: " + vm.vertrekdatum);
                    vm.traject = trajectService.getTrajectByVertrekAankomst(strVertrek, strAankomst);
                    vm.tussenstops = trajectService.getStopsByTraject(trajectService.getTrajectByVertrekAankomst(strVertrek, strAankomst)).ToArray();
                    Debug.WriteLine("vertrekdatum: " + vm.tussenstops);
                    if (!trajectService.checkPlaatsvrij(vm.traject, DateTime.ParseExact(vm.vertrekdatum, "MM/dd/yyyy", CultureInfo.InvariantCulture), 1))
                    {
                        if (!trajectService.checkPlaatsvrij(vm.traject, DateTime.ParseExact(vm.vertrekdatum, "MM/dd/yyyy", CultureInfo.InvariantCulture), 0))//geen van beide over
                        {
                            ViewBag.errormsg = "Er zijn geen plaatsen meer beschikbaar voor " + strVertrek + " naar " + strAankomst + " op " + vm.vertrekdatum;
                        }
                        else//enkel economic over
                        {
                            ViewBag.Economic = true;
                        }
                    }
                    else
                    {
                        if (!trajectService.checkPlaatsvrij(vm.traject, DateTime.ParseExact(vm.vertrekdatum, "MM/dd/yyyy", CultureInfo.InvariantCulture), 0))//enkel business over
                        {
                            ViewBag.Business = true;
                        }
                    }

                }
                return View(vm);
                

              
            }
            else
            {
                for (int i = 0; i < vm.namen.Count(); i++)
                {
                    string id;
                    Debug.WriteLine(vm.traject.TrajectID);
                    Debug.WriteLine(vm.treinklassen[i]);
                      tblProductService productservice = new tblProductService();
                      tblProduct product = productservice.getProductByTraject(vm.traject.TrajectID,vm.treinklassen[i]);

                    var claimsIdentity = User.Identity as ClaimsIdentity;
                    if (claimsIdentity != null)
                    {
                       
                        var userIdClaim = claimsIdentity.Claims
                            .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                        if (userIdClaim != null)
                        {
                            id = userIdClaim.Value;
                            Debug.WriteLine("ProductID: " + product.ProductID);
                            Debug.WriteLine("UserID: " + id);
                            tblWinkelmandlijnService winkelmandlijnservice = new tblWinkelmandlijnService();
                            tblWinkelmandlijn winkelmandlijn = new tblWinkelmandlijn();
                            winkelmandlijn.GebruikersID = id;
                            winkelmandlijn.ProductID = product.ProductID;
                            winkelmandlijn.Naam = vm.namen[i];
                            winkelmandlijn.Datum = DateTime.ParseExact(vm.vertrekdatum,"MM/dd/yyyy",CultureInfo.InvariantCulture);
                            winkelmandlijnservice.addWinkelmandLijn(winkelmandlijn);
                            aantal = vm.namen.Count();
                            TempData["datum"] = vm.vertrekdatum;
                            TempData["namen"] = vm.namen;
                            

                        }
                    }
                   
                   
                         
                }
                return RedirectToAction("Hotels", new { id = vm.traject.Aankomst });
                
            }
            
            
        }
        [Authorize]
        public ActionResult Hotels(int id)
        {
            tblStadService stadservice = new tblStadService();

            HotelsViewModel vm = new HotelsViewModel();

            tblHotelService hotelservice = new tblHotelService();

            tblHotel[] hotels = hotelservice.getHotelsByStad(id);
            vm.hotelID = hotels.Select(a => a.HotelID).ToArray();
            vm.hotelnaam = hotels.Select(a => a.Naam).ToArray();
            vm.hoteladres = hotels.Select(a => a.Adres).ToArray();
            vm.prijspernacht = hotels.Select(a => a.PrijsPerOvernachting).ToArray();
            vm.hotelfoto = hotels.Select(a => a.HotelFoto).ToArray();
            vm.stadNaam = stadservice.getStad(id).Naam;
            if (TempData.Peek("namen") != null)
            {
                Debug.WriteLine("namen: "+(string[])TempData.Peek("namen"));
                vm.namen = (string[])TempData.Peek("namen");

            }
            if (TempData.Peek("datum") != null)
            {
                Debug.WriteLine("datum: " + (string)TempData.Peek("datum"));
                vm.datum = DateTime.ParseExact((string)TempData.Peek("datum"),"MM/dd/yyyy", CultureInfo.InvariantCulture);

            }
            return View(vm);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Hotels(HotelsViewModel model)
        {
            for (int i = 0; i < model.namen.Count(); i++)
            {

                Debug.WriteLine("hotelIDs: " + model.hotelID);
                var claimsIdentity = User.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {

                    var userIdClaim = claimsIdentity.Claims
                        .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                    if (userIdClaim != null)
                    {
                        int hotelid = 999999999;
                        if (Request.Form["0"] != null)
                        {
                            hotelid = model.hotelID[0];
                        }
                        else if (Request.Form["1"] != null)
                        {
                            hotelid = model.hotelID[1];
                        }
                        else if (Request.Form["2"] != null)
                        {
                            Debug.WriteLine(model.hotelID.Count());
                            hotelid = model.hotelID[2];
                        }
                        Debug.WriteLine(hotelid);
                        tblProductService productservice = new tblProductService();
                        tblProduct product = productservice.getProductByHotel(hotelid);
                        string id = userIdClaim.Value;
                        tblWinkelmandlijnService winkelmandlijnservice = new tblWinkelmandlijnService();
                        tblWinkelmandlijn winkelmandlijn = new tblWinkelmandlijn();
                        winkelmandlijn.GebruikersID = id;
                        winkelmandlijn.ProductID = product.ProductID;
                        winkelmandlijn.Naam = model.namen[i];
                        winkelmandlijn.Datum = model.datum;
                        winkelmandlijnservice.addWinkelmandLijn(winkelmandlijn);

                       

                    }
                }
            }


            return RedirectToAction("Index","Home");
        }
    }
}