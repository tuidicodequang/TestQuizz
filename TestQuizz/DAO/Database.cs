using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQuizz
{
    public class Database
    {
        SqlConnection sqlCon;
        DataSet ds;
        SqlDataAdapter da;

        public Database()
        {
            string strCnn = "Data Source=.\\SQLEXPRESS;Initial Catalog=TestQuiz;Integrated Security=True";
            sqlCon = new SqlConnection(strCnn);
        }
        //select
        public DataTable Excute(string sqlStr)
        {
            da = new SqlDataAdapter(sqlStr, sqlCon);
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        //update, insert,delete
        public void ExcuteNonQuery(string strSQL)
        {
            SqlCommand sqlcmd = new SqlCommand(strSQL, sqlCon);
            sqlCon.Open();
            sqlcmd.ExecuteNonQuery();
            sqlCon.Close();
        }


        public int ExecuteScalar(string strSQL)
        {
            int result = 0;
            SqlCommand sqlcmd = new SqlCommand(strSQL, sqlCon);
            sqlCon.Open();
            result = Convert.ToInt32(sqlcmd.ExecuteScalar());
            sqlCon.Close();
            return result;
        }
    }
}
