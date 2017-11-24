//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace DevHitit17Database.Models.CariModul
{
    [Table("Firmalar")]
    public class Firmalar
    {
        [Key]
        //public int id { get; set; }
        public int pkFirma { get; set; }
        public string Firmaadi { get; set; }
        public string Yetkili { get; set; }
        //public FirmaGruplari fkFirmaGruplari { get; set; }
    }
}
