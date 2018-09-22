using System.Collections.Generic;
using Models;

namespace Repositorys
{
    public interface IRepositoryMapingCore
    {
        List<ModelJobAndCoreSkill> FindCoreSkillAllJob(int id);
        List<ModelJobAndCoreSkill> FindJobAllCoreSkill();
        List<ModelJobAndCoreSkill> FindJobAllCoreSkill(int id);
        bool Insert(int professionalID, int coreSkillsID);
    }
}