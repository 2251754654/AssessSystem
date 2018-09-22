using System.Collections.Generic;
using Models;

namespace Domains
{
    public interface IDomainJob
    {
        bool DeleteJob(int jobID);
        List<ModelProfessional> FindAllJob();
        ModelProfessional FindJob(int jobID);
        bool InsertJob(ModelProfessional modelProfessional);
        bool UpdateJob(ModelProfessional modelProfessional);
        bool InsertProfessionalCoreSkills(int professionalID, int coreSkillsID);
        bool InsertProfessionalTeachSkills(int professionalID, int teachSkillsID);
        List<ModelProfessional> AllotedProfessional(int roleID);
    }
}