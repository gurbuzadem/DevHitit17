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
using DevHitit17Database;

namespace DevHitit17
{
    public partial class uBaseUC : DevExpress.XtraEditors.XtraUserControl
    {
        public UnitOfWork _work;
        public uBaseUC()
        {
            InitializeComponent();
            _work = new UnitOfWork(new DatabaseEntities());
        }
    }
}
