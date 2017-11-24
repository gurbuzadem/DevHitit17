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
using DevHitit17Database.Models.StokModul;
using DevHitit17Database.Repositories.BaseDerived.StokKartiRepositories;
using DevHitit17Database;

namespace DevHitit17
{
    public partial class fCariKarti : fBaseForm
    {
        StokKartiRepository stokKartiRepository;
        int _cari_id;
        public fCariKarti(int cari_id)
        {
            InitializeComponent();
            _cari_id = cari_id;
            stokKartiRepository = new StokKartiRepository(_work._context);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtOzelKod.Text == "0") return;

            StokKarti barkodbul = stokKartiRepository.StokKartiBulBarkod(txtOzelKod.Text);
            if (barkodbul == null)
            {
                StokKarti stokKarti = new StokKarti();
                stokKarti.Stokadi = txtCariAdi.Text;
                stokKarti.Barcode = txtOzelKod.Text;

                _work.StokKarti.Add(stokKarti);
                _work.Complete();

                string yeni_id2 = stokKarti.pkStokKarti.ToString();
            }
            else
                MessageBox.Show("Stok Zaten Var");

        }

        private void fStokKarti_Load(object sender, EventArgs e)
        {
            //var stoklistesiara = _work.StokKarti.Find(p => p.Stokadi.Contains(textEdit1.Text));
            //DataTable dt = ToDataTable<StokKarti>(stoklistesiara);

            
            StokKarti stokkartiData = _work.StokKarti.FindOne(s => s.pkStokKarti== _cari_id);
            if (stokkartiData == null)
            {
                ; MessageBox.Show("Stok Bulunamadı");
            }
            else
            {
                txtCariAdi.Text = stokkartiData.Stokadi;
                txtOzelKod.Text = stokkartiData.Barcode;
            }
        }
    }
}