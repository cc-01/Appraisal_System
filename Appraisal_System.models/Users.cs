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
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Sex { get; set; }
        public int BaseTypeId { get; set; }
        public bool IsDel { get; set; }

        public static List<Users> ListAll()
        {
            DataTable dt = SqlHelper.ExecuteTable("SELECT u.Id,u.UserName,u.PassWord,u.Sex,u.BaseTypeId,u.IsDel FROM Users u");
            List<Users> users = new List<Users>();
            foreach (DataRow dr in dt.Rows)
            {
                users.Add(dr.DataRowToModel<Users>());
            }
            return users;
        }
        public static int Insert(Users user)
        {
            return SqlHelper.ExecuteNonQuery($"INSERT INTO Users(UserName,PassWord,Sex,BaseTypeId,isDel) VALUES(@UserName,@PassWord,@Sex,@BaseTypeId,@IsDel)",
                new SqlParameter("UserName", user.UserName),
                new SqlParameter("PassWord", user.PassWord),
                new SqlParameter("Sex", user.Sex),
                new SqlParameter("BaseTypeId", user.BaseTypeId),
                new SqlParameter("IsDel", user.IsDel)
                );
        }
        public static int Update(Users user)
        {
            string sql = "UPDATE Users SET UserName=@UserName,PassWord=@PassWord,Sex=@Sex,BaseTypeId=@BaseTypeId,IsDel=@IsDel WHERE Id=@Id";
            //using SqlParameter to set query params
            return SqlHelper.ExecuteNonQuery(sql,
                new SqlParameter("@UserName", user.UserName),
                new SqlParameter("@PassWord", user.PassWord),
                new SqlParameter("@Sex", user.Sex),
                new SqlParameter("@BaseTypeId", user.BaseTypeId),
                new SqlParameter("@IsDel", user.IsDel),
                new SqlParameter("@Id", user.Id)
                );
        }
    }
    //public class Users
    //{
    //    public int Id { get; set; }
    //    public string UserName { get; set; }
    //    public string PassWord { get; set; }
    //    public string Sex { get; set; }
    //    public int BaseTypeId { get; set; }
    //    public bool IsDel { get; set; }


    //    public static List<Users> ListAll()
    //    {
    //        List<Users> list = new List<Users>();
    //        string sql = "SELECT u.Id,u.UserName,u.PassWord,u.Sex,u.BaseTypeId,u.IsDel FROM Users u";
    //        DataTable dt = SqlHelper.ExecuteTable(sql);
    //        foreach (DataRow dr in dt.Rows)
    //        {
    //            list.Add(dr.DataRowToModel<Users>());

    //        }
    //        return list;
    //    }
    //    public static int Insert(Users user)
    //    {
    //        string sql = $"INSERT INTO Users(UserName,PassWord,Sex,BaseTypeId,IsDel) VALUES(@UserName,@PassWord,@Sex,@BaseTypeId,@IsDel)";
    //        //using SqlParameter to set query params
    //        return SqlHelper.ExecuteNonQuery(sql,
    //            new SqlParameter("@UserName", user.UserName),
    //            new SqlParameter("@PassWord", user.PassWord),
    //            new SqlParameter("@Sex", user.Sex),
    //            new SqlParameter("@BaseTypeId", user.BaseTypeId),
    //            new SqlParameter("@IsDel", user.IsDel)
    //            );
    //    }

    //    public static int Update(Users user)
    //    {
    //        string sql = $"UPDATE Users SET UserName=@UserName,PassWord=@PassWord,Sex=@Sex,BaseTypeId=@BaseTypeId,IsDel=@IsDel WHERE Id=@Id";
    //        //using SqlParameter to set query params
    //        return SqlHelper.ExecuteNonQuery(sql,
    //            new SqlParameter("@UserName", user.UserName),
    //            new SqlParameter("@PassWord", user.PassWord),
    //            new SqlParameter("@Sex", user.Sex),
    //            new SqlParameter("@BaseTypeId", user.BaseTypeId),
    //            new SqlParameter("@IsDel", user.IsDel),
    //            new SqlParameter("@Id", user.Id)
    //            );
    //    }
    //}
}
