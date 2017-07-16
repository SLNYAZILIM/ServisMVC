using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCServis.Areas.SYADMIN.Models
{
    public class TAriza
    {
        public int ID { get; set; }
        [StringLength(20)]
        public string ArizaKodu { get; set; }
        [StringLength(100)]
        public string ArizaAdi { get; set; }
        public virtual ICollection<TeknikServisGiris> TSGirisler { get; set; }

    }
}