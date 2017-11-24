//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel;

namespace DevHitit17Database.Models.CariModul
{
    [Table("Firmalar")]
    public class Firmalar
    {
        //[Key]
        //public int id { get; set; }
        [Key]
        public int pkFirma { get; set; }
        [Required]
        [DisplayName("Özel Kod")]
        public string OzelKod { get; set; }
        [DisplayName("Cari Adı")]
        public string Firmaadi { get; set; }
        public string Yetkili { get; set; }
        [DisplayName("Ev Telefonu")]
        public string Tel { get; set; }
        [DisplayName("Cep Telefonu")]
        public string Cep { get; set; }
        //public FirmaGruplari fkFirmaGruplari { get; set; }
        private FirmaGruplari fkFirmaGruplari { get; set; }
    }
}
