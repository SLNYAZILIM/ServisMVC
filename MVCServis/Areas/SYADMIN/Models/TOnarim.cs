using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCServis.Areas.SYADMIN.Models
{
    public class TOnarim
    {
        public int ID { get; set; }
        [StringLength(20)]
        public string OnarimKodu { get; set; }
        [StringLength(100)]
        public string OnarimAdi { get; set; }
        public virtual ICollection<TeknikServisGiris> TSGirisler { get; set; }
    }
}