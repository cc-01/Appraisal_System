using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appraisal_System.Common
{
    public class FormFactory
    {
        private static FrmUserManager frmUserManager;
        private static FrmBaseManager frmBaseManager;
        private static Form form;
        private static List<Form> forms= new List<Form>();
        public static Form CreateForm(int index)
        {
            HideFormAll();
            switch (index)
            {
                case 0:
                    if (frmBaseManager == null)
                    {
                        frmUserManager = new FrmUserManager();
                        forms.Add(frmUserManager);
                    }
                    form = frmUserManager;
                    break;
                case 1:
                    if (frmBaseManager == null)
                    {
                        frmBaseManager = new FrmBaseManager();
                        forms.Add(frmBaseManager);
                    }
                   form= frmBaseManager;
                    break;
                default:
                    break;
            }
            return form;
        }
        public static Form CreateForm(string formName)
        {
            //获取根目录
            //string path = AppDomain.CurrentDomain.BaseDirectory;
            //获取程序集
            Assembly ass = Assembly.LoadFrom("Appraisal_System.exe");
            //获取程序集里的所有类
            List<Type> types=ass.GetTypes().ToList();
            Type type=types.Find(m=>m.Name==formName);
            //强制转化为窗体类型
            Form form=(Form)Activator.CreateInstance(type);
            return form;
        }
        public static void HideFormAll()
        {
            foreach (var form in forms)
            {
                form.Hide();
            }
        }
    }
}
