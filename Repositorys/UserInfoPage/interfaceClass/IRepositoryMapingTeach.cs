using System.Collections.Generic;
using Models;

namespace Repositorys
{
    public interface IRepositoryMapingTeach
    {
        List<ModelJobAndTeachSkill> FindJobAllTeachSkill();
        List<ModelJobAndTeachSkill> FindJobAllTeachSkill(int id);
        List<ModelJobAndTeachSkill> FindTeachSkillAllJob(int id);
        bool Insert(int professionalID, int teachSkillsID);
    }
}