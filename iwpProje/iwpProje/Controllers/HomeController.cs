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
                Tuple.Create("Çaðrý merkezi çalýþma saatleriniz nedir?",
                             "Çaðrý merkezimiz haftanýn 7 günü, sabah 08:00 ile akþam 22:00 saatleri arasýnda hizmet vermektedir."),
                Tuple.Create("Þikayetlerimi nasýl iletebilirim?",
                             "Þikayetlerinizi online form veya çaðrý merkezimiz aracýlýðýyla iletebilirsiniz."),
                Tuple.Create("Hangi konularda destek alabilirim?",
                             "Ürün bilgisi, teknik destek, sipariþ takibi gibi konularda destek sunuyoruz."),
                Tuple.Create("Çaðrý merkezine ulaþmak ücretli mi?",
                             "Çaðrý merkezimizi aramak, operatörünüzün standart tarifesine tabidir."),
                Tuple.Create("E-posta ile destek alabilir miyim?",
                             "Evet, info@cagrimerkezi.com adresine e-posta göndererek destek alabilirsiniz.")
            };

            ViewBag.FaqList = faqList; 
            return View();
        }
    }
        
        
    
}

