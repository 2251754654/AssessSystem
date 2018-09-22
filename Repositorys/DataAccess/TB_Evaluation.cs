namespace Repositorys.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class TB_Evaluation
    {
        public TB_Evaluation()
        {
            TB_EvaluationInfoList = new HashSet<TB_EvaluationInfo>();
        }

        [Key]
        public int EvaluationID { get; set; }

        [Required]
        [StringLength(100)]
        public string EvaluationDetails { get; set; }


        public int UserIDMain { get; set; }

        public int Delete { get; set; }//ÊÇ·ñÉ¾³ý0É¾³ý£¬1Î´É¾³ý

        public int UserIDBy { get; set; }
        [ForeignKey("UserIDBy")]
        public virtual TB_User TB_User { get; set; }

        public virtual ICollection<TB_EvaluationInfo> TB_EvaluationInfoList { get; set; }
    }
}
