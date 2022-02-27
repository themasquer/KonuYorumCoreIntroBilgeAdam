using _038_KonuYorumCoreIntroBilgeAdam.DataAccess;
using _038_KonuYorumCoreIntroBilgeAdam.Models;
using Microsoft.AspNetCore.Mvc;

namespace _038_KonuYorumCoreIntroBilgeAdam.Controllers
{
    public class KonularYorumlarJoinController : Controller
    {
        private BA_KonuYorumCoreContext _db = new BA_KonuYorumCoreContext();

        /*
        select k.Baslik, k.Aciklama, y.Icerik, y.Yorumcu, y.Puan 
        from Konu k inner join Yorum y
        on k.Id = y.KonuId
        */
        public IActionResult Index()
        {
            IQueryable<Konu> konuQuery = _db.Konu.AsQueryable(); // select * from Konu
            IQueryable<Yorum> yorumQuery = _db.Yorum.AsQueryable(); // select * from Yorum
            var joinQuery = from kq in konuQuery
                            join yq in yorumQuery
                            on kq.Id equals yq.KonuId
                            select new KonuYorumInnerJoinModel()
                            {
                                Baslik = kq.Baslik,
                                Aciklama = kq.Aciklama,
                                Icerik = yq.Icerik,
                                Yorumcu = yq.Yorumcu,
                                Puan = yq.Puan
                            };
            var model = joinQuery.ToList();
            return View(model);
        }
    }
}
