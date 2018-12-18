using MonsterHunterWorld.VO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;

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
        }

        private SqlConnection OpenConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed || con.State == System.Data.ConnectionState.Broken)
            {
                con.Open();
            }
            return con;
        }

        public bool UserIDCheck(string userId)
        {
            cmd.Parameters.Clear();
            cmd.Connection = OpenConnection();
            cmd.CommandText = "proc_Check_UserID";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", HttpUtility.UrlEncode(userId));
            var check = cmd.ExecuteScalar();
            con.Close();
            if ((int)check != 0)
            {
                return false;
            }else
            {
                return true;
            }
        }

        public void InsertUserInfo(string userId, string userPassword)
        {
            cmd.Parameters.Clear();
            cmd.Connection = OpenConnection();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "proc_insert_UserInfo";
            cmd.Parameters.AddWithValue("@UserID", HttpUtility.UrlEncode(userId));
            cmd.Parameters.AddWithValue("@UserPassword", HttpUtility.UrlEncode(userPassword));
            cmd.ExecuteNonQuery();
            con.Close();
            System.Windows.Forms.MessageBox.Show("회원가입 성공");
        }

        public bool UserCheck(string userId, string userPassword)
        {
            cmd.Parameters.Clear();
            cmd.Connection = OpenConnection();
            cmd.CommandText = "proc_Check_User";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", HttpUtility.UrlEncode(userId));
            cmd.Parameters.AddWithValue("@UserPassword", HttpUtility.UrlEncode(userPassword));
            var check = cmd.ExecuteScalar();
            con.Close();
            if ((int)check != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SaveXmlFile(XmlDocument xml)
        {
            XmlTextWriter writer = new XmlTextWriter("../../User.xml", Encoding.UTF8);
            writer.Formatting = Formatting.Indented; // 들여쓰기
            xml.WriteContentTo(writer); // 만든 xml객체를 파일로
            writer.Flush();
            writer.Close();
        }

        public void InsertXml(string userId, string userPassword, bool check)
        {
            XmlDocument xml = new XmlDocument();
            xml.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlNode root = xml.CreateElement("User");
            xml.AppendChild(root);
            XmlElement ID = xml.CreateElement("userID");
            ID.SetAttribute("userId", HttpUtility.UrlEncode(userId));
            root.AppendChild(ID);
            XmlElement Password = xml.CreateElement("Password");
            Password.InnerText = HttpUtility.UrlEncode(userPassword);
            ID.AppendChild(Password);
            XmlElement auto = xml.CreateElement("check");
            auto.InnerText = check.ToString();
            ID.AppendChild(auto);
            SaveXmlFile(xml);
        }

        public string[] CheckAutoLogin()
        {
            string[] userinfo = null;
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load("../../User.xml");
            }
            catch (Exception)
            {
                return userinfo;
            }
            string check = xml.SelectSingleNode("//check").InnerText;
            
            if (check == "True")
            {
                userinfo = new string[3];
                userinfo[0] = xml.SelectSingleNode("//userID").Attributes["userId"].Value;
                userinfo[1] = xml.SelectSingleNode("//Password").InnerText;
                userinfo[2] = xml.SelectSingleNode("//check").InnerText;
            }
            return userinfo;
        }
    }
}
