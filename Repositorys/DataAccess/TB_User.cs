namespace Repositorys.DataAccess
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public  class TB_User
    {
        public TB_User()
        {
            TB_Evaluation = new HashSet<TB_Evaluation>();
        }

        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string UserPassword { get; set; }

        [Required]
        [StringLength(50)]
        public string UserLastDate { get; set; }

        public int UserLever { get; set; }

        public int UserConfirm { get; set; }

        public int Login { get; set; }

        public int UserDelete { get; set; }

        public int RoleID { get; set; }
        
        public virtual ICollection<TB_Evaluation> TB_Evaluation { get; set; }
    }
}
