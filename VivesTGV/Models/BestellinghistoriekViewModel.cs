using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vives.Models;

namespace VivesTGV.Models
{
    public class BestellinghistoriekViewModel
    {
        public int[] bestellingID { get; set; }
        public DateTime[] besteldatum { get; set; }
        public DateTime[] vertekdatum { get; set; }
        public double[] ordertotaal { get; set; }
        public Bestellingstatus[] status { get; set; }
    }
}