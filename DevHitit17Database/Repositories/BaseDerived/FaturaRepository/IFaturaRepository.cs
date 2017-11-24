using DevHitit17Database.Models.FaturaModul;
using DevHitit17Database.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHitit17Database.Repositories.BaseDerived.FaturaRepository
{
    public interface IFaturaRepository : IRepository<Fatura>
    {
        Task<Fatura> FaturaBul(int FaturaId);
        Task<Fatura> FaturaBulAsync(int FaturaId);
    }
}
