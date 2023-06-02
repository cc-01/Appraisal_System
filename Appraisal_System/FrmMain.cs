using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Appraisal_System.Common;

namespace Appraisal_System
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Form form=FormFactory.CreateForm("FrmUserManager");
            //frmUserManager = new FrmUserManager();
            //frmUserManager.MdiParent= this;
            //frmUserManager.Parent = splitContainer1.Panel2;
            //frmUserManager.Show();
            //Form form = FormFactory.CreateForm(0);
            form.MdiParent = this;
            form.Parent = splitContainer1.Panel2;
            form.Show();
        }

        private void trvMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode node in trvMenu.Nodes)
            {
                node.BackColor = Color.White;
                node.ForeColor = Color.Black;
            }
            e.Node.BackColor = SystemColors.Highlight;
            e.Node.ForeColor = Color.White;

            Form form = FormFactory.CreateForm(e.Node.Tag?.ToString());
            form.MdiParent= this;
            form.Parent = splitContainer1.Panel2;
            form.Show();
        }
    }
}
