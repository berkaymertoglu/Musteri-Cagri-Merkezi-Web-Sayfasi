using Microsoft.AspNetCore.Mvc;
using iwpProje.Data;
using iwpProje.Models;
using System.Linq;
using Npgsql.Internal;
using System.Reflection.Metadata;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;


namespace iwpProje.Controllers
{
    public class MusteriController : Controller
    {
        private readonly AppDbContext _context;

        public MusteriController(AppDbContext context)
        {
            _context = context; 
        }

        
        public IActionResult Index()
        {
            var kayitlar = _context.mustericagrikayitlari
                            .OrderBy(x => x.cagriid) 
                            .Take(10)
                            .ToList();
            return View(kayitlar);
        }

        public IActionResult CagriKayitlari1Hafta()
        {
            var view = _context.CagriListesi1Hafta.ToList();
            return View(view);
        }

        public IActionResult KayitSil(int id)
        {
            var kayit = _context.mustericagrikayitlari.FirstOrDefault(x => x.cagriid == id);
            _context.Remove(kayit);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult KayitGetir(int id)
        {
            var kayit = _context.mustericagrikayitlari.Find(id);
            return View("CagriGetir", kayit);
        }

        public IActionResult KayitGuncelle(mustericagrikayitlari m)
        {
            var kayit = _context.mustericagrikayitlari.Find(m.cagriid);
            kayit.asistansicil = m.asistansicil;
            kayit.gorusmekonusuid = m.gorusmekonusuid;
            kayit.gorusmedurumid = m.gorusmedurumid;
            kayit.baslamasaati = m.baslamasaati;
            kayit.bitissaati = m.bitissaati;
            kayit.cagrisuresi = m.cagrisuresi;
            kayit.ogunkucagrisayisi = m.ogunkucagrisayisi;
            kayit.urettigiprim = m.urettigiprim;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CagriEkle()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> CagriEkle(string asistansicil, int gorusmekonusuid, DateTime gorusmetarihi, TimeSpan baslamasaati, TimeSpan bitissaati, int gorusmedurumid, string musteriid)
        {
            // Çağrı ekleme işlemi için gerekli parametreleri veritabanına ilet
            await _context.CagriEkle(asistansicil, gorusmekonusuid, gorusmetarihi, baslamasaati, bitissaati, gorusmedurumid, musteriid);

            // İşlem tamamlandığında Index sayfasına yönlendirme
            return RedirectToAction("Index");
        }


        public IActionResult Musteriler()
        {
            var musteriler = _context.musteriler.Take(50).ToList();
            return View(musteriler);
        }

        public IActionResult CascadeSil(string id)
        {            
            var musteri = _context.musteriler.FirstOrDefault(x => x.musteriid == id);
            if (musteri != null)
            {
                var cagriKayitlari = _context.mustericagrikayitlari
                                             .Where(x => x.musteriid == musteri.musteriid)
                                             .ToList();

                _context.mustericagrikayitlari.RemoveRange(cagriKayitlari);          
                _context.musteriler.Remove(musteri);
                _context.SaveChanges();
            }

            return RedirectToAction("Musteriler");
        }

        public IActionResult MusteriGetir(string id)
        {
            var musteri = _context.musteriler.FirstOrDefault(x => x.musteriid == id);
            return View("MusteriGetir", musteri);
        }

        [HttpPost]
        public IActionResult MusteriGuncelle(musteriler model, string eskiMusteriId)
        {
            try
            {
                // Müşteri bilgilerini eski id ile al
                var musteri = _context.musteriler.FirstOrDefault(x => x.musteriid == eskiMusteriId);

                if (musteri == null)
                {
                    return NotFound("Müşteri bulunamadı.");
                }

                // Müşterinin ismini güncelle
                musteri.musteriadi = model.musteriadi;

                // İlgili müşteri için tüm çağrı kayıtlarını al
                var cagriKayitlari = _context.mustericagrikayitlari
                    .Where(x => x.musteriid == eskiMusteriId)
                    .ToList();

                // Çağrı kayıtlarındaki müşteri ismini güncelle
                foreach (var cagri in cagriKayitlari)
                {
                    cagri.musteriadi = model.musteriadi;
                }

                // Veritabanına kaydet
                _context.SaveChanges();

                return RedirectToAction("Musteriler");
            }
            catch (Exception ex)
            {
                return BadRequest($"Güncelleme sırasında bir hata oluştu: {ex.Message}");
            }
        }

        public IActionResult CagriKayitlariPDF()
        {
            // Veriyi çek
            var kayitlar = _context.mustericagrikayitlari
                                    .OrderBy(x => x.cagriid)
                                    .Take(10)
                                    .ToList();

            // PDF oluşturmak için bir MemoryStream kullan
            MemoryStream memoryStream = new MemoryStream();

            try
            {
                // PdfWriter ve PdfDocument oluştur
                var writer = new PdfWriter(memoryStream);
                var pdf = new PdfDocument(writer);
                var document = new iText.Layout.Document(pdf);

                // PDF başlığı
                document.Add(new Paragraph("Musteri Cagri Kayitlari")
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                            .SetFontSize(20));

                // Veriyi döngüyle PDF'e ekle
                foreach (var kayit in kayitlar)
                {
                    var cagriMetni = $"Cagri ID: {kayit.cagriid}, " +
                                     $"Musteri ID: {kayit.musteriid}, " +
                                     $"Asistan Sicil: {kayit.asistansicil}, " +
                                     $"Gorusme Konusu: {kayit.gorusmekonusuid}, " +
                                     $"Gorusme Durumu: {kayit.gorusmedurumid}, " +
                                     $"Baslama Saati: {kayit.baslamasaati}, " +
                                     $"Bitis Saati: {kayit.bitissaati}, " +
                                     $"Çagri Süresi: {kayit.cagrisuresi}, " +
                                     $"Musteri Adi: {kayit.musteriadi}";

                    document.Add(new Paragraph(cagriMetni).SetFontSize(12));
                }

                // PDF işlemini sonlandır
                document.Close();
                pdf.Close();
                writer.Close();

                // PDF dosyasını döndür
                return File(memoryStream.ToArray(), "application/pdf", "CagriKayitlari.pdf");
            }
            catch (Exception ex)
            {
                // Hata mesajını döndür (Debug için)
                return BadRequest($"PDF oluşturma sırasında bir hata oluştu: {ex.Message}");
            }
            finally
            {
                // MemoryStream'i temizle
                memoryStream.Dispose();
            }
        }


    }
}

