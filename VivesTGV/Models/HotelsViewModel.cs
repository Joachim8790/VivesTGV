using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vives.Models;

namespace VivesTGV.Models
{
    public class HotelsViewModel
    {

        public string stadNaam { get; set; }
        public string[] namen { get; set; }
        public int[] hotelID { get; set; }
        public DateTime datum { get; set; }
        public string[] hotelnaam { get; set; }
        public string[] hoteladres { get; set; }
        public double[] prijspernacht { get; set; }
        public string[] hotelfoto { get; set; }
    }
}