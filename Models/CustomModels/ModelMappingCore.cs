namespace Models
{
    public partial class ModelMappingCore
    {
        public int MappingID { get; set; }
        public int ProfessionalID { get; set; }
        public int CoreSkillsID { get; set; }

        public virtual ModelCoreSkills ModelCoreSkillsItem { get; set; }
        public virtual ModelProfessional ModelProfessionalItem { get; set; }
    }
}
