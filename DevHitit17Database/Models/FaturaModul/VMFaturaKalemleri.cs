using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHitit17Database.Models.FaturaModul
{
    public class VMFaturaKalemleri
    {
        public int VerilenHizmetlerId { get; set; }
        public int HastaKabulId { get; set; }
        public int HizmetId { get; set; }
        public string Stokadi { get; set; }
        [DisplayName("İşlem Tarihi")]
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public int Fiyati { get; set; }
        public int iskTutar { get; set; }
        public int Tutar { get; set; }
    }
}
