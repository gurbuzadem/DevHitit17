using DevHitit17Database.Models.CariModul;
using DevHitit17Database.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHitit17Database.Repositories.BaseDerived.CariStokKartiRepository
{
    public class CariKartiRepository: Repository<CariKarti>, ICariKartiRepository
    {
        public CariKartiRepository(DatabaseEntities context) : base(context)
        {
        }

        public async Task<CariKarti> CariKartiBulKimlikNoAsync(string CariAdi)
        {
            return await FindOneAsync(h => h.CariAdi == CariAdi);
        }

        public async Task<CariKarti> CariKartiBulKimlikPinNoAsync(string CariAdi)
        {
            return await FindOneAsync(h => h.CariAdi == CariAdi);
        }
    }
}
