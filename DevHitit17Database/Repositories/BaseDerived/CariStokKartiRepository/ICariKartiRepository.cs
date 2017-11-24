using DevHitit17Database.Models.CariModul;
using DevHitit17Database.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHitit17Database.Repositories.BaseDerived.CariStokKartiRepository
{
    public interface ICariKartiRepository: IRepository<CariKarti>
    {
        Task<CariKarti> CariKartiBulKimlikNoAsync(string kimlikNo);
        Task<CariKarti> CariKartiBulKimlikPinNoAsync(string kimlikPinNo);
    }
}
