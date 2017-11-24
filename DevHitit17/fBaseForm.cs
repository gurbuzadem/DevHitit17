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
//using DevHitit17Database.Repositories.BaseDerived.StokKartiRepositories;

namespace DevHitit17
{
    public partial class fBaseForm : DevExpress.XtraEditors.XtraForm
    {
        public UnitOfWork _work;
        //StokKartiRepository stokKartiRepository;
        public fBaseForm()
        {
            InitializeComponent();
            _work = new UnitOfWork(new DatabaseEntities());
            //stokKartiRepository = new StokKartiRepository(_work._context);
        }
    }
}