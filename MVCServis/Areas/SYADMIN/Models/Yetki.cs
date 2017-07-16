using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCServis.Areas.SYADMIN.Models
{
    public class Yetki
    {
        public int ID { get; set; }
        public string yetkiadi { get; set; }
        public virtual ICollection<Kullanicilar> kullanicilar { get; set; }

    }
}