using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCServis.Areas.SYADMIN.Models
{
    public class Kullanicilar
    {
        public int ID { get; set; }
        [StringLength(50)]
        public string email { get; set; }
        [StringLength(50)]
        public string kullaniciAdi { get; set; }
        [StringLength(50)]
        public string sifre { get; set; }
        public int BolumId { get; set; }
        public int YetkiId { get; set; }
        public DateTime oluşturmaTarihi { get; set; }

        public virtual Bolum Bolum { get; set; }

        public virtual Yetki yetki { get; set; }
    }
}