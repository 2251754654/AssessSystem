namespace Repositorys.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_Evaluation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_Evaluation()
        {
            TB_EvaluationInfoList = new HashSet<TB_EvaluationInfo>();
        }

        [Key]
        public int EvaluationID { get; set; }

        [Required]
        [StringLength(100)]
        public string EvaluationDetails { get; set; }

        public int UserIDBy { get; set; }

        public int UserIDMain { get; set; }

        public int Delete { get; set; }//ÊÇ·ñÉ¾³ý0É¾³ý£¬1Î´É¾³ý

        public virtual TB_UserInfo TB_UserInfoByItem { get; set; }

        public virtual TB_UserInfo TB_UserInfoMainItem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_EvaluationInfo> TB_EvaluationInfoList { get; set; }
    }
}
