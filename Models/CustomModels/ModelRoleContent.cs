namespace Models
{
    public partial class ModelRoleContent
    {
        public int RoleContentID { get; set; }
        public int RoleID { get; set; }
        public int ProfessionalID { get; set; }
        public virtual ModelProfessional ModelProfessionalItem { get; set; }
        public virtual ModelRole ModelRoleItem { get; set; }
    }
}
