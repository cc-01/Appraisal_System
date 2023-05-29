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
    public delegate void DelBindDgv();
    public partial class FrmUserManager : Form
    {
        DelBindDgv delBindDgv;
        public FrmUserManager()
        {
            InitializeComponent();
        }

        private void FrmUserManager_Load(object sender, EventArgs e)
        {
            BindCbx();
            BindDgv();
            delBindDgv = BindDgv;

        }

        private void BindDgv()
        {
            string userName = txtUserName.Text.Trim();
            int baseTypeId = (int)cbxBase.SelectedValue;
            bool isStop = chkIsStop.Checked;
            dgvUserAppraisal.AutoGenerateColumns = false;
            List<UserAppraisalBases> userAppraisalBases = UserAppraisalBases.GetListJoinAppraisal();
            if (baseTypeId == 0)
            {
                dgvUserAppraisal.DataSource = userAppraisalBases.FindAll(a => a.UserName.Contains(userName) && a.IsDel == isStop);
            }
            else
            {
                dgvUserAppraisal.DataSource = userAppraisalBases.FindAll(a => a.UserName.Contains(userName) && a.BaseTypeId == baseTypeId && a.IsDel == isStop);
            }
        }

        private void BindCbx()
        {
            List<AppraisalBases> appraisalBases = new List<AppraisalBases>();
            //方式一
            //appraisalBases.Add(new AppraisalBases
            //{
            //    Id = 0,
            //    BaseType = "-查询所有-",
            //    AppraisalBase = 0,
            //    IsDel = false
            //});
            //IEnumerable<AppraisalBases> appraisalBases1 = AppraisalBases.ListAll();
            //appraisalBases.AddRange(appraisalBases1);
            appraisalBases = AppraisalBases.ListAll();
            appraisalBases.Insert(0, new AppraisalBases
            {
                Id = 0,
                BaseType = "-查询所有-",
                AppraisalBase = 0,
                IsDel = false
            });
            cbxBase.DataSource = appraisalBases;
            cbxBase.DisplayMember = "BaseType";
            cbxBase.ValueMember = "Id";
            //appraisalBases = AppraisalBases.ListAll();
            //foreach (var appraisalBase in appraisalBases)
            //{
            //    cbxBase.Items.Add(appraisalBase.BaseType);
            //}
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindDgv();
        }

        private void dgvUserAppraisal_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                tsmAdd.Visible = true;
                tsmExit.Visible = false;
                tsmStart.Visible = false;
                tsmStop.Visible = false;
            }
        }

        private void dgvUserAppraisal_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right )
            {
                if (e.RowIndex > -1)
                {
                    dgvUserAppraisal.Rows[e.RowIndex].Selected = true;
                    tsmAdd.Visible = true;
                    tsmExit.Visible = true;
                    //在已经启用的那行右键显示停用，在停用的那行显示启用
                    bool isDel=(bool)dgvUserAppraisal.SelectedRows[0].Cells["IsDel"].Value;
                    if (isDel)
                    {
                        tsmStart.Visible = true;
                    }
                    else
                    {
                        tsmStop.Visible = true;
                    }
                }
            }
        }
        //cmsUserManager右键新增功能
        private void tsmAdd_Click(object sender, EventArgs e)
        {
            FrmSetUser frmSetUser = new FrmSetUser(delBindDgv);
            frmSetUser.ShowDialog();
            BindDgv();
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            int id = (int)dgvUserAppraisal.SelectedRows[0].Cells["Id"].Value;
            FrmSetUser frmSetUser = new FrmSetUser(delBindDgv, id);
            frmSetUser.ShowDialog();
        }
    }
}
