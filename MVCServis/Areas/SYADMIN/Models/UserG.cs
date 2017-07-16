using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCServis.Areas.SYADMIN.Models
{
    public class UserG
    {
        public int ID { get; set; }
        [Display(Name ="Email Adresi:")]
        [Required(ErrorMessage ="Email adresi zorunludur.")]
        [EmailAddress(ErrorMessage ="Geçersi mail adresi.")]
        [StringLength(50)]
        public string email { get; set; }
        [Display(Name = "Adı-Soyadı:")]
        [Required(ErrorMessage = "Ad soyad girilmesi zorunludur.")]
        [StringLength(100)]
        public string adi { get; set; }
        [Display(Name = "Şifre :")]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public string sifre { get; set; }
        [Display(Name = "Gsm No :")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]               
        public string gsm { get; set; }
        [Display(Name = "İş Telefonu :")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string telis { get; set; }
        [Display(Name = "Ev Telefonu :")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string telev { get; set; }
        [Display(Name = "Adres :")]
        [DataType(DataType.MultilineText)]
        public string adres { get; set; }
        public bool onay { get; set; }
        public string ipadres { get; set; }
        public int yetki { get; set; }
        public DateTime uyelikTarih { get; set; }
        public DateTime girisTarih { get; set; }
        public int girissayisi { get; set; }
        [Display(Name = "Beni Hatırla :")]
        public bool hatirla { get; set; }
        [Display(Name = "Fotoğraf Ekle :")]
        [StringLength(200)]
        public string foto { get; set; }
    }
}