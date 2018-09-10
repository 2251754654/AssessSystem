using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ModelProfessional
    {
        public int ProfessionalID { get; set; }
        public string ProfessionalName { get; set; }
        public string ProfessionalDetails { get; set; }
        public int ProfessionalDelete { get; set; }

        public virtual ICollection<ModelMappingCore> ModelMappingCores { get; set; }
        public virtual ICollection<ModelMappingTeach> ModelMappingTeachs { get; set; }
        public virtual ICollection<ModelRoleContent> ModelRoleContents { get; set; }
    }
}
