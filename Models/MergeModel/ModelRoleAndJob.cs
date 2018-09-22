using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ModelRoleAndJob
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string RoleDetails { get; set; }
        public int RoleDelete { get; set; }

        public int ProfessionalID { get; set; }
        public string ProfessionalName { get; set; }
        public string ProfessionalDetails { get; set; }
        public int ProfessionalDelete { get; set; }
    }
}
