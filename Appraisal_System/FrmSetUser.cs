using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Appraisal_System.models;
using Appraisal_System.Models;

namespace Appraisal_System
{
    public partial class FrmSetUser : Form
    {
        private DelBindDgv _delBindDgv;
        public FrmSetUser(DelBindDgv delBindDgv)
        {
            InitializeComponent();
            _delBindDgv = delBindDgv;
        }
        private Users _user;
        public FrmSetUser(DelBindDgv delBindDgv, int userId) : this(delBindDgv)
        {
            _user = Users.ListAll().Find(u => u.Id == userId);

        }

        private void FrmSetUser_Load(object sender, EventArgs e)
        {
            List<AppraisalBases> appraisalBases = new List<AppraisalBases>();
            appraisalBases = AppraisalBases.ListAll();
            cbxBase.DataSource = appraisalBases;
            cbxBase.DisplayMember = "BaseType";
            cbxBase.ValueMember = "Id";
            if(_user != null)
            {
                txtUserName.Text = _user.UserName;
                cbxBase.SelectedValue = _user.BaseTypeId;
                cbxSex.Text = _user.Sex;
                chkIsStop.Checked = _user.IsDel;
            }
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            int baseTypeId = (int)cbxBase.SelectedValue;
            string sex = cbxSex.Text;
            bool isDel = chkIsStop.Checked;

            if (_user == null)
            {
                Users user = new Users
                {
                    UserName = userName,
                    BaseTypeId = baseTypeId,
                    PassWord = "1111",
                    Sex = sex,
                    IsDel = isDel
                };
                Users.Insert(user);
                MessageBox.Show("用户添加成功！！！");
            }
            else
            {
                _user.UserName = userName;
                _user.BaseTypeId = baseTypeId;
                _user.Sex = sex;
                _user.IsDel = isDel;
                Users.Update(_user);
                MessageBox.Show("用户修改成功！！！");
            }
            _delBindDgv();
            this.Close();
        }
    }

}
