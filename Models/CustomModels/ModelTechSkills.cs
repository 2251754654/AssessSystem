namespace Models
{

    using System.Collections.Generic;

    public partial class ModelTechSkills
    {
        public int TeachSkillsID { get; set; }
        public string TeachSkillsName { get; set; }
        public string TeachSkillsDetails { get; set; }
        public string TeachSkillsGUID { get; set; }
        public int TeachSkillDelete { get; set; }
        

        public virtual ICollection<ModelMappingTeach> ModelMappingTeachs { get; set; }
        public virtual ICollection<ModelCoreLever> ModelTeachLevers { get; set; }
    }
}
