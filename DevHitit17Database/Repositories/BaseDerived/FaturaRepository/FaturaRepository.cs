using DevHitit17Database.Models.FaturaModul;
using DevHitit17Database.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHitit17Database.Repositories.BaseDerived.FaturaRepository
{
    public class FaturaRepository : Repository<Fatura>, IFaturaRepository
    {
        public FaturaRepository(DatabaseEntities context) : base(context)
        {

        }
        public Fatura FaturaBul(int FaturaId)
        {
            return FindOne(s => s.FaturaId == FaturaId);
        }

        public async Task<Fatura> FaturaBulAsync(int FaturaId)
        {
            return await FindOneAsync(s => s.FaturaId == FaturaId);
        }

        Task<Fatura> IFaturaRepository.FaturaBul(int FaturaId)
        {
            throw new NotImplementedException();
        }

        //public async Task<Fatura> FaturaBulAsync(int FaturaId)
        //{
        //    return await FindOneAsync(s => s.FaturaId == FaturaId);
        //}
    }
}
