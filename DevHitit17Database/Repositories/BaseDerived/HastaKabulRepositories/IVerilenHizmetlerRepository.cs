using DevHitit17Database.Models.HastaKabul;
using DevHitit17Database.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHitit17Database.Repositories.BaseDerived.HastaKabulRepositories
{
    public interface IVerilenHizmetlerRepository : IRepository<VerilenHizmetler>
    {
        Task<VerilenHizmetler> StokKartiBulKoduAsync(int  HastaKabulId);
        Task<VerilenHizmetler> StokKartiBulBarkodAsync(int HastaKabulId);
    }
}
