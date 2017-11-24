using DevHitit17Database.Models.CariModul;
using DevHitit17Database.Models.FaturaModul;
using DevHitit17Database.Models.HastaKabul;
using DevHitit17Database.Models.StokModul;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
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
        public static string hatamesaji;
        public override int SaveChanges()
        {
            //string hataMesaji = "";
            int sonuc;
            try
            {
                sonuc = base.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx) //DbEntityValidationException e)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        hatamesaji = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException

                        raise = new InvalidOperationException(hatamesaji, raise);
                    }
                }
                throw raise;

                //IEnumerable<DbEntityValidationResult> EntityValidationErrors = new DB;

                //if (e.EntityValidationErrors<StokKarti> 0)
                //{

                //}
                //var newException = new FormattedDbEntityValidationException(e);
                //throw newException;

                //hatamesaji = e.Message;
                //(new System.Collections.Generic.Mscorlib_CollectionDebugView<System.Data.Entity.Validation.DbValidationError>((new System.Collections.Generic.Mscorlib_CollectionDebugView<System.Data.Entity.Validation.DbEntityValidationResult>
                //(e.EntityValidationErrors).Items[0]).ValidationErrors).Items[0]).ErrorMessage
                sonuc = 0;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
            {
                //Exception raise ;
                sonuc = 0;
                throw  new InvalidOperationException(ex.InnerException.Message,ex.InnerException);
                //Console.WriteLine();
                //throw raise;
            }
            catch (System.Data.Entity.Core.EntityCommandCompilationException ex)
            {
                sonuc = 0;
                throw new InvalidOperationException(ex.InnerException.Message, ex.InnerException);
                //Console.WriteLine(ex.InnerException);
            }
            catch (System.Data.Entity.Core.UpdateException ex)
            {
                sonuc = 0;
                throw new InvalidOperationException(ex.InnerException.Message, ex.InnerException);
                //Console.WriteLine(ex.InnerException);
            }

            catch (System.Data.Entity.Infrastructure.DbUpdateException ex) //DbContext
            {
                sonuc = 0;
                throw new InvalidOperationException(ex.InnerException.Message, ex.InnerException);
                //Console.WriteLine(ex.InnerException);
            }

            catch (Exception ex)
            {
                sonuc = 0;
                throw new InvalidOperationException(ex.InnerException.Message, ex.InnerException);
                //Console.WriteLine(ex.InnerException);
            }
            return sonuc;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Code First to ignore PluralizingTableName convention 
            // If you keep this convention then the generated tables will have pluralized names. 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    //public class FormattedDbEntityValidationException : Exception
    //{
    //    public FormattedDbEntityValidationException(DbEntityValidationException innerException) :
    //        base(null, innerException)
    //    {
    //    }

    //    //public override string Message
    //    //{
    //    //    get
    //    //    {
    //    //        var innerException = InnerException as DbEntityValidationException;
    //    //        if (innerException != null)
    //    //        {
    //    //            StringBuilder sb = new StringBuilder();

    //    //            sb.AppendLine();
    //    //            sb.AppendLine();
    //    //            foreach (var eve in innerException.EntityValidationErrors)
    //    //            {
    //    //                sb.AppendLine(string.Format("- Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
    //    //                    eve.Entry.Entity.GetType().FullName, eve.Entry.State));
    //    //                foreach (var ve in eve.ValidationErrors)
    //    //                {
    //    //                    sb.AppendLine(string.Format("-- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
    //    //                        ve.PropertyName,
    //    //                        eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
    //    //                        ve.ErrorMessage));
    //    //                }
    //    //            }
    //    //            sb.AppendLine();

    //    //            return sb.ToString();
    //    //        }

    //    //        return base.Message;
    //    //    }
    //    //}
    //}
}
