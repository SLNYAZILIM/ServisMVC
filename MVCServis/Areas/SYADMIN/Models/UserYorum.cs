using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCServis.Areas.SYADMIN.Models
{
    public class UserYorum
    {
        public int ID { get; set; }
        public int userId { get; set; }
        [Display(Name ="Adınız :")]
        [StringLength(100)]
        public string userAdi { get; set; }
        [Display(Name = "Tarih :")]
        [Column(TypeName ="Date")]
        public DateTime tarih { get; set; }
        [Display(Name = "Yorumunuz :")]
        [StringLength(300)]
        public string yorum { get; set; }
        public string foto { get; set; }
    }
}