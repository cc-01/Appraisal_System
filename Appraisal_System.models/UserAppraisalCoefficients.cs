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
    public class UserAppraisalCoefficients
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CoefficientId { get; set; }
        public double Count { get; set; }
        public int AssessmentYear { get; set; }
        public string AppraisalType { get; set; }
        public double AppraisalCoefficient { get; set; }
        public int CalculationMethod { get; set; }
        public bool IsDel { get; set; }

        public static List<UserAppraisalCoefficients> ListAll()
        {
            List<UserAppraisalCoefficients> userAppraisalCoefficients = new List<UserAppraisalCoefficients>();
            DataTable dt = SqlHelper.ExecuteTable("SELECT ua.*,ac.AppraisalType,ac.AppraisalCoefficient,ac.CalculationMethod FROM UserAppraisals ua LEFT JOIN AppraisalCoefficients ac ON ua.CoefficientId=ac.Id");
            foreach (DataRow dr in dt.Rows)
            {
                userAppraisalCoefficients.Add(dr.DataRowToModel<UserAppraisalCoefficients>());
            }
            return userAppraisalCoefficients;
        }
    }
}
