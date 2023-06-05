using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appraisal_System.Library;
using Appraisal_System.Utility;

namespace Appraisal_System.models
{
    public class AppraisalCoefficients
    {
        public int Id { get; set; }
        public string AppraisalType { get; set; }
        public double AppraisalCoefficient { get; set; }
        public int CalculationMethod { get; set; }
        public bool IsDel { get; set; }

        public static List<AppraisalCoefficients> ListAll()
        {
            List<AppraisalCoefficients> appraisalCoefficients= new List<AppraisalCoefficients>();
            DataTable dt = SqlHelper.ExecuteTable("SELECT * FROM AppraisalCoefficients");
            foreach (DataRow dr in dt.Rows)
            {
                appraisalCoefficients.Add(dr.DataRowToModel<AppraisalCoefficients>());
            }
            return appraisalCoefficients;
        }
    }
}
