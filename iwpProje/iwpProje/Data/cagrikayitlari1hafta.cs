using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace iwpProje.Models
{
    public class cagrikayitlari1hafta
    {
        public int cagriid { get; set; } // mck.cagriid
        public string musteriadi { get; set; } // m.musteriadi
        public string konu { get; set; } // gk.konu
        public DateTime gorusmetarihi { get; set; } // mck.gorusmetarihi
        public TimeSpan baslamasaati { get; set; } // mck.baslamasaati
        public TimeSpan bitissaati { get; set; } // mck.bitissaati
        public string durum { get; set; } // gd.durum
    }
}
