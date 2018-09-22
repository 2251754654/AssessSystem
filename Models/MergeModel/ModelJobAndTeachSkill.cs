using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ModelJobAndTeachSkill
    {
        public int ProfessionalID { get; set; }
        public string ProfessionalName { get; set; }
        public string ProfessionalDetails { get; set; }
        public int ProfessionalDelete { get; set; }

        public int TeachSkillsID { get; set; }
        public string TeachSkillsName { get; set; }
        public string TeachAkillsDetails { get; set; }
        public string TeachAkillsGUID { get; set; }
        public int TeachSkillDelete { get; set; }


    }
}
