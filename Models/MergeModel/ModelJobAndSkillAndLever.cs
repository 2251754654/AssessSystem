using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ModelJobAndSkillAndLever
    {
        public int CoreLeverID { get; set; }
        public int CoreLeverNum { get; set; }
        public string CoreLeverDetails { get; set; }
        public int CoreSkillsID { get; set; }
        public int CoreLeverDelete { get; set; }

        //public int CoreSkillsID { get; set; }
        public string CoreSkillsName { get; set; }
        public string CoreSkillsDetails { get; set; }
        public string CoreSkillsGUID { get; set; }
        public int CoreSkillsDelete { get; set; }

        public int ProfessionalID { get; set; }
        public string ProfessionalName { get; set; }
        public string ProfessionalDetails { get; set; }
        public int ProfessionalDelete { get; set; }



        
    }

}
