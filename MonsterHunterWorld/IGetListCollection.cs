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
        /// <summary>
        /// 해당 도감 전체를 파싱
        /// </summary>
        /// <returns></returns>
        IList<T> GetListCollection();

        /// <summary>
        /// 해당 도감에서 필요한 일부만 파싱
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        IList<T> GetListCollection(VO.Parameter parameter);
    }
}
