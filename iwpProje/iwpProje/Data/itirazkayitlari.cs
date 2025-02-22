using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iwpProje.Models
{
    public class itirazkayitlari
    {
        [Key]
        public int itirazid { get; set; }   
        public DateTime tarih {  get; set; }    
        public string asistanid { get; set; }   
        public string asistaninaciklamasi { get; set; } 
        public string takimliderinincevabi { get; set; }    
        public int durumid { get; set; } 
        public string itirazakonuay {  get; set; }  
        public string ilgilitakimlideri { get; set; }   
    }
}
