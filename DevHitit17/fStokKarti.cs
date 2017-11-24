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
    public partial class fStokKarti : fBaseForm
    {
        StokKartiRepository stokKartiRepository;
        int _stok_id;
        public fStokKarti(int stok_id)
        {
            InitializeComponent();
            _stok_id = stok_id;
            stokKartiRepository = new StokKartiRepository(_work._context);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtBarkod.Text == "0") return;

            StokKarti barkodbul = stokKartiRepository.StokKartiBulBarkod(txtBarkod.Text);
            if (barkodbul == null)
            {
                StokKarti stokKarti = new StokKarti();
                stokKarti.Stokadi = txtStokAdi.Text;
                stokKarti.barkod = txtBarkod.Text;

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

            
            StokKarti stokkartiData = _work.StokKarti.FindOne(s => s.pkStokKarti==_stok_id);
            if (stokkartiData == null)
            {
                ; MessageBox.Show("Stok Bulunamadı");
            }
            else
            {
                txtStokAdi.Text = stokkartiData.Stokadi;
                txtBarkod.Text = stokkartiData.barkod;
            }
        }
    }
}