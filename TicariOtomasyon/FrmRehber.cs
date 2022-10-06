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
    public partial class FrmRehber : Form
    {
        SqlBaglantisi bgl = new SqlBaglantisi();
        public FrmRehber()
        {
            InitializeComponent();
        }

        private void FrmRehber_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select AD,SOYAD,TELEFON,TELEFON2,MAIL From TBL_MUSTERILER ", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource=dt;

            DataTable dtl= new DataTable();
            SqlDataAdapter daf = new SqlDataAdapter("Select AD,YETKILIADSOYAD,TELEFON1,TELEFON2,MAIL,FAX From TBL_FIRMALAR ", bgl.baglanti());
            daf.Fill(dtl);
            gridControl2.DataSource = dtl;


        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frmail = new FrmMail();
            DataRow dr=gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if(dr!=null)
            {
                frmail.Mail = dr["MAIL"].ToString();
            }
            frmail.Show();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frmail = new FrmMail();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                frmail.Mail = dr["MAIL"].ToString();
            }
            frmail.Show();
        }
    }
}
