using System.Collections.Generic;
using Models;

namespace Domains
{
    public interface IDomainUserTeachSkills
    {
        List<ModelTeachLever> FindAllLever(int skillID);
        ModelProfessional FindJob(int jobID);
        List<ModelJobAndTeachSkill> FindJobAllTeachSkill(int jobID);
        List<ModelJobAndTeachSkillAndLever> FindJobAndSkillAndLever(int roleID);
        Dictionary<ModelRoleAndJob, Dictionary<ModelJobAndTeachSkill, List<ModelTeachLever>>> FindJobAndSkillAndLeverThreeLayers(int roleID);
        List<Dictionary<ModelRoleAndJob, Dictionary<ModelJobAndTeachSkill, ModelTeachLever>>> FindJobAndSkillAndLeverThreeLayersList(int roleID);
        ModelTeachLever FindOneLever(int teachSkillID, int leverID);
        ModelRole FindRole(int roleID);
        List<ModelRoleAndJob> FindRoleAllJob(int roleID);
        ModelTechSkills FindTeachSkill(int skillID);
        List<ModelJobAndTeachSkill> FindTeachSkillAllJob(int TeachSkillID);
    }
}