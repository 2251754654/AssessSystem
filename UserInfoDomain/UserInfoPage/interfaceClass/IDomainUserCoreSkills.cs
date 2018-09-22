using System.Collections.Generic;
using Models;

namespace Domains
{
    public interface IDomainUserCoreSkills
    {
        List<ModelCoreLever> FindAllLever(int skillID);
        ModelCoreSkills FindCoreSkill(int skillID);
        List<ModelJobAndCoreSkill> FindCoreSkillAllJob(int coreSkillID);
        ModelProfessional FindJob(int jobID);
        List<ModelJobAndCoreSkill> FindJobAllCoreSkill(int jobID);
        List<ModelJobAndSkillAndLever> FindJobAndSkillAndLever(int roleID);
        Dictionary<ModelRoleAndJob, Dictionary<ModelJobAndCoreSkill, List<ModelCoreLever>>> FindJobAndSkillAndLeverThreeLayers(int roleID);
        List<Dictionary<ModelRoleAndJob, Dictionary<ModelJobAndCoreSkill, ModelCoreLever>>> FindJobAndSkillAndLeverThreeLayersList(int roleID);
        ModelCoreLever FindOneLever(int coreSkillID, int leverID);
        ModelRole FindRole(int roleID);
        List<ModelRoleAndJob> FindRoleAllJob(int roleID);
    }
}