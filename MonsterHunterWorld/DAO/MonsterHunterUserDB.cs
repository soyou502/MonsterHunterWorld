using MonsterHunterWorld.VO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.DAO
{
    class MonsterHunterUserDB
    {
        SqlConnection con;
        SqlCommand cmd;
        public MonsterHunterUserDB()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection();
            cmd = new SqlCommand();
            con.ConnectionString = connectionString;
            cmd.Connection = con;
        }

        public bool UserIDCheck(string userID)
        {
            cmd.CommandText = "select UserId from MonsterHunterUserInfo where UserID = " + userID;
            con.Open();
            var check = cmd.ExecuteScalar();
            con.Close();
            if (check != null)
            {
                return false;
            }else
            {
                return true;
            }
        }

        public void InsertUserInfo(string userId, string UserPassword)
        {
            cmd.CommandText = "insert into MonsterHunterUserInfo values(" + userId + " ," + UserPassword + ");";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            System.Windows.Forms.MessageBox.Show("회원가입 성공");
        }

        public bool UserCheck(string userId, string userPassword)
        {
            cmd.CommandText = "select UserId from MonsterHunterUserInfo where UserID = " + userId + " AND UserPassword = " + userPassword;
            con.Open();
            var check = cmd.ExecuteScalar();
            con.Close();
            if (check != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
