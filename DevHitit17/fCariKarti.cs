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
using DevHitit17Database;
using DevHitit17Database.Repositories.BaseDerived.CariStokKartiRepository;
using DevHitit17Database.Models.CariModul;

namespace DevHitit17
{
    public partial class fCariKarti : fBaseForm
    {
        CariKartiRepository cariKartiRepository;
        int _cari_id;
        public fCariKarti(int cari_id)
        {
            InitializeComponent();
            _cari_id = cari_id;
            cariKartiRepository = new  CariKartiRepository(_work._context);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtOzelKod.Text == "0") return;

            Firmalar barkodbul = cariKartiRepository.FirmaKartiBulBarkod(txtOzelKod.Text);
            if (barkodbul == null)
            {
                Firmalar stokKarti = new Firmalar();
                //stokKarti.OzelKod = "1001";
                stokKarti.Firmaadi = txtCariAdi.Text;
                stokKarti.Yetkili = txtOzelKod.Text;

                _work.CariKarti.Add(stokKarti);
                try
                {
                    int sonuc = _work.Complete();
                }
                catch (Exception EXP)
                {
                    //_work.hatamesaji
                    MessageBox.Show(EXP.Message);
                    //throw;
                }
               

                string yeni_id2 = stokKarti.pkFirma.ToString();
            }
            else
                MessageBox.Show("Cari Zaten Var");

        }

        private void fStokKarti_Load(object sender, EventArgs e)
        {
            //var stoklistesiara = _work.StokKarti.Find(p => p.Stokadi.Contains(textEdit1.Text));
            //DataTable dt = ToDataTable<StokKarti>(stoklistesiara);

            
            Firmalar stokkartiData = _work.CariKarti.FindOne(s => s.pkFirma== _cari_id);
            if (stokkartiData == null)
            {
                ; MessageBox.Show("Cari Kart Bulunamadı");
            }
            else
            {
                txtCariAdi.Text = stokkartiData.Firmaadi;
                txtOzelKod.Text = stokkartiData.Yetkili;
            }
        }
    }
}