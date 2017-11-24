using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevHitit17Database.Models.FaturaModul;
using DevHitit17Database;
using System.Reflection;

namespace DevHitit17
{
    public partial class RaporGoster : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork _work;
        public RaporGoster()
        {
            InitializeComponent();
            _work = new UnitOfWork(new DatabaseEntities());
        }

        private void RaporGoster_Load(object sender, EventArgs e)
        {
            XtraReport1 xr = new XtraReport1();
            DataSet ds = new DataSet();

            var q = _work._context.Database.SqlQuery<VMFaturaKalemleri>(@"select vh.VerilenHizmetlerId,vh.HastaKabulId,
            vh.HizmetId,sk.Stokadi,vh.Tarih,vh.Fiyati,vh.Adet,vh.Fiyati*vh.Adet as Tutar from VerilenHizmetler vh
            left join StokKarti sk on sk.pkStokKarti=vh.hizmetid");

            DataTable dt = ToDataTable<VMFaturaKalemleri>(q);
            ds.Tables.Add(dt);
            dt.TableName = "FaturaKalemleri";
            xr.DataSource = ds;

            xr.LoadLayout(@"D:\adem\DevHitit17\DevHitit17\Raporlar\Fatura.repx");
            reportDesigner1.OpenReport(xr);
        }

        private DataTable ToDataTable<T>(IEnumerable<T> source)
        {
            var table = new DataTable();

            int i = 0;
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props)
            {
                table.Columns.Add(new DataColumn(prop.Name, prop.PropertyType));
                ++i;
            }

            foreach (var item in source)
            {
                var values = new object[i];
                i = 0;
                foreach (var prop in props)
                    values[i++] = prop.GetValue(item);
                table.Rows.Add(values);
            }

            return table;
        }
    }
}