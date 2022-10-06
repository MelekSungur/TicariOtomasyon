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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        void FirmaListesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_FIRMALAR", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
         void temizle()
        {
            TxtFirmaAd.Text = "";
            Txtid.Text = "";
            TxtKod1.Text = "";
            TxtKod2.Text = "";
            TxtKod3.Text = "";
            TxtMail.Text = "";
            TxtSektor.Text = "";
            TxtVergiDairesi.Text="";
            TxtYetkiliAd.Text = "";
            TxtYetkiliGörev.Text = "";
            MskFax.Text = "";
            MskTel1.Text = "";
            Msktel2.Text = "";
            MskTel3.Text = "";
            MskTc.Text = "";
            RchAdres.Text = "";
            RchKod1.Text = "";
            RchKod2.Text = "";
            RchKod3.Text = "";
            Cmbil.Text = "";
            Cmbilce.Text = "";


           

        }

        private void Cmbil_Properties_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void carikodacıklamalar()
        {
            SqlCommand komut1 = new SqlCommand("select FIRMAKOD1 FROM   TBL_KODLAR", bgl.baglanti());
            SqlDataReader dr1=komut1.ExecuteReader();
            while(dr1.Read())
            {
                RchKod1.Text = dr1[0].ToString();
               

            }
            bgl.baglanti().Close();
            SqlCommand komut2 = new SqlCommand("select FIRMAKOD2 FROM   TBL_KODLAR", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                RchKod2.Text = dr2[0].ToString();
                

            }
            bgl.baglanti().Close();
           
            SqlCommand komut3 = new SqlCommand("select FIRMAKOD3 FROM   TBL_KODLAR", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                RchKod3.Text = dr3[0].ToString();
              

            }
            bgl.baglanti().Close();



        }
        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            FirmaListesi();
            SehirListesi();
            carikodacıklamalar();
            
        }
        void SehirListesi()
        {

            SqlCommand komut = new SqlCommand("Select * From TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {

                Cmbil.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
            SqlCommand komut1 = new SqlCommand("Select * From TBL_ILCELER", bgl.baglanti());
            SqlDataReader drm = komut1.ExecuteReader();
            while (drm.Read())
            {

                Cmbilce.Properties.Items.Add(drm[1]);
            }
            bgl.baglanti().Close();




        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["ID"].ToString();
                TxtFirmaAd.Text = dr["AD"].ToString();
                TxtYetkiliGörev.Text = dr["YETKILISTATU"].ToString();
                TxtYetkiliAd.Text = dr["YETKILIADSOYAD"].ToString();
                TxtSektor.Text = dr["SEKTOR"].ToString();
                MskTc.Text = dr["YETKILITC"].ToString();
                MskTel1.Text = dr["TELEFON1"].ToString();
                Msktel2.Text = dr["TELEFON2"].ToString();
                MskTel3.Text = dr["TELEFON3"].ToString();
                TxtMail.Text = dr["MAIL"].ToString();
                MskFax.Text = dr["FAX"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                Cmbilce.Text = dr["IL"].ToString();
                TxtVergiDairesi.Text = dr["VERGIDAIRE"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();
                RchKod1.Text = dr["IL"].ToString();
                RchKod2.Text = dr["IL"].ToString();
                RchKod3.Text = dr["IL"].ToString();


            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_FIRMALAR (AD,YETKILISTATU,YETKILIADSOYAD,SEKTOR,YETKILITC,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX,IL,ILCE,VERGIDAIRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtFirmaAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtYetkiliGörev.Text);
            komut.Parameters.AddWithValue("@p3", TxtYetkiliAd.Text);
            komut.Parameters.AddWithValue("@p4", TxtSektor.Text);
            komut.Parameters.AddWithValue("@p5", MskTc.Text);
            komut.Parameters.AddWithValue("@p6", MskTel1.Text);
            komut.Parameters.AddWithValue("@p7", Msktel2.Text);
            komut.Parameters.AddWithValue("@p8", MskTel3.Text);
            komut.Parameters.AddWithValue("@p9", TxtMail.Text);
            komut.Parameters.AddWithValue("@p10", MskFax.Text);
            komut.Parameters.AddWithValue("@p11", Cmbil.Text);
            komut.Parameters.AddWithValue("@p12", Cmbilce.Text);
            komut.Parameters.AddWithValue("@p13", TxtVergiDairesi.Text);
            komut.Parameters.AddWithValue("@p14", RchAdres.Text);
            komut.Parameters.AddWithValue("@p15", RchKod1.Text);
            komut.Parameters.AddWithValue("@p16", RchKod2.Text);
            komut.Parameters.AddWithValue("@p17", RchKod3.Text);




            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK);
            FirmaListesi();
            temizle();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From TBL_FIRMALAR where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            FirmaListesi();
            MessageBox.Show("Firma Listeden Silindi");
            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FIRMALAR set AD=@p1,YETKILISTATU=@p2,YETKILIADSOYAD=@p3,SEKTOR=@p4,YETKILITC=@p5,TELEFON1=@p6,TELEFON2=@p7,TELEFON3=@p8,MAIL=@p9,IL=@p10,ILCE=@p11,FAX=@p12,VERGIDAIRE=@p13,ADRES=@p14,OZELKOD1=@p15,OZELKOD2=@p16,OZELKOD3=@p17 where ID=@p18", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtFirmaAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtYetkiliGörev.Text);
            komut.Parameters.AddWithValue("@p3", TxtYetkiliAd.Text);
            komut.Parameters.AddWithValue("@p4", TxtSektor.Text);
            komut.Parameters.AddWithValue("@p5", MskTc.Text);
            komut.Parameters.AddWithValue("@p6", MskTel1.Text);
            komut.Parameters.AddWithValue("@p7", Msktel2.Text);
            komut.Parameters.AddWithValue("@p8", MskTel3.Text);
            komut.Parameters.AddWithValue("@p9", TxtMail.Text);
            komut.Parameters.AddWithValue("@p10", MskFax.Text);
            komut.Parameters.AddWithValue("@p11", Cmbil.Text);
            komut.Parameters.AddWithValue("@p12", Cmbilce.Text);
            komut.Parameters.AddWithValue("@p13", TxtVergiDairesi.Text);
            komut.Parameters.AddWithValue("@p14", RchAdres.Text);
            komut.Parameters.AddWithValue("@p15", RchKod1.Text);
            komut.Parameters.AddWithValue("@p16", RchKod2.Text);
            komut.Parameters.AddWithValue("@p17", RchKod3.Text);
            komut.Parameters.AddWithValue("@p18", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK);
            FirmaListesi();

        }
    }
}