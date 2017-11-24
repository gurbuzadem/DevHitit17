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
using DevHitit17Database.Repositories.BaseDerived.StokKartiRepositories;

namespace DevHitit17
{
    public partial class fPersonelKarti : fBaseForm
    {
        StokKartiRepository stokKartiRepository;
        public fPersonelKarti()
        {
            InitializeComponent();
            stokKartiRepository = new StokKartiRepository(_work._context); //new DatabaseEntities());
        }

        private void fPersonelKarti_Load(object sender, EventArgs e)
        {
            //StokKarti barkodbul = stokKartiRepository.StokKartiBulBarkod(txtBarkod.Text);
        }
    }
}