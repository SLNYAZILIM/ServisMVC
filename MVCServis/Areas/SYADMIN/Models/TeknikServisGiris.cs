using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCServis.Areas.SYADMIN.Models
{
    public class TeknikServisGiris
    {
        public int ID { get; set; }
        [StringLength(20)]
        public string TakipNo { get; set; }
        [StringLength(20)]
        public string TeknisyenKodu { get; set; }
        [StringLength(50)]
        public string TeknisyenAdi { get; set; }
        [StringLength(300)]
        public string Aciklama { get; set; }
        [StringLength(300)]
        public string TAciklama { get; set; }
        [StringLength(300)]
        public string Sikayet { get; set; }
        public decimal FaturaTutarS { get; set; }
        public decimal FaturaTutarM { get; set; }
        public int DurumId { get; set; }
        public int BelirtiId { get; set; }
        public int ArizaId { get; set; }
        public int OnarimId { get; set; }
        [StringLength(50)]
        public string UrunKodu { get; set; }
        [StringLength(300)]
        public string DurumYorum { get; set; }
        [StringLength(300)]
        public string MusteriYorum { get; set; }
        [StringLength(300)]
        public string MusteriGeriDonus { get; set; }
        [StringLength(30)]
        public string SeriNo { get; set; }
        [StringLength(30)]
        public string Imei { get; set; }
        [StringLength(50)]
        public string ServisUrunTanim { get; set; }


        public virtual TDurum Durum  { get; set; }
        public virtual TAriza Ariza { get; set; }
        public virtual TBelirti Belirti { get; set; }
        public virtual TOnarim Onarim { get; set; }
        
        
    }
}