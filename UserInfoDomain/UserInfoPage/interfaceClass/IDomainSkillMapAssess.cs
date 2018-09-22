using System.Collections.Generic;
using Models;

namespace Domains
{
    public interface IDomainSkillMapAssess
    {
        Dictionary<ModelJobAndSkillAndLever, List<int>> FindCoreSkillAllState(int userID, int roleID);
        Dictionary<ModelJobAndSkillAndLever, int> FindCoreSkillNowState(int roleID, int assessID);
    }
}