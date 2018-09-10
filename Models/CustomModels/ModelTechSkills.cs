namespace Models
{

    using System.Collections.Generic;

    public partial class ModelTechSkills
    {
        public int TeachSkillsID { get; set; }
        public string TeachSkillsName { get; set; }
        public string TeachAkillsDetails { get; set; }
        public string TeachAkillsGUID { get; set; }

        public virtual ICollection<ModelMappingTeach> ModelMappingTeachs { get; set; }
        public virtual ICollection<ModelTeachLever> ModelTeachLevers { get; set; }
    }
}
