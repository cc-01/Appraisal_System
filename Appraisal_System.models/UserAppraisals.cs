using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appraisal_System.Library;
using Appraisal_System.Utility;

namespace Appraisal_System.models
{
    public class UserAppraisals
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CoefficientId { get; set; }
        public double Count { get; set; }
        public int AssessmentYear { get; set; }
        public bool IsDel { get; set; }
        public static List<UserAppraisals> ListByUserIdAndYear(int userId,string year)
        {
            List<UserAppraisals> userAppraisals = new List<UserAppraisals>();
            DataTable dt = SqlHelper.ExecuteTable("SELECT * FROM UserAppraisals WHERE UserId=@UserId AND AssessmentYear=@AssessmentYear", new SqlParameter("@UserId", userId), new SqlParameter("@AssessmentYear", year));
            foreach (DataRow dr in dt.Rows)
            {
                userAppraisals.Add(dr.DataRowToModel<UserAppraisals>());
            }
            return userAppraisals;
        }
        public static void Insert(UserAppraisals userAppraisals)
        {
             SqlHelper.ExecuteNonQuery("INSERT INTO UserAppraisals (UserId,CoefficientId,Count,AssessmentYear,IsDel) VALUES (@UserId,@CoefficientId,@Count,@AssessmentYear,@IsDel)",
                new SqlParameter("@UserId", userAppraisals.UserId),
                new SqlParameter("@CoefficientId", userAppraisals.CoefficientId),
                new SqlParameter("Count", userAppraisals.Count),
                new SqlParameter("AssessmentYear", userAppraisals.AssessmentYear),
                new SqlParameter("IsDel", userAppraisals.IsDel)
                );
        }
        public static void Delete(int UserId,string AssessmentYear,int CoefficientId)
        {
             SqlHelper.ExecuteNonQuery("DELETE FROM UserAppraisals WHERE UserId=@UserId AND AssessmentYear=@AssessmentYear AND CoefficientId=@CoefficientId",
                new SqlParameter("@UserId", UserId),
                new SqlParameter("@AssessmentYear", AssessmentYear),
                new SqlParameter("@CoefficientId",CoefficientId)
                );
        }
    }
}
