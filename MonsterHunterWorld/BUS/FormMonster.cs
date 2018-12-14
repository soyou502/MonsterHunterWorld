using MonsterHunterWorld.VO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterHunterWorld.BUS
{
    public partial class FormMonster : Form, IGetListCollection<VO.Monster>
    {
        List<Monster> monsters;
        public FormMonster()
        {
            InitializeComponent();
        }


        private void FormMonster_Load(object sender, EventArgs e)
        {

        }

        public IList<Monster> GetListCollection(Parameter parameter)
        {
            List<Monster> searchMonsters = new List<Monster>();
            DAO.MonsterHunterAPI api = new DAO.MonsterHunterAPI();

            JArray ja = JArray.Parse(api.GetJson(parameter));
            foreach (var item in ja)
            {
                Monster monster = SetMonster(item);
                searchMonsters.Add(monster);
            }

            return searchMonsters;
        }

        public IList<Monster> GetListCollection()
        {
            if (monsters == null)
            {
                monsters = new List<Monster>();
                Parameter parameter = new Parameter("monsters");
                DAO.MonsterHunterAPI api = new DAO.MonsterHunterAPI();

                JArray ja = JArray.Parse(api.GetJson(parameter));
                foreach (var item in ja)
                {
                    Monster monster = SetMonster(item);
                    monsters.Add(monster);
                }
            }
            return monsters;
        }

        private Monster SetMonster(JToken item)
        {
            Monster jewel = new Monster();

            return jewel;
        }
    }
}
