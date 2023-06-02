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
        //private static FrmUserManager frmUserManager;
        //private static FrmBaseManager frmBaseManager;
        //private static Form form;
        private static List<Form> forms= new List<Form>();
        //public static Form CreateForm(int index)
        //{
        //    HideFormAll();
        //    switch (index)
        //    {
        //        case 0:
        //            if (frmBaseManager == null)
        //            {
        //                frmUserManager = new FrmUserManager();
        //                forms.Add(frmUserManager);
        //            }
        //            form = frmUserManager;
        //            break;
        //        case 1:
        //            if (frmBaseManager == null)
        //            {
        //                frmBaseManager = new FrmBaseManager();
        //                forms.Add(frmBaseManager);
        //            }
        //           form= frmBaseManager;
        //            break;
        //        default:
        //            break;
        //    }
        //    return form;
        //}
        private static List<Type> types;

        static FormFactory()
        {
            Assembly ass = Assembly.LoadFrom("Appraisal_System.exe");
            types = ass.GetTypes().ToList();
        }
        public static Form CreateForm(string formName)
        {
            //获取根目录
            //string path = AppDomain.CurrentDomain.BaseDirectory;
            //获取程序集
            //Assembly ass = Assembly.LoadFrom("Appraisal_System.exe");
            //获取程序集里的所有类
            //types=ass.GetTypes().ToList();

            HideFormAll();
            formName= formName==null ? "FrmNone":formName;
            Form form = forms.Find(m=>m.Name==formName);
            if (form == null)
            {
                Type type=types.Find(m=>m.Name==formName);
                //强制转化为窗体类型
                form = (Form)Activator.CreateInstance(type);
                forms.Add(form);
            }

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
