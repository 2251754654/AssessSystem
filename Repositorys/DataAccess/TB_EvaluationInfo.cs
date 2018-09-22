namespace Repositorys.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class TB_EvaluationInfo
    {
        [Key]
        public int EvaluationInfoID { get; set; }

        [Required]
        [StringLength(50)]
        public string SkillsGUID { get; set; }

        

        public int Lever { get; set; }

        public int EvaluationID { get; set; }
        [ForeignKey("EvaluationID")]
        public virtual TB_Evaluation TB_Evaluation { get; set; }
    }
}
