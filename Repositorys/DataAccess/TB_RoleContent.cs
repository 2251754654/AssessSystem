namespace Repositorys.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
