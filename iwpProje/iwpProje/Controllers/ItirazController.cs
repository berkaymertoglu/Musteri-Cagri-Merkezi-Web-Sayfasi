using iwpProje.Data;
using Microsoft.AspNetCore.Mvc;
using iwpProje.Models;
using System.Linq;

namespace iwpProje.Controllers
{
    public class ItirazController : Controller
    {
        private readonly AppDbContext _context;

        public ItirazController(AppDbContext context)
        {
            _context = context; // DbContext'i constructor ile alıyoruz
        }

        // Veritabanından tüm kayıtları çekmek için Index Action metodu
        public IActionResult Index()
        {
            // Veritabanından gelen tüm itirazları çekiyoruz
            var itirazlar = _context.itirazkayitlari.ToList();

            // Null kontrolü yapıyoruz, eğer null ise varsayılan değerler atıyoruz
            foreach (var itiraz in itirazlar)
            {
                itiraz.takimliderinincevabi = itiraz.takimliderinincevabi ?? "Bilinmiyor"; 
                itiraz.itirazakonuay = itiraz.itirazakonuay ?? "Bilinmiyor"; 
                itiraz.ilgilitakimlideri = itiraz.ilgilitakimlideri ?? "Bilinmiyor"; 
            }

            // Çekilen veriyi View'a gönderiyoruz
            return View(itirazlar);
        }

        [HttpGet]
        public IActionResult ItirazEkle()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> ItirazEkle(string asistaninaciklamasi)
        {
            try
            {
                // Stored procedure'ü çağırıyoruz
                await _context.ItirazEkle(asistaninaciklamasi);

                // Başarılı işlemden sonra yönlendirme
                TempData["Message"] = "İtiraz başarıyla eklendi!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj döndür
                TempData["Error"] = "İtiraz eklenirken bir hata oluştu: " + ex.Message;
                return View();
            }
        }

    }
}
