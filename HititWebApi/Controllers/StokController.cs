using DevHitit17Database;
using DevHitit17Database.Models.StokModul;
using DevHitit17Database.Repositories.BaseDerived.StokKartiRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HititWebApi.Controllers
{
    public class StokController : ApiController
    {
        //çalıştırmak için
        //http://localhost:12051/api/enabiz

        StokKartiRepository stokKartiRepository;
        private UnitOfWork _work;
        // GET api/<controller>
        public IEnumerable<StokKarti> Get()
        {
            //StokKarti[] stokKarti = new StokKarti[]
            //{
            //    new StokKarti(){pkStokKarti=1,Stokadi="elma",barkod="1234"},
            //    new StokKarti(){pkStokKarti=2,Stokadi="armut",barkod="12345"}

            //};

            _work = new UnitOfWork(new DatabaseEntities());
            stokKartiRepository = new StokKartiRepository(_work._context); 

            var stoklistesi = _work.StokKarti.GetAll().ToList();
            //DataTable dt = ToDataTable<StokKarti>(stoklistesi);

            return stoklistesi;//stokKarti;
        }

        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}