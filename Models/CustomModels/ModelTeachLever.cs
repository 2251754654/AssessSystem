namespace Models
{
    public  class ModelTeachLever
    {
        public int TeachLeverID { get; set; }
        public int TeachLeverNum { get; set; }
        public string TeachLeverDetails { get; set; }
        public int TeachSkillsID { get; set; }
        public int TeachLeverDelete { get; set; }

        public virtual ModelTechSkills ModelTechSkillsItem { get; set; }
    }
}
