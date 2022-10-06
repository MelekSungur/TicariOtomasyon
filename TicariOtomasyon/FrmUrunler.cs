using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TicariOtomasyon
{
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_URUNLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            Listele();
            //ürünler formunda da mdi vardı o yüzden hata veriyordu
            //bundan sonra sorunsuz çalışır başka sorun var mı
          
        }

      

      

       
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("Update TBL_URUNLER set URUNAD=@P1, MARKA=@P2, MODEL=@P3, YIL=@P4, ADET=@P5, ALISFIYAT=@P6, SATISFIYAT=@P7, DETAY=@P8 WHERE ID=@P9",bgl.baglanti());
            guncelle.Parameters.AddWithValue("@P1", TxtUrunAd.Text);
            guncelle.Parameters.AddWithValue("@P2", TxtMarka.Text);
            guncelle.Parameters.AddWithValue("@P3", TxtModel.Text);
            guncelle.Parameters.AddWithValue("@P4", MskYil.Text);
            guncelle.Parameters.AddWithValue("@P5", int.Parse((NudAdet.Value).ToString()));
            guncelle.Parameters.AddWithValue("@P6", decimal.Parse(TxtAlis.Text));
            guncelle.Parameters.AddWithValue("@P7", decimal.Parse(TxtSatis.Text));
            guncelle.Parameters.AddWithValue("@P8", RchDetay.Text);
            guncelle.Parameters.AddWithValue("@p9", Txtid.Text);
            guncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Txtid.Text = " ";
            TxtAlis.Text = " ";
            TxtUrunAd.Text = " ";
            TxtMarka.Text = "";
            TxtModel.Text = " ";
            MskYil.Text = " ";
           
            TxtSatis.Text = "";
            RchDetay.Text = "";
        }

        private void BtnKaydet_Click_1(object sender, EventArgs e)
        {
            SqlCommand kaydet = new SqlCommand("insert into TBL_URUNLER (URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
            kaydet.Parameters.AddWithValue("@p1", TxtUrunAd.Text);
            kaydet.Parameters.AddWithValue("@p2", TxtMarka.Text);
            kaydet.Parameters.AddWithValue("@p3", TxtModel.Text);
            kaydet.Parameters.AddWithValue("@p4", MskYil.Text);
            kaydet.Parameters.AddWithValue("@p5", int.Parse((NudAdet.Value).ToString()));
            kaydet.Parameters.AddWithValue("@p6", decimal.Parse(TxtAlis.Text).ToString());
            kaydet.Parameters.AddWithValue("@p7", decimal.Parse(TxtSatis.Text).ToString());
            kaydet.Parameters.AddWithValue("@p8", RchDetay.Text);
            kaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün sisteme eklendi", "Bilgi", MessageBoxButtons.OK);
            Listele();
        }

        private void BtnSil_Click_1(object sender, EventArgs e)
        {
            SqlCommand sil = new SqlCommand("Delete From TBL_URUNLER where ID=@p1", bgl.baglanti());
            sil.Parameters.AddWithValue("@p1", Txtid.Text);
            sil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
        }

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            Txtid.Text = dr["ID"].ToString();
            TxtUrunAd.Text = dr["URUNAD"].ToString();
            TxtMarka.Text = dr["MARKA"].ToString();
            TxtModel.Text = dr["MODEL"].ToString();
            MskYil.Text = dr["YIL"].ToString();
            NudAdet.Value = decimal.Parse(dr["ADET"].ToString());
            TxtAlis.Text = dr["ALISFIYAT"].ToString();
            TxtSatis.Text = dr["SATISFIYAT"].ToString();
            RchDetay.Text = dr["DETAY"].ToString();
        }
    }
}
