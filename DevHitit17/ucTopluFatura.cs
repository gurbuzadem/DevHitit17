using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevHitit17Database.Repositories.BaseDerived.HastaKabulRepositories;
using DevHitit17Database;
using DevHitit17Database.Models.HastaKabul;
using System.Reflection;
using DevHitit17Database.Models.FaturaModul;
using DevHitit17Database.Repositories.BaseDerived.FaturaRepository;

namespace DevHitit17
{
    public partial class ucTopluFatura : DevExpress.XtraEditors.XtraUserControl
    {
        private UnitOfWork _work;
        //VerilenHizmetlerRepository verilenHizmetlerRepository;
        FaturaRepository faturaRepository;

        public ucTopluFatura()
        {
            InitializeComponent();

            _work = new UnitOfWork(new DatabaseEntities());
            faturaRepository = new FaturaRepository(_work._context);
            //verilenHizmetlerRepository = new VerilenHizmetlerRepository(_work._context);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            XtraReport1 xr = new XtraReport1();
            var q = _work._context.Database.SqlQuery<VMFaturaKalemleri>(@"select * from VerilenHizmetler vh
                                                    left join StokKarti sk on sk.pkStokKarti = vh.hizmetid");
            xr.DataSource = q.ToList();//gridControl2.DataSource;

            xr.LoadLayout(@"D:\adem\DevHitit17\DevHitit17\Raporlar\Fatura.repx");
            documentViewer1.DocumentSource = xr;
            xr.CreateDocument(false);
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            RaporGoster raporGoster = new RaporGoster();
            raporGoster.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            deFaturaTarihi.DateTime = DateTime.Today;

            VerilenHizmetlerGetir();
        }

        private void VerilenHizmetlerGetir()
        {
            // var verilenHizmetler = _work.VerilenHizmetler.GetAll().ToList();

            //var verilenHizmet = _work._context.VerilenHizmetler.AsQueryable();
            //var hizmet = _work._context.StokKartlari.AsQueryable();

            //var my = from vh in verilenHizmet
            //         join h in hizmet on vh.HizmetId equals h.pkStokKarti
            //         select new
            //         {
            //             vh.VerilenHizmetlerId,
            //             vh.HastaKabulId,
            //             vh.HizmetId,
            //             h.Stokadi,
            //             vh.Fiyati,
            //             vh.Adet,
            //         };

            var my = _work._context.VerilenHizmetler.Join(_work._context.StokKartlari, vhs => vhs.HizmetId,
                sk => sk.pkStokKarti, (verilenhiz, stokkart) => new
                {
                    VerilenHizmetlerId= verilenhiz.VerilenHizmetlerId,
                    HastaKabulId = verilenhiz.HastaKabulId,
                    Stokadi= stokkart.Stokadi,
                    KdvOrani = stokkart.KdvOrani,
                    Adet = verilenhiz.Adet,
                    Fiyati = verilenhiz.Fiyati,
                    Tutar = (verilenhiz.Fiyati * verilenhiz.Adet),
                });

            //DataTable dt = ToDataTable<VerilenHizmetler>(my);

            //var q = _work._context.Database.SqlQuery<VMFaturaKalemleri>(@"select * from VerilenHizmetler vh
            //                                        left join StokKarti sk on sk.pkStokKarti = vh.hizmetid");

            gridControl2.DataSource = my.ToList();
            
            //q.ToList();//new BindingList<VerilenHizmetler>();
                                                 //<VerilenHizmetler>(my.ToList); //dt;
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //fatura  var mı?
            Fatura Faturabul = faturaRepository.FaturaBul(int.Parse(Fatur_Id.Text));
            if (Faturabul == null)
            {
                Fatura fatura = new Fatura();
                //stokKarti.pkStokKarti = 5;
                fatura.FaturaId = 6;
                fatura.FaturaNo = txtFaturaNo.Text;
                fatura.Tarih = deFaturaTarihi.DateTime;

                _work.Fatura.Add(fatura);
                int sonuc = _work.Complete();

                //string yeni_id = stokKarti.id.ToString();
                string yeni_id2 = fatura.FaturaId.ToString();
            }
            else
            {
                //barkodbul.id = 1;
                //barkodbul.pkStokKarti = 1;
                Faturabul.FaturaNo = txtFaturaNo.Text;
                //_work.StokKarti.Add(barkodbul);
                //_work._context.Entry(Faturabul).State = System.Data.Entity.EntityState.Modified;
                _work._context.Fatura.Attach(Faturabul);
                int sonuc = _work.Complete();
                //_work.Update(Faturabul);
            }

            //Stoklar();
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            Fatura Faturabul = faturaRepository.FaturaBul(int.Parse(Fatur_Id.Text));
            if (Faturabul == null)
            {
                MessageBox.Show("Fatura Bulunamadı");
            }
            else
            {
                txtFaturaNo.Text = Faturabul.FaturaNo;
                txtFaturaUnvani.Text = Faturabul.FaturaUnvani;
                txtFaturaAdresi.Text = Faturabul.FaturaAdresi;
            }
        }
    }
}
