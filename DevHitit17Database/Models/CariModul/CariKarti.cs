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
    [Table("CariKarti")]
    public class CariKarti
    {
        [Key]
        public int id { get; set; }
        public int pkCariKarti { get; set; }
        public string CariAdi { get; set; }
        public string KimlikNo { get; set; }
    }
}
