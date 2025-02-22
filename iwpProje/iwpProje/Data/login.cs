using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace iwpProje.Models
{
    public class login
    {
        [Required]
        [EmailAddress]
        public string eposta { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string sifre { get; set; }

        [BindNever] 
        public string? personelid { get; set; }

        [BindNever]
        public string? personeladi { get; set; }

        [BindNever]
        public string? personelsoyadi { get; set; }  
    }
}
