using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoExtension
{
   public  class RoleDto
    {
        public Guid Guid { get; set; }
        public string RoleName { get; set; }
        public string Specific { get; set; }//具体的说明
        public int State { get; set; }//0,正常，1，删除
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }//最后一次操作时间
        public int VisitCount { get; set; }//访问次数

        //public virtual ICollection<User_Role> User_Roles { get; set; }
        //public virtual ICollection<Role_Menu> Role_Menus { get; set; }
        //public virtual ICollection<Role_Profess> Role_Professs { get; set; }
    }
}
