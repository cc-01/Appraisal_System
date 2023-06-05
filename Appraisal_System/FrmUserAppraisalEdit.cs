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

namespace Appraisal_System
{
    public partial class FrmUserAppraisalEdit : Form
    {
        private int _userId;
        private string _year;
        private Action _bindDgv;
        public FrmUserAppraisalEdit()
        {
            InitializeComponent();
        }
        public FrmUserAppraisalEdit(int userId, string year,Action bindDgv) :this(){
            _userId = userId;
            _year = year;
            _bindDgv = bindDgv;
        }

        private void FrmUserAppraisalEdit_Load(object sender, EventArgs e)
        {
            CreateControls();
            BindeControls();
        }

        private void BindeControls()
        {
            List<UserAppraisals> userAppraisals = UserAppraisals.ListByUserIdAndYear(_userId, _year);
            foreach (var ua in userAppraisals)
            {
                var flCtrs = flp.Controls;
                foreach (Control flCtr in flCtrs)
                {
                    if (flCtr is Panel)
                    {
                        var plCtrs = flCtr.Controls;
                        foreach (var plCtr in plCtrs)
                        {
                            if (plCtr is TextBox)
                            {
                                int acId = Convert.ToInt32(((TextBox)plCtr).Name.Split('_')[1]);
                                ((TextBox)plCtr).Text = userAppraisals.Find(m => m.CoefficientId == acId).Count.ToString();
                            }
                        }
                    }
                }
            }
        }

        private void CreateControls()
        {
            List<AppraisalCoefficients> appraisalCoefficients = AppraisalCoefficients.ListAll();
            foreach (var item in appraisalCoefficients)
            {
                Panel panel = new Panel();
                Label label = new Label
                {
                    Text = item.AppraisalType,
                    Width = 60,
                    Location = new Point(0, 4)
                };
                TextBox textbox = new TextBox
                {
                    Width = 120,
                    Height = 26,
                    Location = new Point(66, 0),
                    Name = "txtAppraisalType_" + item.Id,
                };
                panel.Controls.Add(label);
                panel.Controls.Add(textbox);
                flp.Controls.Add(panel);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var flCtrs = flp.Controls;
            foreach (Control flCtr in flCtrs)
            {
                if (flCtr is Panel)
                {
                    var plCtrs = flCtr.Controls;
                    foreach (var plCtr in plCtrs)
                    {
                        if (plCtr is TextBox)
                        {
                            int acId = Convert.ToInt32(((TextBox)plCtr).Name.Split('_')[1]);
                            double count = Convert.ToDouble(((TextBox)plCtr).Text);
                            UserAppraisals.Delete(_userId, _year, acId);
                            UserAppraisals userAppraisals = new UserAppraisals
                            {
                                UserId = _userId,
                                CoefficientId = acId,
                                AssessmentYear = Convert.ToInt32(_year),
                                Count = count,
                                IsDel = false
                            };
                            UserAppraisals.Insert(userAppraisals);

                        }
                    }

                }
            }
            MessageBox.Show("数据修改成功");
            _bindDgv();
            this.Close();
        }
    }
}
