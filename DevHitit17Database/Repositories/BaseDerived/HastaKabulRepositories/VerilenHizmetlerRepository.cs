using DevHitit17Database.Models.HastaKabul;
using DevHitit17Database.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHitit17Database.Repositories.BaseDerived.HastaKabulRepositories
{

    public class VerilenHizmetlerRepository : Repository<VerilenHizmetler>, IVerilenHizmetlerRepository
    {
        public VerilenHizmetlerRepository(DatabaseEntities context) : base(context)
        {

        }
        public VerilenHizmetler StokKartiBulBarkod(int HastaKabulId)
        {
            return FindOne(s => s.HastaKabulId == HastaKabulId);
        }

        public async Task<VerilenHizmetler> StokKartiBulBarkodAsync(int HastaKabulId)
        {
            return await FindOneAsync(s => s.HastaKabulId == HastaKabulId);
        }

        public async Task<VerilenHizmetler> StokKartiBulKoduAsync(int HastaKabulId)
        {
            return await FindOneAsync(s => s.HastaKabulId == HastaKabulId);
        }
    }
}
