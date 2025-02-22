using Microsoft.AspNetCore.Mvc;
using iwpProje.Models;
using Microsoft.EntityFrameworkCore;
using iwpProje.Data;

public class LoginController : Controller
{
    private readonly AppDbContext _context;

    public LoginController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    // Giriş işlemi
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(login model)
    {
        if (ModelState.IsValid)
        {
            // Eposta ve sifre ile sorgulama yapıyoruz
            var kullanici = _context.sistemkullanicilari
                .FirstOrDefault(k => k.eposta == model.eposta && k.sifre == model.sifre);

            if (kullanici != null)
            {
                // Personel bilgilerini model'e atıyoruz, ancak sadece personelid'yi session'a kaydediyoruz
                model.personelid = kullanici.personelid;
                model.personeladi = kullanici.personeladi;
                model.personelsoyadi = kullanici.personelsoyadi;

                var oturumKullanici = new oturumacmiskullanici
                {
                    personelid = kullanici.personelid,
                    oturumbaslangiczamani = DateTime.UtcNow
                };

                _context.oturumacmiskullanicilar.Add(oturumKullanici);
                _context.SaveChanges();

                // Yalnızca personelid'yi session'a kaydediyoruz
                HttpContext.Session.SetString("personelid", kullanici.personelid.ToString());

                // Ayrıca TempData'yı da kullanmaya devam edebilirsiniz
                TempData["personelid"] = kullanici.personelid;
                TempData["isim"] = kullanici.personeladi;
                TempData["soyisim"] = kullanici.personelsoyadi;
                TempData["oturumbaslangiczamani"] = oturumKullanici.oturumbaslangiczamani;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "E-posta veya şifre yanlış.";
            }
        }

        return View("Index", model);
    }
}
