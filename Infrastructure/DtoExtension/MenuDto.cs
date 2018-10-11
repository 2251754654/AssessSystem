using Repositorys.DataAccess.MappingModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoExtension
{
    public class MenuDto
    {
        public Guid Guid { get; set; }
        public string MenuName { get; set; }
        public string Specific { get; set; }
        public int State { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }//最后一次操作时间
        public int VisitCount { get; set; }//访问次数

        public virtual ICollection<Role_Menu> RoleMenus { get; set; }
    }
}
