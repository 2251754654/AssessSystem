
using Repositorys.DataAccess.MappingModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys.DataAccess.UserModule
{
   public class User
    {
        public Guid Guid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime ReigstTime { get; set; }
        public DateTime LoginTime { get; set; }
        public int IsActivate { get; set; }//0未激活，1激活
        public int State { get; set; }//0正常，1删除
        public int VisitCount { get; set; }//访问次数

        public virtual UserInfo UserInfo { get; set; }
        public virtual ICollection<User_Role> User_Roles { get; set; }
    }
}
