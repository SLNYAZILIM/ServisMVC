using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCServis.Areas.SYADMIN.Models
{
    public class Bolum
    {
        public int ID { get; set; }
        public string BolumAdi { get; set; }

        public virtual ICollection<Kullanicilar> kullanicilar { get; set; }
    }
}