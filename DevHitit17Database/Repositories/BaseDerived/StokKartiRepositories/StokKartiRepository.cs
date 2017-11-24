using DevHitit17Database.Models.StokModul;
using DevHitit17Database.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHitit17Database.Repositories.BaseDerived.StokKartiRepositories
{
    public class StokKartiRepository : Repository<StokKarti>, IStokKartiRepository
    {
        public StokKartiRepository(DatabaseEntities context) : base(context)
        {

        }
        public StokKarti StokKartiBulBarkod(string Barkod)
        {
            return  FindOne(s => s.barkod == Barkod);
        }

        public async Task<StokKarti> StokKartiBulBarkodAsync(string Barkod)
        {
            return await FindOneAsync(s => s.barkod == Barkod);
        }

        public async Task<StokKarti> StokKartiBulKoduAsync(string Kodu)
        {
            return await FindOneAsync(s => s.barkod == Kodu);
        }
    }
}
