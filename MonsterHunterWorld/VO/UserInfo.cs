using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{
    class UserInfo
    {
        private string userID;
        private string userPassword;

        public UserInfo(string userID, string userPassword)
        {
            this.userID = userID;
            this.userPassword = userPassword;
        }

        public string UserID { get => userID; set => userID = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }
    }
}
