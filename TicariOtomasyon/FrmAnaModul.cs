using DevExpress.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicariOtomasyon
{
    public partial class FrmAnaModul : Form
    {
        public FrmAnaModul()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        FrmMusteriler frm;

       FrmUrunler fr;
        FrmRehber frr;
        private void BtnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null)
                fr = new FrmUrunler();
            fr.MdiParent= this;
            fr.Show();

        }

        FrmStoklar frs;
        private void Btnstoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (frs == null)
            {
                frs=new FrmStoklar();
                frs.MdiParent= this;
                frs.Show();

            }

        }

        private void BtnMüsteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm== null)
                frm = new FrmMusteriler();
            frm.MdiParent = this;
            frm.Show();
        }
        FrmFirmalar frmi;
        private void BtnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if( frmi==null)
            {
                frmi = new FrmFirmalar();
                frmi.MdiParent = this;
                frmi.Show();
            }
        }
        FrmPersonel frm4;
        private void BtnAnasayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            }

        private void BtnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm4 == null)
            {
                frm4 = new FrmPersonel();
                frm4.MdiParent = this;
                frm4.Show();
            }
    }

        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frr == null)
            {
                frr = new FrmRehber();
                frr.MdiParent = this;
                frr.Show();
            }
        }
        FrmGiderler frg;

        private void BtnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frg== null)
            {
                frg = new FrmGiderler();
                frg.MdiParent = this;
                frg.Show();
            }
        }
    }
} 
