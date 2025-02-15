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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {

            dgwUrunler.DataSource = (from x in db.Tbl_Urun
                                     select new
                                     {
                                         x.ID,
                                         x.UrunAd,
                                         x.Marka,
                                         x.Stok,
                                         x.Fiyat,
                                         x.Durum,
                                         x.Tbl_Kategori.Ad // Tbl_Kategori tablosundan Ad sütununu çekiyoruz.
                                     }).ToList();

        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            dgwUrunler.DataSource = (from x in db.Tbl_Urun
                                     select new
                                     {
                                         x.ID,
                                         x.UrunAd,
                                         x.Marka,
                                         x.Stok,
                                         x.Fiyat,
                                         x.Durum,
                                         x.Tbl_Kategori.Ad
                                     }).ToList();

            var kategoriler = (from x in db.Tbl_Kategori
                               select new
                               {
                                   x.ID,
                                   x.Ad
                               }).ToList();

            cmbKategori.ValueMember = "ID";
            cmbKategori.DisplayMember = "Ad";
            cmbKategori.DataSource = kategoriler;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            var urunEkle = db.Tbl_Urun.Add(new Tbl_Urun
            {
                UrunAd = txtUrunAdi.Text,
                Marka = txtMarka.Text,
                Stok = short.Parse(txtStokSayısı.Text),
                Kategori = int.Parse(cmbKategori.SelectedValue.ToString()),
                Fiyat = decimal.Parse(txtFiyat.Text),
                Durum = true
            });

            db.SaveChanges();

            MessageBox.Show("Ürün Eklendi");

            dgwUrunler.DataSource = (from x in db.Tbl_Urun
                                     select new
                                     {
                                         x.ID,
                                         x.UrunAd,
                                         x.Marka,
                                         x.Stok,
                                         x.Fiyat,
                                         x.Durum,
                                         x.Tbl_Kategori.Ad
                                     }).ToList();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var silinecekUrun = db.Tbl_Urun.Find(int.Parse(txtId.Text));
            var sil = db.Tbl_Urun.Remove(silinecekUrun);
            db.SaveChanges();

            MessageBox.Show("Ürün Silindi");

            dgwUrunler.DataSource = (from x in db.Tbl_Urun
                                     select new
                                     {
                                         x.ID,
                                         x.UrunAd,
                                         x.Marka,
                                         x.Stok,
                                         x.Fiyat,
                                         x.Durum,
                                         x.Tbl_Kategori.Ad
                                     }).ToList();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var guncellenecekUrun = db.Tbl_Urun.Find(int.Parse(txtId.Text));

            guncellenecekUrun.UrunAd = txtUrunAdi.Text;
            guncellenecekUrun.Marka = txtMarka.Text;
            guncellenecekUrun.Stok = short.Parse(txtStokSayısı.Text);
            guncellenecekUrun.Kategori = int.Parse(cmbKategori.Text);
            guncellenecekUrun.Fiyat = decimal.Parse(txtFiyat.Text);
            guncellenecekUrun.Durum = true;

            db.SaveChanges();

            MessageBox.Show("Ürün Güncellendi");

            dgwUrunler.DataSource = (from x in db.Tbl_Urun
                                     select new
                                     {
                                         x.ID,
                                         x.UrunAd,
                                         x.Marka,
                                         x.Stok,
                                         x.Fiyat,
                                         x.Durum,
                                         x.Tbl_Kategori.Ad
                                     }).ToList();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtDurum.Text = "";
            txtFiyat.Text = "";
            txtId.Text = "";
            txtMarka.Text = "";
            txtStokSayısı.Text = "";
            txtUrunAdi.Text = "";
            cmbKategori.Text = "";
            
        }
    }
}
