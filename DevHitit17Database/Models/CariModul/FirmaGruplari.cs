using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHitit17Database.Models.CariModul
{
    public class FirmaGruplari
    {
        [Key]
        public int pkFirmaGruplari { get; set; }
        public int GrupAdi { get; set; }
    }
}
