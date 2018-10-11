namespace Repositorys.DataAccess.MappingModule
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Repositorys.DataAccess.ProfessModule;
    using Repositorys.DataAccess.UserModule;

    public  class Role_Profess
    {
        public Guid Guid { get; set; }
        public Guid RoleGuid { get; set; }
        public Guid ProfessGuid { get; set; }

        public virtual Role Role { get; set; }
        public virtual Profess Profess { get; set; }
    }
}
