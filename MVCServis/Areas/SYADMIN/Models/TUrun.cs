using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCServis.Areas.SYADMIN.Models
{
    public class TUrun
    {
        public int ID { get; set; }
        [StringLength(20)]
        public string UrunKodu { get; set; }
        [StringLength(100)]
        public string UrunAdi { get; set; }
        public virtual ICollection<BankoGiris> Bgirisler { get; set; }
    }
}