using System;
using System.Collections.Generic;

namespace _038_KonuYorumCoreIntroBilgeAdam.DataAccess
{
    public partial class Yorum
    {
        public int Id { get; set; }
        public string Icerik { get; set; }
        public DateTime Tarih { get; set; }
        public string Yorumcu { get; set; }
        public int KonuId { get; set; }

        public virtual Konu Konu { get; set; }
    }
}
