using DevHitit17Database.Models.StokModul;
using DevHitit17Database.Repositories.BaseDerived.StokKartiRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevHitit17Database.Repositories.BaseDerived.CariStokKartiRepository;
using DevHitit17Database.Repositories.BaseDerived.HastaKabulRepositories;
using DevHitit17Database.Repositories.BaseDerived.FaturaRepository;
using System.Data.Entity.Validation;

namespace DevHitit17Database
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly DatabaseEntities _context;

        public UnitOfWork(DatabaseEntities context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context was not supplied");
            }

            _context = context;

            //Hasta = new HastaRepository(_context);
            //Personel = new PersonelRepository(_context);
            //Il = new IlRepository(_context);
            //Ilce = new IlceRepository(_context);
            //KimlikTuru = new KimlikTuruRepository(_context);
            //Kurum = new KurumRepository(_context);
            //Uyruk = new UyrukRepository(_context);
            //OncelikDurumu = new OncelikDurumuRepository(_context);
            //Yonlendiren = new YonlendirenRepository(_context);
            CariKarti = new CariKartiRepository(_context);
            StokKarti = new StokKartiRepository(_context);
            VerilenHizmetler = new VerilenHizmetlerRepository(_context);
            Fatura = new FaturaRepository(_context);
        }
        public ICariKartiRepository CariKarti { get; private set; }
        public IStokKartiRepository StokKarti { get; private set; }
        public IVerilenHizmetlerRepository VerilenHizmetler { get; private set; }
        public IFaturaRepository Fatura { get; private set; }
        //public IPersonelRepository Personel { get; private set; }
        //public IIlRepository Il { get; private set; }
        //public IIlceRepository Ilce { get; private set; }
        //public IKimlikTuruRepository KimlikTuru { get; private set; }
        //public IKurumRepository Kurum { get; private set; }
        //public IUyrukRepository Uyruk { get; private set; }
        //public IOncelikDurumuRepository OncelikDurumu { get; private set; }
        //public IYonlendirenRepository Yonlendiren { get; private set; }

        //public IStokKartiRepository StokHizmet { get; private set; }

        //public ICariKartiRepository CariKarti => throw new NotImplementedException();

        //public IStokKartiRepository StokKarti => throw new NotImplementedException();

        //public override int SaveChanges()
        //{

        //}


        public int Complete()
        {
            int sonuc;
            try
            {
                sonuc= _context.SaveChanges();
            }
            catch (FieldAccessException e)
            {
                string hata = e.Message;
                //var newException = new FormattedDbEntityValidationException(e);
                //throw newException;
                sonuc = 0;
            }
            catch (DbEntityValidationException e)
            {
                string hata = e.Message;
                //var newException = new FormattedDbEntityValidationException(e);
                //throw newException;
                sonuc = 0;
            }
            catch (DataMisalignedException e)
            {
                string hata = e.Message;
                // var newException = new FormattedDbEntityValidationException(e);
                // throw newException;
                sonuc = 0;
            }
            catch (DbUnexpectedValidationException e)
            {
                string hata = e.Message;
                sonuc = 0;
                //var newException = new FormattedDbEntityValidationException(e);
                //throw newException;
            }
            catch (Exception e)
            {
                string hata = e.Message;
                sonuc = 0;

                throw new ArgumentNullException(e.Message);//"Context was not supplied");

                //var newException = new FormattedDbEntityValidationException(e);
                //throw newException;

                //string h = ((System.Data.Entity.Validation.DbEntityValidationException)FieldAccessException).Message.ToString();
                //((System.Data.Entity.Validation.DbEntityValidationException)$exception).EntityValidationErrors;
            }
            return sonuc;
        }

        public class FormattedDbEntityValidationException : Exception
        {
            public FormattedDbEntityValidationException(DbEntityValidationException innerException) :
                base(null, innerException)
            {
            }

            public override string Message
            {
                get
                {
                    var innerException = InnerException as DbEntityValidationException;
                    if (innerException != null)
                    {
                        StringBuilder sb = new StringBuilder();

                        sb.AppendLine();
                        sb.AppendLine();
                        foreach (var eve in innerException.EntityValidationErrors)
                        {
                            sb.AppendLine(string.Format("- Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().FullName, eve.Entry.State));
                            foreach (var ve in eve.ValidationErrors)
                            {
                                sb.AppendLine(string.Format("-- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                    ve.PropertyName,
                                    eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                    ve.ErrorMessage));
                            }
                        }
                        sb.AppendLine();

                        return sb.ToString();
                    }

                    return base.Message;
                }
            }
        }
        //public int Update(StokKarti barkodbul)
        //{

        //    _context.Entry(barkodbul).State = System.Data.Entity.EntityState.Modified;
        //    _context.StokKartlari.Attach(barkodbul);
        //    return _context.SaveChanges();
        //}

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
