using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Appraisal_System.Models;

namespace Appraisal_System
{
    public partial class FrmBaseManager : Form
    {
        public FrmBaseManager()
        {
            InitializeComponent();
        }

        private void FrmBaseManager_Load(object sender, EventArgs e)
        {

            dgvBase.DataSource = AppraisalBases.ListAll();
        }

        private void dgvBase_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            AppraisalBases appraisal=(AppraisalBases)dgvBase.Rows[e.RowIndex].DataBoundItem;
            AppraisalBases.Update(appraisal);
        }
    }
}
