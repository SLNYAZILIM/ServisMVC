using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCServis.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVCServis.DAL
{
    public class ADMINContext: DbContext
    {
        public ADMINContext() : base("ADMINContext")
        {

        }
        public DbSet<User> Userlar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // tablo ısımlerıne gelen 's' takısını eklemıyor bunu kullanmazsan 'kullanicilars'
            // olacak...
        }
    }
}