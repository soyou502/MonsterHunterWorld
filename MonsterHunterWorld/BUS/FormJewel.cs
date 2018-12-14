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
    public partial class FormJewel : Form,IGetListCollection<VO.Jewel>
    {
        static List<VO.Jewel> jewelList;
        public FormJewel()
        {
            InitializeComponent();
        }

        public IList<Jewel> GetListCollection(Parameter parameter)
        {
            if (jewelList != null)
            {
                DAO.MonsterHunterAPI api = new DAO.MonsterHunterAPI();
                JArray ja = JArray.Parse(api.GetJson(parameter));
                foreach (var item in ja)
                {
                    jewelList.Add(new Jewel
                    {

                    });
                }
            }
            return jewelList;
        }
    }
}
