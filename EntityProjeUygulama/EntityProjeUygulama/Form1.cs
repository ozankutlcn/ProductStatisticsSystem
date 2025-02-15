using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EntityProjeUygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void btnListele_Click(object sender, EventArgs e)
        {
            var kategoriler = db.Tbl_Kategori.ToList();

            dgwCategory.DataSource = kategoriler;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var kategoriler = db.Tbl_Kategori.ToList();

            dgwCategory.DataSource = kategoriler;

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            var yeniKategori = new Tbl_Kategori
            {
                Ad = txtKategoriAdi.Text
            };

            db.Tbl_Kategori.Add(yeniKategori);
            db.SaveChanges();

            MessageBox.Show("Kategori Eklendi");

            dgwCategory.DataSource = db.Tbl_Kategori.ToList();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var silinecekKategori = db.Tbl_Kategori.Find(int.Parse(txtKategoriID.Text));

            db.Tbl_Kategori.Remove(silinecekKategori);

            db.SaveChanges();

            MessageBox.Show("Kategori Silindi");

            dgwCategory.DataSource = db.Tbl_Kategori.ToList();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var guncellenecekKategori = db.Tbl_Kategori.Find(int.Parse(txtKategoriID.Text));

            guncellenecekKategori.Ad = txtKategoriAdi.Text;

            db.SaveChanges();

            MessageBox.Show("Kategori Güncellendi");

            dgwCategory.DataSource = db.Tbl_Kategori.ToList();
        }
    }
}
