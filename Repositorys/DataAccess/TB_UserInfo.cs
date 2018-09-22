namespace Repositorys.DataAccess
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public  class TB_UserInfo
    {
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
       
        public int UserID { get; set; }

    }
}
