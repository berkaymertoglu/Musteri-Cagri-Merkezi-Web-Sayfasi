using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iwpProje.Models
{
    public class mustericagrikayitlari
    {

        [Key]
        public int cagriid { get; set; }

        public string asistansicil { get; set; }
   
        public int gorusmekonusuid { get; set; }
   
        public DateTime gorusmetarihi { get; set; }

        public int gorusmedurumid { get; set; }

        public string musteriid { get; set; }

        public TimeSpan baslamasaati { get; set; }

        public TimeSpan bitissaati { get; set; }

        public int cagrisuresi { get; set; }

        public int ogunkucagrisayisi { get; set; }

        public double urettigiprim { get; set; }

        public string musteriadi { get; set; }  
    }
}