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
    public partial class FormSkill : Form, IGetListCollection<VO.Skill>
    {
        static List<Skill> skills;
        public FormSkill()
        {
            InitializeComponent();
        }

        public IList<Skill> GetListCollection()
        {
            if (skills == null)
            {
                skills = new List<Skill>();
                VO.Parameter parameter = new Parameter("skills");
                DAO.MonsterHunterAPI api = new DAO.MonsterHunterAPI();

                JArray ja = JArray.Parse(api.GetJson(parameter));
                foreach (var item in ja)
                {
                    Skill skill = SetSkill(item);
                    skills.Add(skill);
                }
            }
            return skills;
        }

        public IList<Skill> GetListCollection(Parameter parameter)
        {
            List<Skill> searchSkills = new List<Skill>();
            DAO.MonsterHunterAPI api = new DAO.MonsterHunterAPI();

            JArray ja = JArray.Parse(api.GetJson(parameter));
            foreach (var item in ja)
            {
                Skill skill = SetSkill(item);
                skills.Add(skill);
            }
            return searchSkills;
        }

        private Skill SetSkill(JToken item)
        {
            Skill skill = new Skill();
            skill.Idx = Convert.ToInt32(item["idx"].ToString());
            skill.Name = item["name"].ToString();
            skill.Type = item["type"].ToString();
            skill.Desc = new List<SkillDesc>();
            foreach (var subitem in item["desc"])
            {
                SkillDesc desc = new SkillDesc();
                desc.Name = subitem["name"].ToString();
                desc.Level = Convert.ToInt32(subitem["level"].ToString());
                desc.Desc = subitem["desc"].ToString();
                skill.Desc.Add(desc);
            }
            return skill;
        }
    }
}
