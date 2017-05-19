using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vives.Models;
namespace VivesTGV.Models
{
    public class WinkelmandViewModel
    {
        public string[] trajectvertrek { get; set; }
        public string[] trajectaankomst { get; set; }
        public DateTime[] trajectdatum { get; set; }
        public DateTime[] hoteldatum { get; set; }
        public int[] trajectenIDs { get; set; }
        public int[] treinplaats { get; set; }
        public double[] hotelprijzen { get; set; }
        public double[] trajectprijzen { get; set; }
        public int[] hotelIDs { get; set; }
        public string[] hotelnaam { get; set; }
        public string[] hotelnamen { get; set; }
        public string[] trajectnamen { get; set; }
        public bool[] treinklassen { get; set; }
        public int[] trajectwinkelmandIDs { get; set; }
        public int[] hotelwinkelmandIDs { get; set; }

        

    }
}