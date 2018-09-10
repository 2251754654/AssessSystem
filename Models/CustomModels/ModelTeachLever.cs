namespace Models
{
    public partial class ModelTeachLever
    {
        public int TeachLeverID { get; set; }
        public int TeachLeverNum { get; set; }
        public string TeachLeverDetails { get; set; }
        public int TeachSkillsID { get; set; }

        public virtual ModelTechSkills ModelTechSkillItem { get; set; }
    }
}
