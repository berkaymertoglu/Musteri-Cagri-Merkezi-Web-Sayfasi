using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iwpProje.Data
{
    public class oturumacmiskullanici
    {
        [Key]        
        public int oturumid { get; set; } 
        public string personelid { get; set; } 
        public DateTime oturumbaslangiczamani { get; set; } 
    }
}
