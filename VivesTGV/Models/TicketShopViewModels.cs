using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vives.Models;
using System.ComponentModel.DataAnnotations;
using Foolproof;

 

namespace VivesTGV.Models
{
    public class TicketShopViewModels
    {

        public string[] vertrek { get; set; }
        [Unlike("vertrek",ErrorMessage ="De vertreklocatie mag niet gelijk zijn aan de aankomstlocatie.")]
        public string[] aankomst { get; set; }
        public string[] tussenstops { get; set; }
        public tblTraject traject { get; set; }
        [Required]
        public string vertrekdatum { get; set; }
        [Required]
        [Range(1,10,ErrorMessage ="Je kan slechts 10 plaatsen per keer boeken.")]
        public int aantal { get; set; }
        [Display(Name ="Naam reiziger")]
        [Required]
        public string[] namen { get; set; }
        [Required]
        public  bool[] treinklassen { get; set; }

        
    }
}