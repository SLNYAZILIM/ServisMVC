using MVCServis.Areas.SYADMIN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCServis.Areas.SYADMIN.Models
{
    public class BankoGiris
    {
        public int id { get; set; }

        public int mtipId { get; set; }

        [StringLength(50)]
        public string musteriAdi { get; set; }
        [StringLength(20)]
        public string tcNo { get; set; }
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string telEv { get; set; }
        [StringLength(20)]
        public string telIs { get; set; }
        [StringLength(20)]
        public string GSM { get; set; }
        [StringLength(250)]
        public string adres { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "servisGirisTarih")]
        public DateTime servisGirisTarih { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "servisGirisSaat")]
        public DateTime servisGirisSaat { get; set; }
        
        [StringLength(50)]
        public string seriNo { get; set; }
        [StringLength(50)]
        public string imei { get; set; }
        [StringLength(250)]
        public string musteriSikayet { get; set; }
        [StringLength(250)]
        public string Aciklama { get; set; }
        [StringLength(20)]
        public string takipNo { get; set; }
        public int garantiId { get; set; }

        public int TurunId { get; set; }
        public string TeknikerAdi { get; set; }
        

        public virtual MusteriTip mtip { get; set; }
        public virtual Garanti grnt { get; set; }
        public virtual TUrun Turun { get; set; }

        
    }
}