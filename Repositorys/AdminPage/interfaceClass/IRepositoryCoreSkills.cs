using System.Collections.Generic;
using Models;

namespace Repositorys
{
    public interface IRepositoryCoreSkills
    {
        bool FakeDelete(int id);
        List<ModelCoreSkills> FindAllCoreSkill();
        List<ModelCoreSkills> FindAllDeleteCoreSkill();
        List<ModelCoreSkills> FindAllNotDeleteCoreSkill();
        ModelCoreSkills FindCoreSkill(int id);
        bool Insert(ModelCoreSkills modelCoreSkills);
        bool ReallyDelete(int id);
        bool Update(ModelCoreSkills modelCoreSkills);
        List<ModelCoreSkills> FindCoreSkillByProfessionalID(int professionalID);
    }
}