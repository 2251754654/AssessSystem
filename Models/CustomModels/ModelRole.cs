using Models;
using System.Collections.Generic;

namespace Models
{
    public class ModelRole
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string RoleDetails { get; set; }
        public int RoleDelete { get; set; }

        public virtual ICollection<ModelRoleContent> ModelRoleContentList { get; set; }
    }
}