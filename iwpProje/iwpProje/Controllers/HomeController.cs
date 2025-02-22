using iwpProje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Collections.Generic;


namespace iwpProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Destek()
        {
            var faqList = new List<Tuple<string, string>>
            {
                Tuple.Create("�a�r� merkezi �al��ma saatleriniz nedir?",
                             "�a�r� merkezimiz haftan�n 7 g�n�, sabah 08:00 ile ak�am 22:00 saatleri aras�nda hizmet vermektedir."),
                Tuple.Create("�ikayetlerimi nas�l iletebilirim?",
                             "�ikayetlerinizi online form veya �a�r� merkezimiz arac�l���yla iletebilirsiniz."),
                Tuple.Create("Hangi konularda destek alabilirim?",
                             "�r�n bilgisi, teknik destek, sipari� takibi gibi konularda destek sunuyoruz."),
                Tuple.Create("�a�r� merkezine ula�mak �cretli mi?",
                             "�a�r� merkezimizi aramak, operat�r�n�z�n standart tarifesine tabidir."),
                Tuple.Create("E-posta ile destek alabilir miyim?",
                             "Evet, info@cagrimerkezi.com adresine e-posta g�ndererek destek alabilirsiniz.")
            };

            ViewBag.FaqList = faqList; 
            return View();
        }
    }
        
        
    
}

