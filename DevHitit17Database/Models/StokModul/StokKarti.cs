using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace DevHitit17Database.Models.StokModul
{
    [Table("StokKarti")]
    public class StokKarti
    {
        public StokKarti()
        {

        }
        //[Key]
        public int id { get; set; }
        [Key]
        public int pkStokKarti { get; set; }

        [Display(Name = "Ad")]
        public string Stokadi { get; set; }
        public string barkod { get; set; }
        public int KdvOrani { get; set; }

        public string Aciklama { get; set; }
    }
}
