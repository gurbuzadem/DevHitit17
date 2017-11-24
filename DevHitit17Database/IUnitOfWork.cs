using DevHitit17Database.Repositories.BaseDerived.CariStokKartiRepository;
using DevHitit17Database.Repositories.BaseDerived.StokKartiRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHitit17Database
{
    public interface IUnitOfWork : IDisposable
    {
        ICariKartiRepository CariKarti { get; }
        //IPersonelRepository Personel { get; }
        //IIlRepository Il { get; }
        //IIlceRepository Ilce { get; }
        //IKimlikTuruRepository KimlikTuru { get; }
        //IKurumRepository Kurum { get; }
        //IUyrukRepository Uyruk { get; }
        //IOncelikDurumuRepository OncelikDurumu { get; }
        //IYonlendirenRepository Yonlendiren { get; }
        IStokKartiRepository StokKarti { get; }

        int Complete();
        Task<int> CompleteAsync();
    }
}
