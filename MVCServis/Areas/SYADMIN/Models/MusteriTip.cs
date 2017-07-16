using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCServis.Areas.SYADMIN.Models
{
    public class MusteriTip
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string MusteriTipi { get; set; }
        public virtual ICollection<BankoGiris> BankoGirisler { get; set; }

    }
}