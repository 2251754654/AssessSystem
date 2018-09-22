namespace Repositorys.DataAccess
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TB_TechSkills
    {
        public TB_TechSkills()
        {
            TB_MappingTeach = new HashSet<TB_MappingTeach>();
            TB_TeachLever = new HashSet<TB_TeachLever>();
        }

        [Key]
        public int TeachSkillsID { get; set; }

        [Required]
        [StringLength(50)]
        public string TeachSkillsName { get; set; }

        [Required]
        [StringLength(100)]
        public string TeachSkillsDetails { get; set; }

        [Required]
        [StringLength(50)]
        public string TeachSkillsGUID { get; set; }

        public int TeachSkillDelete { get; set; }

        public virtual ICollection<TB_MappingTeach> TB_MappingTeach { get; set; }

        public virtual ICollection<TB_TeachLever> TB_TeachLever { get; set; }
    }
}
