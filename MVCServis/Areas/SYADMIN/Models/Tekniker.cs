using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCServis.Areas.SYADMIN.Models
{
    public class tekniker
    {
        public int id { get; set; }
        public int teknikerNo { get; set; }
        public string teknikerAdi { get; set; }
        public int teknikerIsYuk { get; set; }
        
    }
}