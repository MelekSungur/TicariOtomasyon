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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }

        private void Cmbil_Properties_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        SqlBaglantisi bgl = new SqlBaglantisi();
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

                Cmbilce.Properties.Items.Add(drm[0]);
            }
            bgl.baglanti().Close();




        }
       
        void PersonelListe()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_PERSONELLER", bgl.baglanti());

            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmPersonel_Load(object sender, EventArgs e)
        {

            PersonelListe();
        }
        

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
          
            
            SqlCommand kaydet = new SqlCommand("insert into TBL_PERSONELLER (AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9)",bgl.baglanti());
           
            kaydet.Parameters.AddWithValue("@P1", TxtAd.Text);
            kaydet.Parameters.AddWithValue("@P2", TxtSoyad.Text);
            kaydet.Parameters.AddWithValue("@P3", MskTel.Text);
            kaydet.Parameters.AddWithValue("@P4", MskTc.Text);
            kaydet.Parameters.AddWithValue("@P5", TxtMail.Text);
            kaydet.Parameters.AddWithValue("@P6", Cmbil.Text);
            kaydet.Parameters.AddWithValue("@P7", Cmbilce.Text);
            kaydet.Parameters.AddWithValue("@P8", RchAdres.Text);
            kaydet.Parameters.AddWithValue("@P9", TxtGorev.Text);
            kaydet.ExecuteNonQuery();
           
            MessageBox.Show("Personel Kaydedildi");


            PersonelListe();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["ID"].ToString();
                TxtAd.Text = dr["AD"].ToString();
                TxtSoyad.Text = dr["SOYAD"].ToString();
                MskTel.Text = dr["TELEFON"].ToString();
                MskTc.Text = dr["TC"].ToString();
                TxtMail.Text = dr["MAIL"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                Cmbilce.Text = dr["ILCE"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();
                TxtGorev.Text = dr["GOREV"].ToString();
            }
        }
    }
}
