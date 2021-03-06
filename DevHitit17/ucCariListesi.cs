﻿using System;
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
using System.Reflection;
using System.Linq.Expressions;
using DevHitit17Database.Repositories.BaseDerived.CariStokKartiRepository;
using DevHitit17Database.Models.CariModul;

namespace DevHitit17
{
    public partial class ucCariListesi : uBaseUC
    {
        CariKartiRepository cariKartiRepository;
        public ucCariListesi()
        {
            InitializeComponent();

            cariKartiRepository = new  CariKartiRepository(_work._context);
        }

        private void Cariler()
        {
            //bool apiden_verigetir = false;
            DataTable dt;
            //if (apiden_verigetir)
            //{
            //    StokController api = new StokController();
            //    IEnumerable<StokKarti> sl = api.Get();

            //    dt = ToDataTable<StokKarti>(sl);
            //}
            //else
            {
                var carilistesi = _work.CariKarti.GetAll().ToList();
                 dt = ToDataTable<Firmalar>(carilistesi);
            }
            gridControl1.DataSource = dt;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            StokDuzenle();

            //barkod  var mı?
            //StokKarti barkodbul = stokKartiRepository.StokKartiBulBarkod(txtBarkod.Text);
            //if (barkodbul == null)
            //{
            //    StokKarti stokKarti = new StokKarti();
            //    //stokKarti.pkStokKarti = 5;
            //    stokKarti.id = 6;
            //    stokKarti.Stokadi = txtStokAdi.Text;
            //    stokKarti.barkod = txtBarkod.Text;

            //    _work.StokKarti.Add(stokKarti);
            //    _work.Complete();

            //    //string yeni_id = stokKarti.id.ToString();
            //    string yeni_id2 = stokKarti.pkStokKarti.ToString();
            //}
            //else
            //{
            //    //barkodbul.id = 1;
            //    ///barkodbul.pkStokKarti = 1;
            //    barkodbul.Stokadi = txtStokAdi.Text;
            //    //_work.StokKarti.Add(barkodbul);
            //    //_work._context.Entry(barkodbul).State = System.Data.Entity.EntityState.Modified;
            //    _work._context.StokKartlari.Attach(barkodbul);
            //    int sonuc = _work.Complete();
            //    //_work.Update(barkodbul);
            //}

            Cariler();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Hide();
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

        void StokDuzenle()
        {
            int i = gridView1.FocusedRowHandle;
            if (i < 0) return;

            DataRow dr = gridView1.GetDataRow(i);
            int id = int.Parse(dr["pkFirma"].ToString());

            fCariKarti stokKarti = new fCariKarti(id);
            stokKarti.ShowDialog();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            StokDuzenle();
            //if (gridView1.FocusedRowHandle < 0) return;

            //DataRow dr =
            //gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //string id = dr["pkStokKarti"].ToString();
            //string barkod = dr["barkod"].ToString();
            //string stokadi = dr["stokadi"].ToString();

            //txtBarkod.Text = barkod;
            //txtStokAdi.Text = stokadi;
        }

        private void ucStokListesi_Load(object sender, EventArgs e)
        {
            Cariler();
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            fCariKarti stokKarti = new fCariKarti(0);
            stokKarti.ShowDialog();

            Cariler();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var carilistesiara = _work.CariKarti.Find(p => p.Firmaadi.Contains(textEdit1.Text)).Take(20);

            DataTable dt = ToDataTable<Firmalar>(carilistesiara);

            gridControl1.DataSource = dt;
        }

        private void stokKArtıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StokDuzenle();
        }

        private void stokHareketleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = gridView1.FocusedRowHandle;
            if (i < 0) return;

            DataRow dr = gridView1.GetDataRow(i);
            int id = int.Parse(dr["pkFirma"].ToString());

            fStokKarti stokKarti = new fStokKarti(id);
            stokKarti.ShowDialog();
        }

        private void cariKartıToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
