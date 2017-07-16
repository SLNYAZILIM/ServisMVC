using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCServis.Models
{

    public class User
    {
        public int ID { get; set; }
        public string email { get; set; }
        public string adi { get; set; }
        public string soyadi { get; set; }
        public string sifre { get; set; }
        public string gsm { get; set; }
        public string tel1 { get; set; }
        public string tel2 { get; set; }
        public string adres { get; set; }
        public bool onay { get; set; }
    }
}