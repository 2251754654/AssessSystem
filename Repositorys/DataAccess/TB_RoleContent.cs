namespace Repositorys.DataAccess
{
    using System.ComponentModel.DataAnnotations;

    public partial class TB_RoleContent
    {
        [Key]
        public int RoleContentID { get; set; }

        public int RoleID { get; set; }

        public int ProfessionalID { get; set; }

        public virtual TB_Professional TB_Professional { get; set; }

        public virtual TB_Role TB_Role { get; set; }
    }
}
