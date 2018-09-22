namespace Repositorys.DataAccess
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TB_Role
    {
        public TB_Role()
        {
            TB_RoleContent = new HashSet<TB_RoleContent>();
        }

        [Key]
        public int RoleID { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        [Required]
        [StringLength(100)]
        public string RoleDetails { get; set; }

        public int RoleDelete { get; set; }

        public virtual ICollection<TB_RoleContent> TB_RoleContent { get; set; }

        public virtual ICollection<TB_User> TB_User { get; set; }
    }
}
