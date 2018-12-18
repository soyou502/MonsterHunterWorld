using MonsterHunterWorld.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterHunterWorld
{
    public partial class FrmsignIn : Form
    {
        MonsterHunterUserDB db;
        bool idCheck = false;
        bool passwordCheck = false;
        public FrmsignIn()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(db.UserIDCheck(txtID.Text))
            {
                MessageBox.Show("사용가능한 아이디입니다.");
                idCheck = true;
            }else
            {
                MessageBox.Show("사용불가능한 아이디입니다.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!idCheck)
            {
                MessageBox.Show("아이디 중복확인이 필요합니다.");
                return;
            }
            if (!passwordCheck)
            {
                MessageBox.Show("비밀번호가 다릅니다.");
                return;
            }

        }

        private void FrmsignIn_Load(object sender, EventArgs e)
        {
            db = new MonsterHunterUserDB();
        }

        private void txtRePassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtRePassword.Text)
            {
                passwordCheck = true;
            }else
            {
                passwordCheck = false;
            }

            db.InsertUserInfo(txtID.Text, txtPassword.Text);
        }
    }
}
