namespace Repositorys.DataAccess
{
    using System.ComponentModel.DataAnnotations;

    public partial class TB_TeachLever
    {
        [Key]
        public int TeachLeverID { get; set; }

        public int TeachLeverNum { get; set; }

        [Required]
        [StringLength(100)]
        public string TeachLeverDetails { get; set; }

        public int TeachSkillsID { get; set; }

        public int TeachLeverDelete { get; set; }

        public virtual TB_TechSkills TB_TechSkills { get; set; }
    }
}
