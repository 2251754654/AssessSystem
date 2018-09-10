using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ModelCoreSkills
    {
        public int CoreSkillsID { get; set; }
        public string CoreSkillsName { get; set; }
        public string CoreSkillsDetails { get; set; }
        public string CoreSkillsGUID { get; set; }


        public virtual ICollection<ModelCoreLever> ModelCoreLeverItem { get; set; }
        public virtual ICollection<ModelMappingCore> TB_MappingCoreItem { get; set; }
    }
}
