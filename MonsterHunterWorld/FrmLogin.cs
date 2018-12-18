using MonsteHunterWorld;
using MonsterHunterWorld.BUS;
using MonsterHunterWorld.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;

namespace MonsterHunterWorld
{
    public partial class FrmLogin : Form
    {
        MonsterHunterUserDB db;
        public FrmLogin()
        {
            db = new MonsterHunterUserDB();
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmsignIn fsi = new FrmsignIn();
            fsi.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(db.UserCheck(txtUserID.Text, txtUserPassword.Text))
            {
                db.InsertXml(txtUserID.Text, txtUserPassword.Text, chkAutoLogin.Checked);
                FrmItems frmItems = new FrmItems();
                frmItems.ShowDialog();
            }else
            {
                MessageBox.Show("아이디 또는 비밀번호를 확인해주세요.");
                return;
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            string[] userinfo = db.CheckAutoLogin();
            if (userinfo != null)
            {
                txtUserID.Text = HttpUtility.UrlDecode(userinfo[0]);
                txtUserPassword.Text = HttpUtility.UrlDecode(userinfo[1]);
                chkAutoLogin.Checked = bool.Parse(userinfo[2]);
                button1_Click(null, null);
            }
        }
    }
}
