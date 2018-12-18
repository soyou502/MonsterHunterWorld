using MonsterHunterWorld.BUS;
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
                Form1 form = new Form1();
                form.Show();
            }else
            {
                MessageBox.Show("아이디 또는 비밀번호를 확인해주세요.");
                return;
            }
        }
    }
}
