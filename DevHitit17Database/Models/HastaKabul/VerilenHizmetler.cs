using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHitit17Database.Models.HastaKabul
{
    [Table("VerilenHizmetler")]
    public class VerilenHizmetler
    {
        public VerilenHizmetler()
        {

        }
        //[Key]
        public int id { get;  set; }
        [Key]
        public int VerilenHizmetlerId { get; set; }
        public int HastaKabulId { get; set; }
        public int HizmetId { get; set; }
        public DateTime Tarih { get; set; }
        //public Nullable<DateTime> Tarih { get; set; }
        public int Fiyati { get; set; }
        public int Adet { get; set; }
        public int BolumId { get; set; }
        public int MuayeneId { get; set; }
        /// <summary>
        /// Fatura Kesildiyse, FaturaKalemindeki FaturaKalemiId değerini alır.
        /// </summary>
        public int FaturaKalemiId { get; set; }

        public Nullable<DateTime> IptalTarihi { get; set; }
        public Nullable<int> IptalEdenPersonelId { get; set; }
        public string IptalNedeni { get; set; }

        public Nullable<int> HizmetiVerenPersonelId { get; set; }
        public Nullable<int> EkleyenPersonelId { get; set; }
    }
}
