using DevHitit17Database;
using DevHitit17Database.Models.CariModul;
using DevHitit17Database.Models.StokModul;
using DevHitit17Database.Repositories.BaseDerived.StokKartiRepositories;
using HititWebApi.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace DevHitit17
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public Form1()
        {
            InitializeComponent();
        }
        //static HttpClient client = new HttpClient();
        private void Form1_Load(object sender, EventArgs e)
        {
            //StokController api = new StokController();
            //IEnumerable<StokKarti> sl=   api.Get();

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:55268/");
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            //barButtonItem1_ItemClick(sender, null);
            barButtonItem1.PerformClick();
        }
        ucStokListesi _StokListesi;
        private ucStokListesi StokListesi
        {
            get
            {
                if(_StokListesi == null)
                    _StokListesi = new ucStokListesi();
                return _StokListesi;
            }
            set
            {
                _StokListesi = value;
            }
        }

        ucCariListesi _CariListesi;
        private ucCariListesi CariListesi
        {
            get
            {
                if (_CariListesi == null)
                    _CariListesi = new ucCariListesi();
                return _CariListesi;
            }
            set
            {
                _CariListesi = value;
            }
        }


        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Panel.Controls.Add(StokListesi);
            StokListesi.Dock = System.Windows.Forms.DockStyle.Fill;//DevExpress.Utils.
            StokListesi.Show();
            StokListesi.BringToFront();
            StokListesi.VisibleChanged += UcstokListesi_VisibleChanged;
        }

        private void UcstokListesi_VisibleChanged(object sender, EventArgs e)
        {
            StokListesi = null;
            //throw new NotImplementedException();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {


        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }
        ucTopluFatura _ucTopluFatura;
        public ucTopluFatura UcTopluFatura
        {
        get
        {
            if(_ucTopluFatura==null)
                _ucTopluFatura = new ucTopluFatura();

            return _ucTopluFatura;
        }
            set
            {
                _ucTopluFatura = value;
            }
    }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Panel.Controls.Add(UcTopluFatura);
            UcTopluFatura.BringToFront();
            UcTopluFatura.Dock = System.Windows.Forms.DockStyle.Fill;//DevExpress.Utils.
            UcTopluFatura.Show();
            UcTopluFatura.VisibleChanged += UcTopluFatura_VisibleChanged;
        }

        private void UcTopluFatura_VisibleChanged(object sender, EventArgs e)
        {
            this.UcTopluFatura = null;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RaporGoster raporGoster = new RaporGoster();
            raporGoster.ShowDialog();
        }

        private void barBICariListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Panel.Controls.Add(CariListesi);
            CariListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            CariListesi.Show();
            CariListesi.BringToFront();
            CariListesi.VisibleChanged += CariListesi_VisibleChanged;
        }

        private void CariListesi_VisibleChanged(object sender, EventArgs e)
        {
            CariListesi = null;
            //throw new NotImplementedException();
        }
    }
}
