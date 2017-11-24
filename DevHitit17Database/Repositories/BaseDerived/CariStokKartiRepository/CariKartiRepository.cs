using DevHitit17Database.Models.CariModul;
using DevHitit17Database.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHitit17Database.Repositories.BaseDerived.CariStokKartiRepository
{
    public class CariKartiRepository: Repository<Firmalar>, ICariKartiRepository
    {
        public CariKartiRepository(DatabaseEntities context) : base(context)
        {
        }

        public async Task<Firmalar> CariKartiBulKimlikNoAsync(string CariAdi)
        {
            return await FindOneAsync(h => h.Firmaadi == CariAdi);
        }

        public async Task<Firmalar> CariKartiBulKimlikPinNoAsync(string CariAdi)
        {
            return await FindOneAsync(h => h.Firmaadi == CariAdi);
        }
    }
}
