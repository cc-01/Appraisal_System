using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appraisal_System.Utility
{
    public class SqlHelper
    {
        public static string ConStr { get; set; }

        public static DataTable ExecuteTable(string cmdText)
        {
            using(SqlConnection conn=new SqlConnection(ConStr))
            {
                conn.Open();
                SqlCommand cmd=new SqlCommand(cmdText,conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds= new DataSet();
                sda.Fill(ds);
                return ds.Tables[0];
            }
        }
        public static int ExecuteNonQuery(string cmdText,params SqlParameter[] sqlParameters)
        {
            using (SqlConnection conn = new SqlConnection(ConStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddRange(sqlParameters);
                int rows = cmd.ExecuteNonQuery();
                if (rows <= 0)
                {
                    throw new Exception("数据库操作失败");
                }
                return rows;
            }
        }
    }
}
