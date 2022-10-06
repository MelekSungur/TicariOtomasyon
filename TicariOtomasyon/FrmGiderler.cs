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
using DevExpress.XtraBars;

namespace TicariOtomasyon
{
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }

        private void Cmbil_Properties_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        void GiderListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da=new SqlDataAdapter("select * from TBL_GIDERLER",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;   
        }

        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            GiderListesi();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_GIDERLER (AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EXTRA,NOTLAR) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", Txtay.Text);
            komut.Parameters.AddWithValue("@P2", txtyil.Text);
            komut.Parameters.AddWithValue("@P3", decimal.Parse(txtelektrik.Text));
            komut.Parameters.AddWithValue("@P4", decimal.Parse( txtsu.Text));
            komut.Parameters.AddWithValue("@P5", decimal.Parse( Txtdogalgaz.Text));
            komut.Parameters.AddWithValue("@P6",decimal.Parse( txtinternet.Text));
            komut.Parameters.AddWithValue("@P7", decimal.Parse(txtmaas.Text));
            komut.Parameters.AddWithValue("@P8", decimal.Parse(Txtextra.Text));
            komut.Parameters.AddWithValue("@P9", Rchnot.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider Listeye Eklendi");
            GiderListesi();


        }
    }
}
