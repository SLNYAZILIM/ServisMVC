using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCServis.Areas.SYADMIN.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVCServis.Areas.SYADMIN.DAL
{
    public class SYADMINContext : DbContext
    {
        public SYADMINContext() : base("SYADMINContext")
        {

        }
        public DbSet<Kullanicilar> Kullanicilar { get; set; }
        public DbSet<Bolum> Bolumler { get; set; }
        public DbSet<Yetki> Yetkiler { get; set; }
        public DbSet<tekniker> Teknikerler { get; set; }
        public DbSet<BankoGiris> BankoGirisler { get; set; }
        public DbSet<MusteriTip> MusteriTipler { get; set; }
        public DbSet<Garanti> Garantiler { get; set; }

        public DbSet<TOnarim> Onarimlar { get; set; }
        public DbSet<TUrun> Urunler { get; set; }
        public DbSet<TAriza> Arizalar { get; set; }
        public DbSet<TBelirti> Belirtiler { get; set; }
        public DbSet<TDurum> Durumlar { get; set; }
        public DbSet<TeknikServisGiris> TServisler { get; set; }
        public DbSet<UserG> Userlar { get; set; }
        public DbSet<UserYorum> UserYorumlar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
                    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // tablo ısımlerıne gelen 's' takısını eklemıyor bunu kullanmazsan 'kullanicilars'
            // olacak...
        }
    }
}