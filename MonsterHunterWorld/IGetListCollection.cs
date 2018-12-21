using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld
{
    interface IGetListCollection<T>
    {
        IList<T> GetListCollection(VO.Parameter parameter);
    }
}
