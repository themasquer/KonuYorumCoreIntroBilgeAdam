using _038_KonuYorumCoreIntroBilgeAdam.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace _038_KonuYorumCoreIntroBilgeAdam.Controllers
{
    public class KonuController : Controller
    {
        private BA_KonuYorumCoreContext _db = new BA_KonuYorumCoreContext();

        public IActionResult Index()
        {
            List<Konu> konular = _db.Konu.ToList();
            return View(konular);
        }

        public IActionResult Details(int id)
        {
            Konu konu = _db.Konu.Find(id);
            return View(konu);
        }

        [HttpGet] // Eğer yazılmazsa default olarak her aksiyon HttpGet'tir
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // sunucuya bir form veya başka bir yol ile veri gönderiliyorsa mutlaka HttpPost yazılmalıdır
        public IActionResult Create(Konu konu)
        {
            _db.Konu.Add(konu);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet] // Eğer yazılmazsa default olarak her aksiyon HttpGet'tir
        public IActionResult Edit(int id)
        {
            //Konu konu = _db.Konu.Find(id);

            //Konu konu = _db.Konu.First(konu => konu.Id == id); // eğer belirtilen koşula uygun sonuç dönmezse exception fırlatır, eğer belirtilen koşula uygun birden çok kayıt dönerse de her zaman ilk kaydı döner

            //Konu konu = _db.Konu.FirstOrDefault(konu => konu.Id == id); // eğer belirtilen koşula uygun sonuç dönmezse null döner, eğer belirtilen koşula uygun birden çok kayıt dönerse de her zaman ilk kaydı döner

            // Last, eğer belirtilen koşula uygun sonuç dönmezse hata fırlatır, eğer belirtilen koşula uygun birden çok kayıt dönerse de her zaman son kaydı döner

            // LastOrDefault, eğer belirtilen koşula uygun sonuç dönmezse null döner, eğer belirtilen koşula uygun birden çok kayıt dönerse de her zaman son kaydı döner

            //Konu konu = _db.Konu.Single(konu => konu.Id == id); // eğer belirtilen koşula uygun sonuç dönmezse exception fırlatır, eğer belirtilen koşula uygun birden çok kayıt dönerse de exception fırlatır

            Konu konu = _db.Konu.SingleOrDefault(konu => konu.Id == id); // eğer belirtilen koşula uygun sonuç dönmezse null döner, eğer belirtilen koşula uygun birden çok kayıt dönerse de exception fırlatır

            // eğer expression olarak birden çok koşul kullanılmak isteniyorsa bu koşullar and (&&) veya or (||) ile birleştirilebilir, değil işlemi için de not (!) kullanılabilir

            return View(konu);
        }

        [HttpPost] // sunucuya bir form veya başka bir yol ile veri gönderiliyorsa mutlaka HttpPost yazılmalıdır
        public IActionResult Edit(Konu konu)
        {
            _db.Konu.Update(konu);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
