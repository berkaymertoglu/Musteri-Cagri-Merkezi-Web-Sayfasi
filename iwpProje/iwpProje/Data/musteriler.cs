using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iwpProje.Models
{
    public class musteriler
    {
        [Key]  
        public string musteriid { get; set; }
     
        public string musteriadi { get; set; }
     
        public string musteritel { get; set; }
  
        public string musteriadres { get; set; }
   
        public string musteriemail { get; set; }
    }
}
