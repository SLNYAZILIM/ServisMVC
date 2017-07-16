using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCServis.Areas.SYADMIN.Models
{
    public class Garanti
    {
        public int ID { get; set; }
        public string GarantiAdi { get; set; }

        public virtual ICollection<BankoGiris>bankoGirisler { get; set; }
    }
}