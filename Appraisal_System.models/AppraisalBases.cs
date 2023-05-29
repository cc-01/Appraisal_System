using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appraisal_System.Utility;

namespace Appraisal_System.Models
{
    public class AppraisalBases
    {
        public int Id { get; set; }
        public string BaseType { get; set; }
        public int AppraisalBase { get; set; } 
        public bool IsDel { get; set; }

        public static List<AppraisalBases> ListAll() {
            List<AppraisalBases> appraisalBases= new List<AppraisalBases>();
            DataTable dt = SqlHelper.ExecuteTable("SELECT * FROM AppraisalBases");
            foreach (DataRow dr in dt.Rows)
            {
                appraisalBases.Add(ToModel(dr));
            }
            return appraisalBases;
        }
        //public static int Update(AppraisalBases appraisalBases)
        //{
        //    string sql = $"UPDATE AppraisalBases SET BaseType=@BaseType,AppraisalBase=@AppraisalBase,IsDel=@IsDel WHERE Id=@Id";
        //    //using SqlParameter to set query params
        //    int rows= SqlHelper.ExecuteNonQuery(sql,
        //        new SqlParameter("@Id", appraisalBases.Id),
        //        new SqlParameter("@BaseType", appraisalBases.BaseType),
        //        new SqlParameter("@UserName", appraisalBases.AppraisalBase),
        //        new SqlParameter("@IsDel", appraisalBases.IsDel)
        //        );
        //    return rows;
        //}
        private static AppraisalBases ToModel(DataRow dr)
        {
            AppraisalBases appraisalBase= new AppraisalBases();
            appraisalBase.Id = (int)dr["Id"];
            appraisalBase.BaseType = dr["BaseType"].ToString();
            appraisalBase.AppraisalBase = (int)dr["AppraisalBase"];
            appraisalBase.IsDel = (bool)dr["IsDel"];
            return appraisalBase;
        }
        public static int Update(AppraisalBases appraisal)
        {
            string sql = "UPDATE AppraisalBases SET BaseType=@BaseType,AppraisalBase=@AppraisalBase,IsDel=@IsDel WHERE Id=@Id";
            int rows = SqlHelper.ExecuteNonQuery(sql,
                new SqlParameter("@Id", appraisal.Id),
                new SqlParameter("@BaseType", appraisal.BaseType),
                new SqlParameter("@AppraisalBase", appraisal.AppraisalBase),
                new SqlParameter("@IsDel", appraisal.IsDel)
                );
            return rows;
        }
    }
}
