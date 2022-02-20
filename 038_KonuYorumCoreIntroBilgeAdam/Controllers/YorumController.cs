using _038_KonuYorumCoreIntroBilgeAdam.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _038_KonuYorumCoreIntroBilgeAdam.Controllers
{
    public class YorumController : Controller
    {
        private BA_KonuYorumCoreContext _db = new BA_KonuYorumCoreContext();

        public IActionResult Index()
        {
            // select * from Yorum order by Puan desc
            //List<Yorum> yorumlar = _db.Yorum.OrderByDescending(yorum => yorum.Puan).ToList(); // OrderBy, OrderByDescending
            // Bu şekilde ilişkili Konu kayıtları boş gelir.

            // select * from Yorum inner join Konu on Yorum.KonuId = Konu.Id order by Puan desc, Yorumcu
            List<Yorum> yorumlar = _db.Yorum.Include(yorum => yorum.Konu).OrderByDescending(yorum => yorum.Puan).ThenBy(yorum => yorum.Yorumcu).ToList(); // ThenBy, ThenByDescending

            // Bir OrderBy kullanıldıktan sonra diğerlerinin hepsi ThenBy olmalıdır.

            return View(yorumlar);
        }

        public IActionResult Details(int id)
        {
            Yorum yorum = _db.Yorum.Include(yorum => yorum.Konu).SingleOrDefault(yorum => yorum.Id == id);
            return View(yorum);
        }
    }
}
