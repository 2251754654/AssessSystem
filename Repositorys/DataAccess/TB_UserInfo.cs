namespace Repositorys.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_UserInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_UserInfo()
        {
            TB_Evaluation = new HashSet<TB_Evaluation>();
            TB_Evaluation1 = new HashSet<TB_Evaluation>();
        }

        [Key]
        public int UserInfoID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserInfoName { get; set; }

        public int UserInfoAge { get; set; }

        [Required]
        [StringLength(50)]
        public string UserInfoAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string UserInfoBirthday { get; set; }

        [Required]
        [StringLength(50)]
        public string UserPhone { get; set; }

        [Required]
        [StringLength(50)]
        public string UserInfoEmail { get; set; }

        [Required]
        [StringLength(50)]
        public string UserInfoWorkPhone { get; set; }

        [Required]
        [StringLength(50)]
        public string UserCurrentAddress { get; set; }

        [StringLength(50)]
        public string UserInfoQQ { get; set; }

        [StringLength(200)]
        public string UserInfoDetails { get; set; }

        public int UserInfoDelete { get; set; }

        public int RoleID { get; set; }

        public int UserID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Evaluation> TB_Evaluation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Evaluation> TB_Evaluation1 { get; set; }

        public virtual TB_Role TB_Role { get; set; }

        public virtual TB_User TB_User { get; set; }
    }
}
