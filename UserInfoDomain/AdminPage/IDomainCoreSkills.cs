using Models;
using System.Collections.Generic;

namespace Domains
{
    public interface IDomainCoreSkills
    {
        List<ModelCoreSkills> FindAllCoreSkills();
        bool UpdateCoreSkills(ModelCoreSkills modelCoreSkills);
        bool DeleteCoreSkills(int coreSkillsID);
        bool InsertCoreSkills(ModelCoreSkills modelCoreSkills);
        List<ModelCoreLever> FindAllLever(int coreSkillsID);
        bool DeleteLever(int coreSkillsID, int coreLeverID);
        bool InsertLever(ModelCoreLever modelCoreLever);
        List<ModelCoreSkills> AllotCoreSkills(int professionalID);
    }
}