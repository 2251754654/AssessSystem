namespace Models
{
    public partial class ModelMappingTeach
    {
        public int MappingID { get; set; }
        public int ProfessionalID { get; set; }
        public int TeachSkillsID { get; set; }

        public virtual ModelProfessional ModelProfessionalItem { get; set; }
        public virtual ModelTechSkills TB_TechSkillsItem { get; set; }
    }
}
