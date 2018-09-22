using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ModelCoreLever
    {
        public int CoreLeverID { get; set; }
        public int CoreLeverNum { get; set; }
        public string CoreLeverDetails { get; set; }
        public int CoreSkillsID { get; set; }
        public int CoreLeverDelete { get; set; }


        public virtual ModelCoreSkills ModelCoreSkillsItem { get; set; }
    }
}
