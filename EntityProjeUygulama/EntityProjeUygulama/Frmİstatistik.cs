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
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            // Toplam Kategori Sayısı
            var toplamKategoriSayisi = db.Tbl_Kategori.Count();
            lblToplamKategoriSayisi.Text = toplamKategoriSayisi.ToString();

            // Toplam Ürün Sayısı
            var toplamUrunSayisi = db.Tbl_Urun.Count();
            lblToplamUrunSayisi.Text = toplamUrunSayisi.ToString();

            // Aktif Müşteri Sayısı
            var aktifMusteriSayisi = db.Tbl_Musteri.Where(x => x.Durum == true).Count();
            lblAktifMusteriSayisi.Text = aktifMusteriSayisi.ToString();

            // Pasif Müşteri Sayısı
            var pasifMusteriSayisi = db.Tbl_Musteri.Where(x => x.Durum == false).Count();
            lblPasifMusteriSayisi.Text = pasifMusteriSayisi.ToString();

            // Beyaz Eşya Sayısı
            var beyazEsyaSayisi = db.Tbl_Urun.Where(x => x.Kategori == 1).Count();
            lblBeyazEsyaSayisi.Text = beyazEsyaSayisi.ToString();

            // Toplam Stok Sayısı
            var toplamStokSayisi = db.Tbl_Urun.Sum(x => x.Stok);
            lblToplamStokSayisi.Text = toplamStokSayisi.ToString();

            // En Yüksek Fiyatlı Ürün
            var enYuksekFiyatlıUrun = (from x in db.Tbl_Urun orderby x.Fiyat descending select x.UrunAd).FirstOrDefault();
            lblEnYuksekFiyatlıUrun.Text = enYuksekFiyatlıUrun;

            // En Düşük Fiyatlı Ürün
            var enDusukFiyatlıUrun  = (from x in db.Tbl_Urun orderby x.Fiyat ascending select x.UrunAd).FirstOrDefault();
            lblEnDusukFiyatlıUrun.Text = enDusukFiyatlıUrun;

            // En Fazla Ürünü Olan Marka
            lblEnFazlaUrunuOlanMarka.Text = db.MarkaGetir().FirstOrDefault(); // MarkaGetir metodu aslında SQL'de yazılmış olan bir prosedürdür!

            // Toplam Buzdolabı Sayısı
            var toplamSampuanSayisi = db.Tbl_Urun.Where(x => x.UrunAd == "Şampuan").Select(x => x.Stok).FirstOrDefault();
            lblToplamSampuanSayisi.Text = toplamSampuanSayisi.ToString();


            // Toplam Şehir Sayısı
            var toplamSehirSayisi = db.Tbl_Musteri.Select(x => x.Sehir).Distinct().Count();
            lblToplamSehirSayisi.Text = toplamSehirSayisi.ToString();


            // Kasadaki Tutar
            var kasaTutar = db.Tbl_Satis.Sum(x => x.Fiyat);
            lblKasadakiTutar.Text = kasaTutar.ToString() + " TL";
        }
    }
}
