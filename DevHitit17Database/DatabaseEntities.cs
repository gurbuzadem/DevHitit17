using DevHitit17Database.Models.CariModul;
using DevHitit17Database.Models.FaturaModul;
using DevHitit17Database.Models.HastaKabul;
using DevHitit17Database.Models.StokModul;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHitit17Database
{
    public class DatabaseEntities : DbContext
    {
        public DbSet<Firmalar> Cariler { get; set; }
        //public DbSet<Personeller> Personeller { get; set; }
        //public DbSet<Kurum> Kurumlar { get; set; }
        //public DbSet<Yonlendiren> Yonlendirenler { get; set; }
        //public DbSet<Uyruk> Uyruklar { get; set; }
        public DbSet<StokKarti> StokKartlari { get; set; }
        public DbSet<VerilenHizmetler> VerilenHizmetler { get; set; }
        public DbSet<Fatura> Fatura { get; set; }


        public DatabaseEntities()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Code First to ignore PluralizingTableName convention 
            // If you keep this convention then the generated tables will have pluralized names. 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
