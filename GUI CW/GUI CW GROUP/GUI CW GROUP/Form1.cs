using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_CW_GROUP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void membersDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMemberDetails window1 = new FrmMemberDetails();
           // window1.MdiParent = this;
            window1.ShowDialog();
        }

        private void matchDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMatchDetails window2 = new FrmMatchDetails();
            //window2.MdiParent = this;
            window2.Show();
        }

        private void batsmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBatsman window3 = new FrmBatsman();
            //window3.MdiParent = this;
            window3.Show();
        }

        private void bowlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBowler window4 = new FrmBowler();
            //window4.MdiParent = this;
            window4.Show();
        }

        private void dailyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSquadReport window5 = new FrmSquadReport();
            //window5.MdiParent = this;
            window5.Show();
        }

        private void monthlyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMatchReport window6 = new FrmMatchReport();
            //window6.MdiParent = this;
            window6.Show();
        }
    }
}
