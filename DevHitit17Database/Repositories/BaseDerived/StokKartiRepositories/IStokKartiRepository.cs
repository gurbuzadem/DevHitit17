using DevHitit17Database.Models.StokModul;
using DevHitit17Database.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHitit17Database.Repositories.BaseDerived.StokKartiRepositories
{
    public interface IStokKartiRepository : IRepository<StokKarti>
    {
        Task<StokKarti> StokKartiBulKoduAsync(string Kodu);
        Task<StokKarti> StokKartiBulBarkodAsync(string Barkod);
    }
}
