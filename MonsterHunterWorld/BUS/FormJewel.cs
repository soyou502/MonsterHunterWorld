using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonsterHunterWorld.VO;
using Newtonsoft.Json.Linq;

namespace MonsterHunterWorld.BUS
{
    public partial class FormJewel : Form, IGetListCollection<VO.Jewel>
    {
        static List<VO.Jewel> jewels;
        public FormJewel()
        {
            InitializeComponent();
        }

        public IList<Jewel> GetListCollection(Parameter parameter)
        {
            List<Jewel> searchJewels = new List<Jewel>();
            DAO.MonsterHunterAPI api = new DAO.MonsterHunterAPI();

            JArray ja = JArray.Parse(api.GetJson(parameter));
            foreach (var item in ja)
            {
                Jewel jewel = SetJewel(item);
                searchJewels.Add(jewel);
            }

            return searchJewels;
        }

        public IList<Jewel> GetListCollection()
        {
            if (jewels == null)
            {
                jewels = new List<Jewel>();
                Parameter parameter = new Parameter("jewels");
                DAO.MonsterHunterAPI api = new DAO.MonsterHunterAPI();

                JArray ja = JArray.Parse(api.GetJson(parameter));
                foreach (var item in ja)
                {
                    Jewel jewel = SetJewel(item);
                    jewels.Add(jewel);
                }
            }
            return jewels;
        }

        private Jewel SetJewel(JToken item)
        {
            Jewel jewel = new Jewel();
            jewel.Idx = Convert.ToInt32(item["idx"].ToString());
            jewel.Name = item["name"].ToString();
            jewel.Slot_level = Convert.ToInt32(item["slot_level"].ToString());
            jewel.Rare = Convert.ToInt32(item["rare"].ToString());
            jewel.Skill = new Skill(Convert.ToInt32(item["skill"]["idx"].ToString()), item["skill"]["name"].ToString(), item["skill"]["type"].ToString());
            return jewel;
        }
    }
}
