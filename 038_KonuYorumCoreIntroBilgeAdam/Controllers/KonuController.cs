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
    }
}
