using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHitit17Database.Models.FaturaModul
{
    public class Fatura
    {
        public Fatura()
        {

        }

        public int Id { get; protected set; }
        [Key]
        public int FaturaId { get; set; }
        [DisplayName("Fatura No")]
        public string FaturaNo { get; set; }
        [DisplayName("Fatura Tarihi")]
        public DateTime Tarih { get; set; }
        public string VergiDairesi { get; set; }
        public string VergiNo { get; set; }
        //[FieldSize(100)]
        public string FaturaUnvani { get; set; }
        ///[FieldSize(250)]
        public string FaturaAdresi { get; set; }

        public decimal FaturaTutari { get; set; }
        public decimal KdvTutari { get; set; }

        public Nullable<DateTime> IptalTarih { get; set; }
        public string IptalNedeni { get; set; }

        public Nullable<int> TopluFaturaId { get; set; }

        public Nullable<DateTime> YazdirmaTarihi { get; set; }
    }
}
