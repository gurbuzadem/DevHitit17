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

namespace DevHitit17Database
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly DatabaseEntities _context;

        public UnitOfWork(DatabaseEntities context)
        {
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



        public int Complete()
        {
            return _context.SaveChanges();
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
