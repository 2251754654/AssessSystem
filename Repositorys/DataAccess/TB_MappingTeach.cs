namespace Repositorys.DataAccess
{
    using System.ComponentModel.DataAnnotations;

    public  class TB_MappingTeach
    {
        [Key]
        public int MappingID { get; set; }

        public int ProfessionalID { get; set; }

        public int TeachSkillsID { get; set; }



        public virtual TB_Professional TB_Professional { get; set; }

        public virtual TB_TechSkills TB_TechSkills { get; set; }
    }
}
