using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCServis.Areas.SYADMIN.Models
{
    public class TBelirti
    {
        public int ID { get; set; }
        [StringLength(20)]
        public string BelirtiKodu { get; set; }
        [StringLength(100)]
        public string BelirtiAdi { get; set; }
        public virtual ICollection<TeknikServisGiris> TSGirisler { get; set; }
    }
}